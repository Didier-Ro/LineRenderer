using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer = default;
    [SerializeField] private List<Vector3> points = default;

    private void Awake()
    {
        _lineRenderer.positionCount = 0;
        points = new List<Vector3>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tracer();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _lineRenderer.positionCount = 0;
            points.Clear();
        }
    }

    private void Tracer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 5f);
            _lineRenderer.positionCount++;
            points.Add(hit.point);
            
            if(points.Count >= 2)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    _lineRenderer.SetPosition(i, points[i]);
                }

            }
        }
    }
}
