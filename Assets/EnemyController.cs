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
    public float viewDistance = 10f;
    public float attackDistance = 2f;
    public GameObject patrollPoint1;
    public GameObject patrollPoint2;
    public Transform[] waypoints;
    private int waypointIndex;
    private float waypointDistance;
    public float nextAttackTime = 0;
    public float attackCooldown = 2;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public float attackRange;
    public float maxLife = 20;
    public float currentLife;

    void Start()
    {
        waypointIndex = 0;
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, objectToFollow.position);
        if(dist <= 10f)
        {  
            if (dist <= 3f)
            {
                if (Time.time >= nextAttackTime)
                {
                    Attack();
                    print("atacando");
                    nextAttackTime = Time.time + attackCooldown;
                }

            }
            else
            {
                MoveToPlayer();
            }
        }
        else
        {
            Patrol();
        }

        
    }

    public void MoveToPlayer()
    {
        nma.destination = objectToFollow.position;
    }
    public void Movement()
    {
        anim.SetFloat("Speed", nma.velocity.magnitude);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(AttackPointCalculator());
    }

    public void Patrol()
    {
        waypointDistance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(waypointDistance < 1f)
        {
            IncreaseIndex();
        }
        nma.destination = waypoints[waypointIndex].position;
        Movement();
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        print(currentLife);
        if(currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public IEnumerator AttackPointCalculator()
    {
        yield return new WaitForSeconds(1f);
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Hit on Player");
            player.GetComponent<PlayerController>().TakeDamage(3);
            print(PlayerController.instance.currentLife);
        }

    }
}
