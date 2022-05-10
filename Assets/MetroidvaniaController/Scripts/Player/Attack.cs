using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public static Attack instance;
	public float ClickDuration = 0.75f;

	bool clicking = false;
	float totalDownTime = 0;
	public float dmgValue = 4;
	public GameObject throwableObject;
	public Transform attackCheck;
	
	[SerializeField] private Rigidbody2D m_Rigidbody2D;
	public Transform PosAttack;
	public Animator animator;
	public bool canAttack;
	public bool isTimeToCheck = false;

	public GameObject cam;

	Vector3 direction;

    // Update is called once per frame

    private void Awake()
    {
		instance = this;
    }
    void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0f;
		//Vector3 mousePosition = (mousePosition - transform.position).normalized;
		if (Input.GetMouseButtonDown(0))
		{
			totalDownTime = 0;
			clicking = true;
		}

		if (clicking && Input.GetMouseButton(0)) //tiro
		{ 
			totalDownTime += Time.deltaTime;
			if (totalDownTime >= ClickDuration && CharacterController2D.instance.energy >= 70 && canAttack)
			{
				CharacterController2D.instance.energy -= 20;
				CharacterController2D.instance.SetEnergy();
				clicking = false;
				GameObject throwableWeapon = Instantiate(throwableObject, PosAttack.position, Quaternion.identity);
				//GameObject throwableWeapon = Instantiate(throwableObject,transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
				direction = mousePosition - transform.position;
				direction = direction.normalized;
				throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
				throwableWeapon.name = "ThrowableWeapon";
				print("mouse0");
			}


		}
		if (clicking && Input.GetMouseButtonUp(0) && canAttack)
		{
			CharacterController2D.instance.energy = Mathf.Min(CharacterController2D.instance.energy + 10, 100);
			CharacterController2D.instance.SetEnergy();
			Debug.Log(CharacterController2D.instance.energy);
			canAttack = false;
			animator.SetBool("IsAttacking", true);
			StartCoroutine(AttackCooldown());
		}
		Debug.Log(direction);
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}


	public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
}