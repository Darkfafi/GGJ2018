using UnityEngine;
using System.Collections;

/// <summary>
/// This class handles the effect show when a powerup is grabbed
/// </summary>
public class PowerupGrab : MonoBehaviour
{
    private Curve _targetCurve;
    private Vector3 _fromPosition;
    private Vector2d toPosition;

    private float _time = 0.0f;
    private float _duration = 1f;

    private Vector3 _initDirection;
    private float _initAmplitude = 10f;

    private float _trailTime;

    /// <summary>
    /// Initialize this class
    /// </summary>
    /// <param name="targetCurve">The curve we want to tween to</param>
    /// <param name="duration">The duration in seconds</param>
    /// <param name="angle">The angle of the initial force</param>
    /// <param name="trailTime">The duration in seconds of the trail to expire</param>
    public void Init(Curve targetCurve, float duration, float angle, float trailTime)
	{
        _targetCurve = targetCurve;
        _trailTime = trailTime;

		// Add a random angle
        angle += Mathf.Deg2Rad * Random.Range(-30f, 30f);

		// Calculate the initial direction it needs to fly to
        _initDirection = new Vector3(Mathf.Cos(angle) * _initAmplitude, -Mathf.Sin(angle) * _initAmplitude, 0);

		// Get the old position
		_fromPosition = transform.localPosition;

		// Start the tween
        StartCoroutine(Tween());
    }

	private IEnumerator Tween ()
	{
		// Only update the new position if the curve is alive
        if (_targetCurve.alive)
		{
			 toPosition = _targetCurve.position;
		}
		// if the time is not yet elapsed, tween that shit
        if (_time < _duration + _trailTime)
        {
            //Add the deltaTime to the time variable
            _time += Time.deltaTime;

			// Calculate the current time in the tween
            float t = _time / _duration;

			// Add the init direction to the from and multiply it by the time so it decreases over time
            Vector3 vOld = _fromPosition + _initDirection * t;

			// Get the local position of the target
            Vector3 localTarget = GameController.LocalWorldPos(toPosition);

			// Subtract the distance of the current position and the target and multiply it by reversed t so it increases over time
            Vector3 vNew = localTarget - (localTarget - transform.localPosition) * (1f - t);

			// Lerp that shit
			transform.localPosition = Vector3.Slerp(vOld, vNew, t);

			// Wait one frame
            yield return 0;

			// Start it again
			StartCoroutine(Tween());
        }
		// Else destroy it
		else
		{
			Destroy(gameObject);
		}
    }
}
