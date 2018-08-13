using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BarType
{
	MessBar,
	Incinerator,
	Compactor
};


public class GUIBar : MonoBehaviour {

	Image bar;
	BarType bartype;


    private int _maxRawValue = 1000;

    public int MaxRawValue
    {
        get { return _maxRawValue; }
        set { _maxRawValue = value; }
    }


    void Start()
	{
		bar = this.gameObject.GetComponent<Image>();
        bar.fillAmount = 0;
		if (bartype == BarType.Incinerator)
		{
			
		}
	}
		

	public void UpdateMess(float value)
	{
        //Assim que haver variáveis de bagunça, descomentar esse bloco
        //Debug.Log("value: " + value);
        //Debug.Log("%: " + value / _maxRawValue);
        bar.fillAmount = (float)value / (float)_maxRawValue; //tlvz messlevel tenha que ser subtraído ou dividido ao invés de multiplicado..
		ChangeBarColor ();

	}




	public void UpdateCooldownBar(float cooldown)
	{
		bar.fillAmount = ((cooldown * 1.0f) / (100 * 1.0f)); //tlvz messlevel tenha que ser subtraído ou dividido ao invés de multiplicado..
	}

	public void ChangeBarColor()
	{
		if (bar.fillAmount < 0.30f)
		{
            bar.color = new Color32(0, 245, 63, 255);
        }
		else if (bar.fillAmount < 0.55f) 
		{
			bar.color = new Color32 (245, 207, 0, 255);
		}
		else if(bar.fillAmount > 0.56f) 
		{
            bar.color = new Color32(255, 50, 0, 255);
		}		
	}
}
