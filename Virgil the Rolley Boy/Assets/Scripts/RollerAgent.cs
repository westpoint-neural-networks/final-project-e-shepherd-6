using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RollerAgent : Agent
{
    //Define variables
    Rigidbody rBody;
    public Transform Target;
    public float closestDist;
    public Vector3[] positionArray = new Vector3[9];
    public Vector3[] positionArray1 = new Vector3[8];

    //Start function runs at beginning of every epoch
    void Start()
    {
        rBody = GetComponent<Rigidbody>();

        //Establish spawn positions for target
        positionArray[0] = new Vector3(0f, 0.5f, 0f);
        positionArray[1] = new Vector3(6f, 0.5f, -18.5f);
        positionArray[2] = new Vector3(-6f, 0.5f, -18.5f);
        positionArray[3] = new Vector3(-6f, 0.5f, -6f);
        positionArray[4] = new Vector3(6f, 0.5f, -6f);
        positionArray[5] = new Vector3(6f, 0.5f, 6f);
        positionArray[6] = new Vector3(-6f, 0.5f, 6f);
        positionArray[7] = new Vector3(6f, 0.5f, 18.5f);
        positionArray[8] = new Vector3(-6f, 0.5f, 18.5f);
        positionArray1[0] = new Vector3(18.5f, 0.5f, 18.5f);
        positionArray1[1] = new Vector3(18.5f, 0.5f, 6f);
        positionArray1[2] = new Vector3(18.5f, 0.5f, -6f);
        positionArray1[3] = new Vector3(18.5f, 0.5f, -18.5f);
        positionArray1[4] = new Vector3(-18.5f, 0.5f, -18.5f);
        positionArray1[5] = new Vector3(-18.5f, 0.5f, -6f);
        positionArray1[6] = new Vector3(-18.5f, 0.5f, 6f);
        positionArray1[7] = new Vector3(-18.5f, 0.5f, 18.5f);
    }

    //Reset runs when the agent falls off the map, collides with target, or when epoch ends
    public override void AgentReset()
    {

        // If the Agent fell, zero its momentum
        this.rBody.angularVelocity = Vector3.zero;
        this.rBody.velocity = Vector3.zero;
        this.transform.localPosition = new Vector3(20f, 0.5f, 0f);
        closestDist = Vector3.Distance(this.transform.localPosition, Target.localPosition);
    }

    //Executed at every frame, take environment inputs
    public override void CollectObservations()
    {
        // Target and Agent positions
        AddVectorObs(Target.localPosition);
        AddVectorObs(this.transform.localPosition);
        AddVectorObs(Vector3.Distance(this.transform.localPosition, Target.localPosition));
    }

    // a rigidbody tagged as "Wall" hit the player, small punishment
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            AddReward(-0.01f);
        }
    }

    //Executes after all calculations are done for a frame, determines action agent will take
    public float speed = 10;
    public override void AgentAction(float[] vectorAction)
    {
        //Small punishment executed every frame to encourage rapidly finding target
        AddReward(-0.001f/50f);
        
        // Actions
        Vector3 controlSignal = new Vector3(vectorAction[0], 0f, vectorAction[1]) * speed * Time.deltaTime;
        transform.Translate(controlSignal, Space.Self);
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition,
                                                  Target.localPosition);

        //Small reward for getting closer to target
        if (distanceToTarget < closestDist)
        {
            closestDist = distanceToTarget;
            AddReward(0.001f / 40f);
        }

        // Reached target
        if (distanceToTarget < 1.42f)
        {
            AddReward(1.0f);
            // Move the target to a new spot
            if (Random.Range(0, 2) == 0)
            {
                Target.localPosition = positionArray[Random.Range(0, 9)];
            }
            else
            {
                Target.localPosition = positionArray1[Random.Range(0, 8)];
            }
            Done();
        }

        // Fell off platform
        if (this.transform.localPosition.y < 0)
        {
            AddReward(-0.1f);
            Done();
        }

    }

    //Can enable heuristic brain in Unity control panel for player controlled agent
    public override float[] Heuristic()
    {
        var action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }
}