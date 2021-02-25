using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFallScript : MonoBehaviour
{
    public GameObject carBodyHolder;
    public GameObject tire1;
    public GameObject tire2;
    public GameObject checkPoint;
    public bool checker;
    public GameObject winPanel;

    private void Start()
    {
        checker = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fallplane")
        {
            Debug.Log("car fall");
            tire1.GetComponent<FixedJoint>().connectedBody = null;
            tire2.GetComponent<FixedJoint>().connectedBody = null;

            carBodyHolder.GetComponent<Rigidbody>().isKinematic = true;
            if (checker == false)
            {
                checker = true;
                GoToCheckPoint();
            }
        }
        else if (other.gameObject.tag == "checkpoint")
        {
            Debug.Log("checkpoint");
            checkPoint = other.gameObject;
        }
        else if (other.gameObject.tag == "finishline")
        {
            Debug.Log("finishline");
            carBodyHolder.GetComponent<Rigidbody>().isKinematic = true;
            tire1.GetComponent<TireScript>().turnSpeed = 0;
            tire2.GetComponent<TireScript>().turnSpeed = 0;
            winPanel.SetActive(true);
        }
    }
    void GoToCheckPoint()
    {
        Debug.Log("go to checkpoint");

        tire1.SetActive(false);
        tire2.SetActive(false);
        tire1.transform.position = checkPoint.transform.position;
        tire2.transform.position = checkPoint.transform.position;
    }
}
