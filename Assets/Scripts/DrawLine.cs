using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float minDistance = 0.1f;
    public Color defaultColor = Color.black;
    public float defaultWidth = 0.1f;

    private List<LineRenderer> lines = new List<LineRenderer>();
    private List<Color> lineColors = new List<Color>();
    private List<float> lineWidths = new List<float>();

    private EdgeCollider2D edgeCollider;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.startColor = lineRenderer.endColor = defaultColor;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
            StartNewLine();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLine();
        }
    }

    void StartNewLine()
    {
        LineRenderer newLineRenderer = new GameObject().AddComponent<LineRenderer>();
        newLineRenderer.transform.parent = transform;
        //newLineRenderer.startWidth = newLineRenderer.endWidth = defaultWidth;
        newLineRenderer = lineRenderer;
        newLineRenderer.material.color = defaultColor;

        lines.Add(newLineRenderer);
        lineColors.Add(defaultColor);
        lineWidths.Add(defaultWidth);

        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;
        newLineRenderer.positionCount = 1;
        newLineRenderer.SetPosition(0, currentPosition);

        edgeCollider.points = new Vector2[] { currentPosition, currentPosition };
    }

    void UpdateLine()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;

        LineRenderer currentLine = lines[lines.Count - 1];

        if (Vector3.Distance(currentPosition, currentLine.GetPosition(currentLine.positionCount - 1)) > minDistance)
        {
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, currentPosition);

            Vector2[] newPoints = edgeCollider.points;
            newPoints[newPoints.Length - 1] = currentPosition;
            edgeCollider.points = newPoints;
        }
    }

    public void ChangeColor(Color newColor)
    {
        if (lines.Count > 0)
        {
            lines[lines.Count - 1].startColor = lines[lines.Count - 1].endColor = newColor;
            lineColors[lineColors.Count - 1] = newColor;
        }
    }

    public void ChangeWidth(float newWidth)
    {
        if (lines.Count > 0)
        {
            lines[lines.Count - 1].startWidth = lines[lines.Count - 1].endWidth = newWidth;
            lineWidths[lineWidths.Count - 1] = newWidth;
        }
    }

    public void Undo()
    {
        if (lines.Count > 0)
        {
            Destroy(lines[lines.Count - 1].gameObject);
            lines.RemoveAt(lines.Count - 1);
            lineColors.RemoveAt(lineColors.Count - 1);
            lineWidths.RemoveAt(lineWidths.Count - 1);
        }
    }

    public void ClearAll()
    {
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }
        lines.Clear();
        lineColors.Clear();
        lineWidths.Clear();
    }

    

    void UpdateCollider()
    {
        // EdgeCollider2D'yi temizle
        edgeCollider.points = new Vector2[0];

        // Her bir çizgi noktasý için bir collider noktasý ekle
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 position = lineRenderer.GetPosition(i);
            Vector2 point = new Vector2(position.x, position.y);
            edgeCollider.points = (Vector2[])edgeCollider.points.Append(point);
        }
    }
}