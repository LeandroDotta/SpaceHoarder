using System;
using TMPro;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Assertions;
   
public class Player : MonoBehaviour
{        
    private Transform _cam;                  // A reference to the main camera in the scenes transform
    private Vector3 _camForward;             // The current forward direction of the camera
    private Vector3 _move;
    private Rigidbody _rigidbody;
    private Vector3 _offsetToGrab = new Vector3(0f, 2f, 0f);    
    [Range(0, 10f)]
    [SerializeField] private float _grabReach = 3f;
    [Tooltip("velocity of the player")]
    [Range(0, 100f)]
    [SerializeField] private float _velocity = 17f;

    private float h;
    private float v;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
    }

    private void Start()
    {        
        if (Camera.main != null)
        {
            _cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);         
        }
    }
    
    private void FixedUpdate()
    {
        // calculate move direction to pass to character
        if (_cam != null)
        {
            // calculate camera relative direction to move:
            _camForward = Vector3.Scale(_cam.forward, new Vector3(1, 0, 1)).normalized;
            _move = v * _camForward + h * _cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            _move = v * Vector3.forward + h * Vector3.right;
        }
#if !MOBILE_INPUT
        // walk speed multiplier
        // if (CrossPlatformInputManager.GetButton("Fire3")) { _move *= 1.2f; }
#endif

        Move(_move);        
    }

    private void Update() 
    {
        // read inputs
        h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        v = CrossPlatformInputManager.GetAxisRaw("Vertical");    
    }

    private void Move(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            _rigidbody.transform.forward = move;
        }

        move.x *= _velocity;
        move.y = _rigidbody.velocity.y;
        move.z *= _velocity;        
        _rigidbody.velocity = (move.normalized * _velocity);
    }

    private IGrabable Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + _offsetToGrab, transform.TransformDirection(Vector3.forward), out hit, _grabReach))                  
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("We hit " + hit.transform.name);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        return null;
    }
}

