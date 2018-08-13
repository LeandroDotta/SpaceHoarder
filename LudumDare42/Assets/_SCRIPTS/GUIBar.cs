using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//public enum BarType
//{
//	MessBar,
//	Incinerator,
//	Compactor
//};

public class GUIBar : MonoBehaviour
{

	Image _bar;
	//BarType bartype;

    private int _maxRawValue = 1000;

    public int MaxRawValue
    {
        get { return _maxRawValue; }
        set { _maxRawValue = value; }
    }

    void Awake()
	{
		_bar = this.gameObject.GetComponent<Image>();

	    Assert.IsNotNull(_bar);
        SetBarToZero();
    }

	public void UpdateMess(float value)
	{
        if (value > 0)
        {
            _bar.fillAmount = (float)value / (float)_maxRawValue;
            ChangeBarColor();
        }
        else
        {
            _bar.fillAmount = 0;
        }
	}

    public void SetBarToZero()
    {
        _bar.fillAmount = 0;
    }

	public void UpdateCooldownBar(float cooldown)
	{        
        _bar.fillAmount = ((cooldown * 1.0f) / (100 * 1.0f));
	}

	public void ChangeBarColor()
	{
		if (_bar.fillAmount < 0.30f)
		{
            _bar.color = new Color32(0, 245, 63, 255);
        }
		else if (_bar.fillAmount < 0.55f) 
		{
			_bar.color = new Color32 (245, 207, 0, 255);
		}
		else if(_bar.fillAmount > 0.56f) 
		{
            _bar.color = new Color32(255, 50, 0, 255);
		}		
	}
}
