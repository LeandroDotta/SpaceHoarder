using UnityEngine;
using UnityEngine.UI;

public class GUIBar : MonoBehaviour
{
	Image _bar;

	void Start()
	{
		_bar = this.gameObject.GetComponent<Image>();
	}	
    
	public void UpdateMessBar(float messLevel)
	{
		_bar.fillAmount = messLevel / 100f;	    
		UpdateBarColor ();
	}

	private void UpdateBarColor()
	{
		if (_bar.fillAmount < 0.30f)
		{
			_bar.color = new Color32 (255, 50, 0, 255);
		}
		else if (_bar.fillAmount < 0.55f) 
		{
			_bar.color = new Color32 (245, 207, 0, 255);
		}
		else if(_bar.fillAmount > 0.56f) 
		{
			_bar.color = new Color32 (0, 245, 63, 255);
		}		
	}
}
