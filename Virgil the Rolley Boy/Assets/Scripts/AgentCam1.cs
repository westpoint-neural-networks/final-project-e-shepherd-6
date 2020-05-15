using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ensures camera stays locked in position over agent
public class AgentCam1 : MonoBehaviour
{

    Vector3 myPos = new Vector3(0f, 7.71f, -9.3f);
    public Transform myPlay;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = myPlay.position + myPos;
        this.transform.rotation = Quaternion.Euler(40.528f, 0f, 0f);
    }
}
