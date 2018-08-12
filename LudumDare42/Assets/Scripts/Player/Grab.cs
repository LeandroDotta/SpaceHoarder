using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Grab : MonoBehaviour
{    
    [SerializeField] private Collider _collider;
    private IGrabable[] _itensGrabbed;
    private bool _isFire1Pressed = false;    

    private void Start()
    {
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {            
            _isFire1Pressed = true;
            StartCoroutine(GrabCoroutine());            
        }
    }

    private IEnumerator GrabCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _isFire1Pressed = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (!_isFire1Pressed) { return; }
        
        IGrabable grabable = other.GetComponentInParent<IGrabable>();

        if (grabable != null)
        {
            grabable.GetTransform().SetParent(this.transform);
            Rigidbody rb = grabable.GetTransform().GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IGrabable grabable = other.GetComponentInParent<IGrabable>();
        if (grabable != null)
        {            
            grabable.SetHighlighted(true);            
        }
        else
        {
            Debug.Log("not an IGrabable");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        IGrabable grabable = other.GetComponentInParent<IGrabable>();
        if (grabable != null)
        {
            grabable.SetHighlighted(false);            
        }
    }
}