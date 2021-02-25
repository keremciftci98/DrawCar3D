using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCarBodyScript : MonoBehaviour
{
    public List<Vector2> coords;
    public GameObject carBodyHolder;
    public GameObject carBodyPart;
    public GameObject tire1;
    public GameObject tire2;
    public float yDist;
    public CarFallScript cfs;

    public void CreateBody()
    {
        cfs.checker = false;
        tire1.SetActive(true);
        tire2.SetActive(true);
        tire1.GetComponent<FixedJoint>().connectedBody = null;
        tire2.GetComponent<FixedJoint>().connectedBody = null;

        carBodyHolder.GetComponent<Rigidbody>().isKinematic = true;
        carBodyHolder.transform.rotation = Quaternion.identity;

        carBodyHolder.transform.position = new Vector3(coords[0].x, coords[0].y + yDist, 0);

        foreach (Transform child in carBodyHolder.transform)
        {
            if (child.tag != "tire")
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < coords.Count; i++)
        {
            var newPart = Instantiate(carBodyPart, new Vector3(coords[i].x, coords[i].y + yDist, 0), Quaternion.identity);
            newPart.transform.parent = carBodyHolder.transform;
        }

        tire1.transform.position = new Vector3(coords[0].x, coords[0].y + yDist, 0);
        tire2.transform.position = new Vector3(coords[coords.Count - 1].x, coords[coords.Count - 1].y + yDist, 0);


        tire1.GetComponent<Rigidbody>().isKinematic = false;
        tire2.GetComponent<Rigidbody>().isKinematic = false;
        carBodyHolder.GetComponent<Rigidbody>().isKinematic = false;

        tire1.GetComponent<FixedJoint>().connectedBody = carBodyHolder.GetComponent<Rigidbody>();
        tire2.GetComponent<FixedJoint>().connectedBody = carBodyHolder.GetComponent<Rigidbody>();

        if (coords.Count < 30)
        {
            tire1.GetComponent<TireScript>().maxSpeed = 8;
            tire2.GetComponent<TireScript>().maxSpeed = 8;

        }
        else if (coords.Count >= 30 && coords.Count <= 60)
        {
            tire1.GetComponent<TireScript>().maxSpeed = 10;
            tire2.GetComponent<TireScript>().maxSpeed = 10;
        }
        else if (coords.Count > 60)
        {
            tire1.GetComponent<TireScript>().maxSpeed = 12;
            tire2.GetComponent<TireScript>().maxSpeed = 12;
        }
    }
}
