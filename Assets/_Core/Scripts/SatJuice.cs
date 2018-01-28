using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SatJuice : MonoBehaviour {
    [SerializeField]
    private Transform _visual;

	// Use this for initialization
	void Start () {
        Sequence tweenSequence = DOTween.Sequence();
        tweenSequence.Append(_visual.DOLocalRotate(new Vector3(0, 0, 8f), 5f).SetEase(Ease.InOutSine));
        tweenSequence.SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
