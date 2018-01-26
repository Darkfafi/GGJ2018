using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour {

	
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOMoveX(1, 1.2f).SetEase(Ease.OutBack).OnComplete(()=> { GetComponent<SpriteRenderer>().DOColor(Color.red, 1).SetEase(Ease.OutBounce); });
        }
    }

}
