using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawScript : MonoBehaviour
{
    public CreateCarBodyScript ccbs;
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public List<Vector2> fingerPos;
    public float camDist;
    public bool clicked;
    public bool correctPlace;

    void Start()
    {
        clicked = false;
        correctPlace = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            CheckDrawPanel();

            if (correctPlace)
            {
                Time.timeScale = 0;
                CreateLine();
            }
        }

        if (correctPlace == false)
        {
            Time.timeScale = 1;
            Destroy(currentLine);
            clicked = false;
        }

        if (Input.GetMouseButton(0) && correctPlace)
        {
            CheckDrawPanel();

            var mousePos = Input.mousePosition;
            mousePos.z = camDist;

            Vector2 tempPos = Camera.main.ScreenToWorldPoint(mousePos);
            float distance = Vector2.Distance(tempPos, fingerPos[fingerPos.Count - 1]);

            if (distance > 0.05f)
            {
                DrawLine(tempPos);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            if (correctPlace)
            {
                correctPlace = false;
                Debug.Log("create car body");

                List<Vector2> temp = new List<Vector2>(fingerPos);
                ccbs.coords = temp;
                ccbs.CreateBody();
            }
        }
    }
    void CreateLine()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = camDist;

        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        fingerPos.Clear();
        fingerPos.Add(Camera.main.ScreenToWorldPoint(mousePos));
        fingerPos.Add(Camera.main.ScreenToWorldPoint(mousePos));
        lineRenderer.SetPosition(0, fingerPos[0]);
        lineRenderer.SetPosition(1, fingerPos[1]);

    }

    void DrawLine(Vector2 newFingerPos)
    {
        fingerPos.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
    }

    void CheckDrawPanel()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.name == "DrawPanel")
            {
                correctPlace = true;
                return;
            }
        }
        correctPlace = false;
    }
}
