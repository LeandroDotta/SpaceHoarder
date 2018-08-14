using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image bar;

    public bool IsCoolingdown { get; private set; }

	private void Start() 
	{
		canvas.gameObject.SetActive(false);	
	}

    public void Show(float cooldown)
    {
		StopCoroutine("CooldownCoroutine");
		StartCoroutine("CooldownCoroutine", cooldown);
    }

    private IEnumerator CooldownCoroutine(float cooldown)
    {
		bar.fillAmount = 0;
		
		canvas.gameObject.SetActive(true);
		IsCoolingdown = true;

        do
        {
            yield return new WaitForEndOfFrame();

            bar.fillAmount += Time.deltaTime / cooldown;
        } while (bar.fillAmount < 1);

		canvas.gameObject.SetActive(false);
		IsCoolingdown = false;
    }
}
