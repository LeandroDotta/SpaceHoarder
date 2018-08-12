using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Grab : MonoBehaviour
{    

    [SerializeField] private Collider _collider;    

    private void Start()
    {
//        _collider.enabled = false;        
        //if (_collider == null)
        //{
        //    _collider = GetComponentInChildren<Collider>();
        //}
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

    private void OnTriggerStay(Collider other)
    {
        IGrabable grabable = other.GetComponent<IGrabable>();

        if (grabable != null)
        {
            Debug.Log("interface " + other.name);
        }

        if (other.CompareTag("Debri"))
        {
            Debug.Log(other.name);
            //Rigidbody rb = other.GetComponentInParent<Rigidbody>();
            //if (rb != null)
            //    rb.AddForce(transform.forward * Force, ForceMode.Impulse);
        }
    }
}