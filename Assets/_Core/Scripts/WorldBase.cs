using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*Vector3 oldScale = transform.localScale;
        float percentage = 0.03f;
        float time = 6f;

        transform.localScale = new Vector3(oldScale.x * (1 - percentage), oldScale.y * (1 - percentage), oldScale.z * (1 - percentage));

        transform.DOScaleX(oldScale.x * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOScaleY(oldScale.y * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOScaleZ(oldScale.z * (1 + percentage), time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}