using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILaunchable
{
    Transform Visual { get; }
    void SetLaunchState(bool launchState);
}
