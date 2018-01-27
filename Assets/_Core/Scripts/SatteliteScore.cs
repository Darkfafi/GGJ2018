using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatteliteScore : MonoBehaviour {
    private float _scoreToAdd = 100;
    private float _timeToNextScore = 3f;
    private float _currentTime = 0f;

    [SerializeField]
    private SatVisual _satVisual = null;

	// Use this for initialization
	void Start () {
        _currentTime = Random.Range(0f, _timeToNextScore);
	}
	
	// Update is called once per frame
	void Update () {
        return;
        _currentTime += Time.deltaTime;
        if (_currentTime >= _timeToNextScore)
        {
            Score.Instance.AddScore(_scoreToAdd, _satVisual.gameObject.transform.position);
            _currentTime = 0;
        }
    }
}
