using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public bool chave1;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public static PlayerController instance;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject espada;
    public States currentState;


    private float z;
    [SerializeField] private float jumpPower;
    private bool canJump;
    private bool lookingLeft;
    private bool attacking;
    public bool canAttack;
    [SerializeField] public bool canMove;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        Inputs();
        Flip();
        Animations();
        AddRemoveSword();
        Attacking();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
        Movement();
        Jump();
        }

    }

    public enum States
    {
        Talking,
        Exploring,
        Pause
    }
    void Flip()
    {
        if (z > 0 && lookingLeft)
        {
            lookingLeft = !lookingLeft;
            Quaternion rotPlayer = transform.rotation;
            rotPlayer.y = 0;
            transform.rotation = rotPlayer;
        }
        else if (z < 0 && !lookingLeft)
        {
            lookingLeft = !lookingLeft;
            Quaternion rotPlayer = transform.rotation;
            rotPlayer.y = 180;
            transform.rotation = rotPlayer;
        }
    }

    void Inputs()
    {
        z = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            canJump = true;
        }
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            attacking = true;
        }
    }

    void Movement()
    {
        rb.velocity = new Vector3(0f , rb.velocity.y, z * speed);

    }

    void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpPower);
            anim.SetTrigger("Jump");
            canJump = false;
        }

    }

    bool OnGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    void Animations()
    {
        anim.SetFloat("Speed",Mathf.Abs(z));
        anim.SetBool("IsMoving", rb.velocity.z != 0);
        anim.SetBool("OnGround", OnGround());
        anim.SetBool("Attacking", attacking);
    }

    void AddRemoveSword()
    {
        if (canAttack)
        {
            espada.SetActive(true);
        }
        else
        {
            espada.SetActive(false);
        }
    }

    public void CanAttackChange()
    {
        canAttack = !canAttack;
    }

    public void CanMoveChange()
    {
        canMove = !canMove;
    }
    public void CanMoveFalse()
    {
        canMove = false;
    }
    public void CanMoveTrue()
    {
        canMove = true;
    }

    public void ChangeState(States _state)
    {
        currentState = _state;
        switch (currentState)
        {
            case States.Talking:
                canMove = false;
                break;

            case States.Exploring:
                canMove = true;
                break;

            case States.Pause:
                canMove = false;
                break;

        }
    }
    public void LoadDeathMenu()
    {
        MenuController.instance.LoadDeathMenu();
    }

    public void Chave1Change()
    {
        chave1 = !chave1;
    }

    public void Attacking()
    {
        if (attacking)
        {
            anim.SetBool("Attacking", attacking);
            attacking = false;
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider enemy in hitEnemies)
            {
                Debug.Log("Hit");
            }
        }
    }
}
