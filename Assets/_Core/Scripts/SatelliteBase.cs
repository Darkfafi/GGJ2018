using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SatelliteBase : MonoBehaviour {

	public Transform visual;

	public Vector3 orbitRotation;

	public float switchLaneDuration = 0.5f;

	public enum States
	{
		DESTROYED,
        IN_ORBIT,
		LAUNCHED
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

    private Modes _mode;

    private States _state = States.IN_ORBIT;

    protected void Awake()
    {
        DoMovementToLane(mode);
    }

	protected void FixedUpdate () {

		transform.Rotate(orbitRotation);
		switch (_state)
		{
			case States.LAUNCHED:

				break;

			case States.DESTROYED:

				break;

			default:

				break;

		}
	}

    private Tween DoMovementToLane(Modes mode)
    {
        if (_state != States.IN_ORBIT) { return null; }
        float desiredHeight = GameGlobals.GetHeightFor(mode);
        return visual.DOLocalMoveY(desiredHeight, switchLaneDuration);
    }
}
