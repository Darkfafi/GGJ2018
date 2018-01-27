using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 oldScale = transform.localScale;
        float percentage = 0.03f;
        float time = 6f;

        transform.localScale = new Vector3(oldScale.x * (1 - percentage), oldScale.y * (1 - percentage), oldScale.z * (1 - percentage));

        transform.DOScaleX(oldScale.x * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOScaleY(oldScale.y * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOScaleZ(oldScale.z * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        /*
        tweenSequenceX.Append();

        tweenSequenceX.Append(transform.DOScaleX(transform.localScale.x * 1.1f, 1f));
        tweenSequenceX.Join(transform.DOScaleY(transform.localScale.y * 0.9f, 1f));
        tweenSequenceX.SetDelay(1f);
        tweenSequenceX.Append(transform.DOScaleX(transform.localScale.x * 0.9f, 1f));
        tweenSequenceX.Join(transform.DOScaleY(transform.localScale.x * 1.1f, 1f));
        tweenSequenceX.SetLoops(-1, LoopType.Yoyo);*/


        //transform.DOScaleX(transform.localScale.x * 1.1f, 3f).SetLoops(-1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
