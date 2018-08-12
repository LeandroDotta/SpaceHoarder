using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIBar : MonoBehaviour {

	Image bar;

	void Start()
	{
		bar = this.gameObject.GetComponent<Image>();
	}
		
	/*
	//Assim que haver variáveis de bagunça, descomentar esse bloco
	public void UpdateMessBarr(float messLevel)
	{
		bar.fillAmount = ((messLevel * 1.0f) / (100 * 1.0f)); //tlvz messlevel tenha que ser subtraído ou dividido ao invés de multiplicado..
		ChangeBarColor ();
	}
	*/

	public void ChangeBarColor()
	{
		if (bar.fillAmount < 0.30f)
		{
			bar.color = new Color32 (255, 50, 0, 255);
		}
		else if (bar.fillAmount < 0.55f) 
		{
			bar.color = new Color32 (245, 207, 0, 255);
		}
		else if(bar.fillAmount > 0.56f) 
		{
			bar.color = new Color32 (0, 245, 63, 255);
		}
		Debug.Log ("cor atualizada");
	}
}
