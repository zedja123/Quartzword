using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public bool chave1;

    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask enemyLayers;
    public static PlayerController instance;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject espada;
    [SerializeField] LayerMask destinationLayer;
    [SerializeField] Transform destination;
    public Transform SwordLocation;


    private float z;
    [SerializeField] private float jumpPower;
    private bool canJump;
    private bool lookingLeft;
    private bool attacking;
    public bool canAttack;
    [SerializeField] public bool canMove;

    public int swordDamage = 4;
    public float maxLife = 20;
    public float currentLife;
    public float nextAttackTime;
    public float attackCooldown;

    public Image healthBar;

    public bool swordFlying;
    public bool swordAttacking;
    public Transform swordAttackPoint;
    public AudioSource slash;
    public AudioSource die;
    public AudioSource jump;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SwordScript.instance.ChangeDestination(SwordLocation);
        currentLife = maxLife;
    }
    private void Update()
    {
        if (canMove)
        {
            Inputs();
        }
        Flip();
        Animations();
        //AddRemoveSword();
        Attacking();
        SwordAttacking();
        healthBar.fillAmount = currentLife / maxLife;

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
            Jump();
        }

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
        if (Input.GetMouseButtonDown(0) && canAttack && swordFlying == false)
        {
            if (Time.time >= nextAttackTime)
            {
                attacking = true;
                nextAttackTime = Time.time + attackCooldown;
            }

        }
        if (Input.GetMouseButtonDown(0) && canAttack == false && swordFlying)
        {
            if (Time.time >= nextAttackTime)
            {
                swordAttacking = true;
                nextAttackTime = Time.time + attackCooldown;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            MoveSword();
            swordFlying = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwordScript.instance.ChangeDestination(SwordLocation);
            canAttack = true;
            swordFlying = false;
            SwordScript.instance.anim.enabled = false;

        }
    }

    void Movement()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, z * speed);

    }

    void Jump()
    {
        if (canJump)
        {
            JumpSound();
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
        anim.SetFloat("Speed", Mathf.Abs(z));
        anim.SetBool("IsMoving", rb.velocity.z != 0);
        anim.SetBool("OnGround", OnGround());
        anim.SetBool("Attacking", attacking);
    }

    /*    void AddRemoveSword()
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
    */
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
            StartCoroutine(AttackPointCalculator());

        }
    }

    public void SwordAttacking()
    {
        if (swordAttacking)
        {
            SlashSound();
            SwordScript.instance.anim.enabled = true;
            SwordScript.instance.anim.SetFloat("Blend", 1);
            swordAttacking = false;
            StartCoroutine(SwordAttackPointCalculator());

        }
    }
    public IEnumerator SwordAttackPointCalculator()
    {
        yield return new WaitForSeconds(0.33f);
        Collider[] hitEnemies = Physics.OverlapSphere(swordAttackPoint.position, attackRange, enemyLayers);

        SwordScript.instance.anim.SetFloat("Blend", 0);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Hit");
            enemy.GetComponent<DamageCalc>().TakeDamage(swordDamage);

        }

    }

    public IEnumerator AttackPointCalculator()
    {
        yield return new WaitForSeconds(0.33f);
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        SlashSound();
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Hit");
            enemy.GetComponent<DamageCalc>().TakeDamage(swordDamage);
        }

    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            MenuController.instance.LoadDeathMenu();
            DieSound();
        }
    }

    public void MoveSword()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, destinationLayer))
        {
            Debug.Log(hit.point);
            destination.position = hit.point;
            SwordScript.instance.ChangeDestination(destination);
            canAttack = false;
        }
    }

    public void SlashSound()
    {
        slash.Play();
    }

    public void DieSound()
    {
        die.Play();
    }

    public void JumpSound()
    {
        jump.Play();
    }
}
