using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image bar;
    [SerializeField] private Gradient gradient;



    public bool IsCoolingdown { get; private set; }

	private void Start() 
	{
		canvas.gameObject.SetActive(false);
        // bar.color = gradient.colorKeys[0].color;
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

        float timer = 0;

        do
        {
            yield return new WaitForEndOfFrame();

            timer += Time.deltaTime / cooldown;
            bar.color = gradient.Evaluate(timer);
            bar.fillAmount = timer;
        } while (timer < 1);

		canvas.gameObject.SetActive(false);
		IsCoolingdown = false;
    }
}
