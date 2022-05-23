using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objectToFollow;
    [SerializeField] public  Animator anim;
    [SerializeField] public NavMeshAgent nma;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nma.destination = objectToFollow.position;
        Movement();
    }

    public void Movement()
    {
        anim.SetFloat("Speed", nma.velocity.magnitude);
    }
}
