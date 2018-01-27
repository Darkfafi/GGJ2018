using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour {

	
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.DOMoveX(1, 1.2f).SetEase(Ease.OutBack).OnComplete(()=> { GetComponent<SpriteRenderer>().DOColor(Color.red, 1).SetEase(Ease.OutBounce); });


            transform.DORotate(new Vector3(0, 0, 45), 1.2f).SetEase(Ease.OutBounce).OnComplete(
                ()=> 
                {
                    transform.DOScale(10, 1).SetEase(Ease.OutBack).OnComplete(() => { transform.DOShakePosition(1); });
                }
            );
        }
    }

}
