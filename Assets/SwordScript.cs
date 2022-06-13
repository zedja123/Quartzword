using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static SwordScript instance;
    public Transform destination;
    public Rigidbody rb;
    [SerializeField] private float velocity;
    private Vector3 movement;
    public Animator anim;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim.enabled = false;
    }

    private void Update()
    {
        MoveToDestination();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
    }

    void MoveToDestination()
    {
        float distance = Vector3.Distance(transform.position, destination.position);
        if(Mathf.Abs(distance) > 0.3f)
        {
            transform.LookAt(destination);
            transform.SetParent(null);
            //transform.rotation = Quaternion.Euler(Vector3.zero);
            Vector3 direction = destination.position - transform.position;
            direction = direction.normalized;
            movement = direction * velocity;
        }
        else
        {
            movement = Vector3.zero;
            if (destination == PlayerController.instance.SwordLocation)
            {
                transform.SetParent(destination);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
                
            
            
        }
    }

    public void ChangeDestination(Transform _newDestination)
    {
        transform.SetParent(null);
        destination = _newDestination;
    }
}
