using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Incinerator : MonoBehaviour {

	public float CooldownCounter { get; private set; }	
	public CooldownBar cooldown;

	[Header("Effects")]
	public AudioClip SfxDestroy;
    public GameObject IncineratorDestruction;

    private void Awake()
    {
        Assert.IsNotNull(cooldown);
        Assert.IsNotNull(SfxDestroy);
        Assert.IsNotNull(IncineratorDestruction);
    }

	void Update ()
	{
		if(CooldownCounter > 0)
		{
			CooldownCounter -= Time.deltaTime;
			if(CooldownCounter < 0) CooldownCounter = 0;
		}
	}

	private void OnTriggerStay(Collider other) 
	{
		if (CooldownCounter > 0) 
			return;

        IGrabable grabable = other.GetComponentInParent<IGrabable>();

        if (grabable != null)
        {
		    Debri debri = other.GetComponentInParent<Debri>();
			if(debri.IsGrabbed) { return; }
            
            GameObject particleGO = Instantiate(IncineratorDestruction, debri.transform.position, Quaternion.identity) as GameObject;
            Destroy(particleGO, 1f);

            CooldownCounter = debri.IncineratorCooldown;		    
			cooldown.Show(debri.IncineratorCooldown); // Show cooldown UI
            GameManager.Instance.AddScore(debri.Score);
            GameManager.Instance.DecrementMessValue(grabable.GetMassValue());

            // TODO play with random pitch - and maybe with a particle animation            
			SoundEffects.Instance.Play(SfxDestroy, true);
            
            Destroy(debri.gameObject);
        }
	}
}
