using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PulseEffect : MonoBehaviour {

    [SerializeField]
    private float pulseSpeed = 5;

    private MeshRenderer mr;
    private float a = 0;
    private int tcid = Shader.PropertyToID("_TintColor");

    protected void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    protected void Update()
    {
        Color c = mr.material.GetColor(tcid);
        float nca = Mathf.Abs(Mathf.Sin(a));
        nca *= 0.25f;
        c.a = nca;
        mr.material.SetColor(tcid, c);
        a += Time.deltaTime * pulseSpeed;
    }
}
