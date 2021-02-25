using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControllerScript : MonoBehaviour
{
    public int point;
    public Text pointText;
    public Slider slider;
    public float startingDist;
    public float currentDist;

    public Transform tire1;
    public Transform tire2;
    public Transform finishLine;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        var x = (tire1.transform.position.x + tire2.transform.position.x) / 2;
        startingDist = finishLine.position.x - x;
        slider.maxValue = startingDist;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var x = (tire1.transform.position.x + tire2.transform.position.x) / 2;
        currentDist = startingDist - (finishLine.position.x - x);
        slider.value = currentDist;

        pointText.text = "POINT: " + point;
    }
}
