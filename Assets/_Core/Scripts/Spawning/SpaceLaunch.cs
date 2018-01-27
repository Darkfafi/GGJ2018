using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceLaunch : MonoBehaviour {

    [SerializeField]
    private Transform A;

    [SerializeField]
    private Transform B;

    [SerializeField]
    private Transform Center;

    [SerializeField, Range(3, 50)]
    private float curveHeight;

    [SerializeField, Range(0, 1)]
    private float progress = 0.5f;


	protected void Update()
    {
        //Debug.DrawLine(aPos, aLU);
    }


    protected void OnDrawGizmos()
    {
        CurveTravelInfo curveTravel = CurveCalculations.GetCurvePoint(A.transform.position, B.transform.position, Center.transform.position, curveHeight, progress);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(curveTravel.P1, 0.15f);
        Gizmos.DrawWireSphere(curveTravel.P2, 0.15f);
        Gizmos.DrawWireSphere(curveTravel.P3, 0.15f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(curveTravel.P4, 0.15f);
        Gizmos.DrawWireSphere(curveTravel.P5, 0.15f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(curveTravel.FinalPoint, 0.2f);
    }





























    /*
    // Angle between sections
    float angleToA = Vector3.Angle(Vector3.up, aPos - centerPos);
    float angleToB = Vector3.Angle(Vector3.up, bPos - centerPos);
    float angle = Vector3.Dot(cToA, cToB) / (cToA.magnitude * cToB.magnitude) * Mathf.Rad2Deg;

    float angleToC1 = Mathf.LerpAngle(angleToA, angleToB, 0.5f);
    Vector3 cToC = centerPos + ((aPos - centerPos) + (bPos - centerPos)).normalized; //Vector3.Lerp((aPos - centerPos).normalized, (bPos - centerPos).normalized, thing);

    //Debug.Log(angle);

    Gizmos.color = Color.blue;
    Gizmos.DrawLine(centerPos, cToA);
    Gizmos.DrawLine(centerPos, cToB);

    Gizmos.color = Color.red;
    Gizmos.DrawLine(centerPos, cToC);
    */
}
