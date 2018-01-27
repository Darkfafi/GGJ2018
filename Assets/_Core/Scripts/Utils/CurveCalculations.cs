using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurveCalculations
{

	public static CurveTravelInfo GetCurvePoint(Vector3 a, Vector3 b, Vector3 c, float height, float progress)
    {;
        // Center to positions
        Vector3 cToA = a - c;
        Vector3 cToB = b - c;

        float rad1 = Mathf.Atan2(cToA.y, cToA.x);
        float rad2 = Mathf.Atan2(cToB.y, cToB.x);
        float rad1Z = Mathf.Atan2(cToA.z, cToA.x);
        float rad2Z = Mathf.Atan2(cToB.z, cToB.x);

        float angleResult = Mathf.LerpAngle(rad1 * Mathf.Rad2Deg, rad2 * Mathf.Rad2Deg, 0.5f) * Mathf.Deg2Rad;
        float angleResultZ = Mathf.LerpAngle(rad1Z * Mathf.Rad2Deg, rad2Z * Mathf.Rad2Deg, 0.5f) * Mathf.Deg2Rad;

        Vector3 newVec = new Vector3(Mathf.Cos(angleResult), Mathf.Sin(angleResult), Mathf.Sin(angleResultZ)).normalized;

        // Curve Calculation
        Vector3 aUp = newVec * height;
        Vector3 bUp = newVec * height;

        // -- Section 1

        Vector3 p1 = a + aUp * progress;
        Vector3 p2 = b + bUp - (bUp * progress);
        Vector3 p3 = a + aUp + ((b + bUp) - (a + aUp)) * progress;

        // -- Section 2

        Vector3 p4 = p1 + (p3 - p1) * progress;
        Vector3 p5 = p2 + (p3 - p2) - (p3 - p2) * progress;

        // -- Last Section

        Vector3 finalPoint = p4 + (p5 - p4) * progress;


        return new CurveTravelInfo(p1, p2, p3, p4, p5, finalPoint);
    }
}


public struct CurveTravelInfo
{
    public Vector3 P1 { get; private set; }
    public Vector3 P2 { get; private set; }
    public Vector3 P3 { get; private set; }
    public Vector3 P4 { get; private set; }
    public Vector3 P5 { get; private set; }
    public Vector3 FinalPoint { get; private set; }

    public CurveTravelInfo(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Vector3 p5, Vector3 finalPoint)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
        P4 = p4;
        P5 = p5;

        FinalPoint = finalPoint;
    }
}