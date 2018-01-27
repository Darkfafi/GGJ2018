using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrawCircle : MonoBehaviour
{
    [Header("Options")]
    [SerializeField]
    private Color color;

    [SerializeField]
    private float radius = 5;

    [SerializeField]
    private float width = 0.20f;

    [SerializeField]
    private float resolution = 0.25f;

    private int size;
    private LineRenderer lineRenderer;

    public Color GetColor()
    {
        return lineRenderer.startColor;
    }

    public float GetRadius()
    {
        return radius;
    }

    public void SetLineColor(Color newColor, float duration)
    {
        Color2 c1 = new Color2(lineRenderer.startColor, lineRenderer.endColor);
        Color2 c2 = new Color2(newColor, newColor);
        lineRenderer.DOColor(c1, c2, duration);
    }

    public void SetRadius(float rad)
    {
        radius = rad;
    }

    void Awake()
    {
        float sizeValue = (2.0f * Mathf.PI) / resolution;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startWidth = width; //thickness of line
        lineRenderer.endWidth = width;
        lineRenderer.loop = true;
        lineRenderer.positionCount = size;
        SetLineColor(color, 0.2f);
     }

    void Update()
    {
        float circleAngle = (2 * Mathf.PI) / size;
        int i = 0;
        for(float v = 0; v <= 2 * Mathf.PI; v+= circleAngle)
        {
            Vector3 vec = new Vector3(Mathf.Cos(v), Mathf.Sin(v));
            vec = vec.normalized * radius;

            lineRenderer.SetPosition(i, vec + transform.position);
            i++;
        }
    }
}
