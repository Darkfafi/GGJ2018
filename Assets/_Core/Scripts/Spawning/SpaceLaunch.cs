using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class SpaceLaunch : MonoBehaviour
{
    private ILaunchable currentLaunchable;


    public void SendToPointInSpace(ILaunchable launchable, Vector3 location)
    {
        // idea, create transform at location and remove later (for orbit follow purposes)
        currentLaunchable = launchable;
            
        launchable.SetLaunchState(true);
    }

    protected void Update()
    {

    }
}
