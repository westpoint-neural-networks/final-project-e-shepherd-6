using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget1 : MonoBehaviour
{
    public Transform agent;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = agent.transform.position;
        //this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        this.transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
    }
}
