using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//defines behavior for camera following agent
public class CamTarget : MonoBehaviour
{
    public Transform agent;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = agent.transform.position;
        this.transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
    }
}
