using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SatelliteBase : MonoBehaviour, ILaunchable
{
    public Transform Visual { get { return visual.transform; } }

    [SerializeField]
	private SatVisual visual;

	public Vector3 orbitRotation;

	public float switchLaneDuration = 0.5f;
    private DrawCircle currentCircle;

	public enum States
	{
		DESTROYED,
        IN_ORBIT,
		LAUNCHING
	};

    public Modes mode
    {
        get
        {
            return _mode;
        }
        set
        {
            if (_mode == value) { return; }
            Modes nm = value;
            // Move to height only if in orbit
            SetLine(nm);
            if (_state == States.IN_ORBIT)
            {
                DoMovementToLane(nm).OnComplete(() =>
                {
                    _mode = nm;
                });
            }
            else
            {
                _mode = nm;
            }
        }
    }

    [SerializeField]
    private Modes _mode = Modes.MEO;

    private States _state = States.IN_ORBIT;

    protected void Awake()
    {
        mode = _mode;
        DoMovementToLane(mode);
        currentCircle = gameObject.AddComponent<DrawCircle>();
    }

    protected void FixedUpdate () {


		switch (_state)
		{
			case States.LAUNCHING:

				break;

			case States.DESTROYED:

				break;
            case States.IN_ORBIT:
                transform.Rotate(orbitRotation);
                break;
            default:

				break;

		}
	}

    private Tween DoMovementToLane(Modes mode)
    {
        if (_state != States.IN_ORBIT) { return null; }
        float desiredHeight = GameGlobals.GetHeightFor(mode);
        return Visual.DOLocalMoveY(desiredHeight, switchLaneDuration);
    }

    public void SetLaunchState(bool launchState)
    {
        _state = (launchState) ? States.LAUNCHING : States.IN_ORBIT;
        visual.Killable = (_state == States.IN_ORBIT);
    }

    private void SetLine(Modes mode)
    {
        currentCircle.SetRadius(GameGlobals.GetHeightFor(mode));
        Color c = GameGlobals.GetColorFor(mode);
        c.a = 0.25f;
        currentCircle.SetLineColor(c, 0.15f);
    }
}
