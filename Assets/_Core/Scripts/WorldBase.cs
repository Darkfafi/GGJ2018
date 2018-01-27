using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sequence tweenSequenceX = DOTween.Sequence();
        Vector3 oldScale = transform.localScale;
        transform.localScale = oldScale * 0.9f;

        tweenSequenceX.Append(transform.DOScaleX(transform.localScale.x * 1.1f, 1f));
        tweenSequenceX.Join(transform.DOScaleY(transform.localScale.y * 0.9f, 1f));
        tweenSequenceX.SetDelay(1f);
        tweenSequenceX.Append(transform.DOScaleX(transform.localScale.x * 0.9f, 1f));
        tweenSequenceX.Join(transform.DOScaleY(transform.localScale.x * 1.1f, 1f));
        tweenSequenceX.SetLoops(-1, LoopType.Yoyo);


        //transform.DOScaleX(transform.localScale.x * 1.1f, 3f).SetLoops(-1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
