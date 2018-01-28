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
		LAUNCHING,
        CLEAR
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
            if (_state == States.IN_ORBIT && nm != Modes.None)
            {
                SetSpeed(nm);
                DoMovementToLane(nm).OnComplete(() =>
                {
                    _mode = nm;
                });
            }
            else
            {
                _mode = nm;
            }
            if (_state == States.CLEAR && nm == Modes.None)
            {
                float desiredHeight = 40;
                
                Visual.DOLocalMoveY(desiredHeight, 10).OnComplete(()=> 
                {
                    Destroy(gameObject);
                });
            }
        }
    }

    public States State { get { return _state; } }

    [SerializeField]
    private Modes _mode = Modes.MEO;

    private States _state = States.IN_ORBIT;

    protected void Awake()
    {
        mode = _mode;
        DoMovementToLane(mode);
        currentCircle = gameObject.AddComponent<DrawCircle>();
        SetLine(mode);
        SetSpeed(mode);
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
        Visual.DOComplete();
        float desiredHeight = GameGlobals.GetHeightFor(mode);
        if (visual.transform.localPosition.y < desiredHeight)
        {
            AudioSystem.Instance.PlayAudio("SwooshLow");
        }
        else
        {
            AudioSystem.Instance.PlayAudio("SwooshHigh");
        }

        return Visual.DOLocalMoveY(desiredHeight, switchLaneDuration);
    }

    public void SetReleased()
    {
        if (_state != States.IN_ORBIT) { return; }
        _state = States.CLEAR;
        mode = Modes.None;
    }

    public void SetLaunchState(bool launchState)
    {
        _state = (launchState) ? States.LAUNCHING : States.IN_ORBIT;
        visual.Killable = (_state == States.IN_ORBIT);
    }

    private void SetLine(Modes mode)
    {
        if (mode == Modes.None || currentCircle == null) { return; }
        currentCircle.SetRadius(GameGlobals.GetHeightFor(mode));
        Color c = GameGlobals.GetColorFor(mode);
        c.a = 0.25f;
        currentCircle.SetLineColor(c, 0.15f);
    }

    private void SetSpeed(Modes mode)
    {
        Vector3 or = orbitRotation;
        or.z = GameGlobals.GetSpeedFor(mode);
        orbitRotation = or;
    }
}
