using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public static Health singleton;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Transform center;

	int health = 120;
    private Color c;

    private float sinV = 0; 

	void Awake()
	{
		if (singleton == null)
		{
			singleton = this;
		}
		else
		{
			Debug.LogError("singleton of health already exists");
		}
        c = healthText.color;
        healthText.text = health + "%";
        healthText.transform.DORotate(new Vector3(0, 0, 8), 2.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    protected void Update()
    {
        sinV += Time.deltaTime * 0.45f;

        float s = (center.localScale.x/10) + Mathf.Abs(Mathf.Sin(sinV) * 0.2f);
        healthText.transform.localScale = new Vector3(s, s, s);
    }

	public void DoDamage(int amount)
	{
		health = health - amount;

		//GetComponent<Image>().fillAmount = health;

        if (health <= 0)
		{
            health = 0;
            FindObjectOfType<GameManager>().EndGame();
            healthText.gameObject.SetActive(false);
        }

        healthText.DOComplete(true);
        healthText.DOText(health + "%", 1f, true, ScrambleMode.Numerals);
        healthText.DOColor(Color.red, 0.2f);
        healthText.transform.DOShakeRotation(1.1f, 10).OnComplete(()=> { healthText.DOColor(c, 0.5f); });
    }

}
