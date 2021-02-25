using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform tire1;
    public Transform tire2;
    public GameObject myCam;
    public Vector3 myPos;

    // Update is called once per frame
    void Update()
    {
        var x = (tire1.transform.position.x + tire2.transform.position.x) / 2;
        myPos = new Vector3(x, tire1.transform.position.y + 0.8f, myCam.transform.position.z);
        myCam.transform.position = myPos;
    }
}
