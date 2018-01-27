using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Score : MonoBehaviour {
    [SerializeField]
    private Text _scoreText = null;
    [SerializeField]
    private RectTransform _rect = null;

    private float _score = 0;
    private float _scoreTarget = 0;

    public static Score _instance;
    public static Score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Score>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Score");
                    _instance = container.AddComponent<Score>();
                }
            }

            return _instance;
        }
    }
	// Use this for initialization
	void Start () {
		
	}

    public void AddScore(float _scoreParam)
    {
        _scoreTarget += _scoreParam;
        _rect.DOComplete();
        _rect.DOPunchScale(Vector3.one * 0.1f, 0.75f, 10, 1);
        //_scoreText.text = Mathf.Lerp(_score, _score + _scoreParam, 10f).ToString();
        //_score += _scoreParam;
        //_scoreText.DOText(_score.ToString(),1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (_scoreTarget != _score)
        {
            _score = Mathf.Lerp(_score, _scoreTarget, Time.deltaTime * 2.4f);
            //_score = Mathf.Ceil(_score);
            print(_score);
            if (Mathf.Abs(_scoreTarget - _score) < 1)
            {
                _score = _scoreTarget;
            }
            _scoreText.text = ((int)_score).ToString();

        }
    }
}
