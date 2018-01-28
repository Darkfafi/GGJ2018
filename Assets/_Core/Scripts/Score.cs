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
    [SerializeField]
    private Canvas _canvas = null;
    [SerializeField]
    private GameObject _FloatText = null;

    private Vector2 _uiOffset;

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
	
	


    public void AddScore(float _scoreParam, Vector3 _scoreUISpawnLocation = new Vector3())
    {
        /*_scoreTarget += _scoreParam;
        _rect.DOComplete();
        _rect.DOPunchScale(Vector3.one * 0.1f, 0.75f, 10, 1);*/

        if (_scoreUISpawnLocation != null)
        {
            RectTransform _canvasRect = _canvas.GetComponent<RectTransform>();

            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_scoreUISpawnLocation);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ((ViewportPosition.x * _canvasRect.sizeDelta.x) - (_canvasRect.sizeDelta.x * 0.5f)),
                ((ViewportPosition.y * _canvasRect.sizeDelta.y) - (_canvasRect.sizeDelta.y * 0.5f))
            );

            //now you can set the position of the ui element
            //UI_Element.anchoredPosition = WorldObject_ScreenPosition;

            //Vector2 _screenLoc = Camera.main.WorldToViewportPoint(_scoreUISpawnLocation);
            GameObject go = GameObject.Instantiate(_FloatText);
            go.transform.SetParent(_canvas.transform, false);


            Text _text = go.GetComponent<Text>();
            if (_scoreParam < 0)
            {
                _text.text = "" + _scoreParam.ToString();
            }
            else
            {
                _text.text = "+" + _scoreParam.ToString();
            }


            RectTransform _goRect = go.GetComponent<RectTransform>();
            _goRect.anchoredPosition = WorldObject_ScreenPosition;

            Sequence tweenSequence = DOTween.Sequence();

            _goRect.localScale = Vector3.zero;
            tweenSequence.Append(_goRect.DOMoveY(_goRect.transform.position.y + 40f, 0.2f).SetEase(Ease.OutSine));
            tweenSequence.Join(_goRect.DOScale(Vector3.one, 0.2f));
            tweenSequence.Append(_goRect.DOPunchScale(Vector3.one * 0.5f, 0.2f, 7, 0.4f));
            float r = (float)Random.Range(0, 100) / 1000f;
            print(r); 
            tweenSequence.AppendInterval(0.2f + r);
            tweenSequence.Append(_goRect.DOMove(_rect.transform.position, 0.75f).SetEase(Ease.InCubic).OnComplete(() =>
            {
                Destroy(go);
                _scoreTarget += _scoreParam;
                _rect.DOComplete();
                _rect.DOPunchScale(Vector3.one * 0.1f, 0.75f, 10, 1);
                AudioSystem.Instance.PlayAudio("Score");

            }));
            tweenSequence.Play();
            /*_goRect.DOPunchScale(Vector3.one * 0.2f, _tweenDuration, 7, 0);
            _goRect.DOAnchorPos3D(_rect.anchoredPosition3D, _tweenDuration).OnComplete(() => { 
                Destroy(go); 
                _scoreTarget += _scoreParam;
                _rect.DOComplete();
                _rect.DOPunchScale(Vector3.one * 0.1f, 0.75f, 10, 1);
            }).SetEase(Ease.OutQuad);*/
        }

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
            if (Mathf.Abs(_scoreTarget - _score) < 1)
            {
                _score = _scoreTarget;
            }
            _scoreText.text = ((int)_score).ToString();

        }
    }
}
