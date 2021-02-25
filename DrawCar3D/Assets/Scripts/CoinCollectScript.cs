using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectScript : MonoBehaviour
{
    public UiControllerScript uics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin" && other.GetComponent<CoinScript>().collected == false)
        {
            other.GetComponent<CoinScript>().collected = true;
            
            uics.point += other.GetComponent<CoinScript>().point;

            Destroy(other.gameObject);
        }
    }
}
