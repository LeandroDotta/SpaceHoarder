using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Grab : MonoBehaviour
{    
    [SerializeField] private Collider _collider;    

    private void Start()
    {
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
    }

    //private void Update()
    //{
    //    if (CrossPlatformInputManager.GetButton("Fire1"))
    //    {
    //        Apply();
    //    }

    //    if (CooldownCounter > 0)
    //    {
    //        CooldownCounter -= Time.deltaTime;

    //        if (CooldownCounter < 0)
    //            CooldownCounter = 0;
    //    }
    //}
    //public void Apply()
    //{
    //    if (CooldownCounter > 0)
    //        return;

    //    _collider.enabled = true;
    //    StartCoroutine("DisableCoroutine");
    //    CooldownCounter = Cooldown;
    //}

    //private IEnumerator DisableCoroutine()
    //{
    //    yield return new WaitForSeconds(0.1f);

    //    _collider.enabled = false;
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    IGrabable grabable = other.GetComponent<IGrabable>();

    //    if (grabable != null)
    //    {
    //        Debug.Log("interface " + other.name);
    //    }

    //    if (other.CompareTag("Debri"))
    //    {
    //        Debri debri = other.GetComponent<Debri>();
            
    //        //Rigidbody rb = other.GetComponentInParent<Rigidbody>();
    //        //if (rb != null)
    //        //    rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        IGrabable grabable = other.GetComponentInParent<IGrabable>();
        if (grabable != null)
        {            
            grabable.SetHighlighted(true);
            //Debug.Log("interface " + other.name);
        }
        else
        {
            Debug.Log("not an IGrabable");
        }

        //if (other.CompareTag("Debri"))
        //{
        //    Debri debri = other.GetComponent<Debri>();
        //    debri.SetHighlighted(true);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        IGrabable grabable = other.GetComponentInParent<IGrabable>();
        if (other.CompareTag("Debri"))
        {
            grabable.SetHighlighted(false);            
        }
    }
}