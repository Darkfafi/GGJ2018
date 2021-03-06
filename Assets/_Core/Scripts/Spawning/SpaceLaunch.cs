﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceLaunch : MonoBehaviour
{
	public Transform warningSign;

    [SerializeField]
    private Transform center;

    private Dictionary<ILaunchable, float> launchableProgressionMap = new Dictionary<ILaunchable, float>();



    public void SendToPointInSpace(ILaunchable launchable, Vector3 locationDirection, Modes lane, float duration)
    {
        // idea, create transform at location and remove later (for orbit follow purposes)
        float h = (lane == Modes.None) ? Random.Range(GameGlobals.GetHeightFor(Modes.HEO), GameGlobals.GetHeightFor(Modes.HEO) + 2) : GameGlobals.GetHeightFor(lane);
        launchableProgressionMap.Add(launchable, 0);
        Vector3 target = center.position + locationDirection.normalized * h;
		Debug.Log("warning sign");
		Transform warning = Instantiate(warningSign, target, Quaternion.identity) as Transform;

        Vector3 startPos = transform.position;
        launchable.SetLaunchState(true);
        DOTween.To(
          () => launchableProgressionMap[launchable]
        , x => SetValueOLaunchable(startPos, launchable, x, target, h), 
        
        1f, duration).OnComplete(
            () =>
            {
                launchableProgressionMap.Remove(launchable);
                launchable.SetLaunchState(false);
            }    
        ).SetEase(Ease.InOutQuad);
    }

    private void SetValueOLaunchable(Vector3 startPos, ILaunchable l, float value, Vector3 target, float height)
    {
        launchableProgressionMap[l] = value;
        l.Visual.transform.position = CurveCalculations.GetCurvePoint(startPos, target, center.transform.position, height, value).FinalPoint;
    }
}
