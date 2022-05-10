using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject throwableObject;
    public Transform PosAttack;
    public Vector3 direction;
    public float life = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 2f, 2f);
    }

    private void Update()
    {
        Debug.Log(life);
    }
    void FixedUpdate()
	{


		if (life <= 0)
		{
            Destroy(gameObject);
		}
	}


	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && life > 0)
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
		}
	}


	IEnumerator DestroyEnemy()
	{
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

	}

    public void Shoot()
    {
        GameObject throwableWeapon = Instantiate(throwableObject, PosAttack.position, Quaternion.identity);
        //GameObject throwableWeapon = Instantiate(throwableObject,transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
        direction = CharacterController2D.instance.gameObject.transform.position - transform.position;
        direction = direction.normalized;
        throwableWeapon.GetComponent<EnemyThrowableProjectile>().direction = direction;
        throwableWeapon.name = "ThrowableWeapon";
        print("enemyshoot");
    }
    /*   IEnumerator Shoot()
       {
           GameObject throwableWeapon = Instantiate(throwableObject, PosAttack.position, Quaternion.identity);
           //GameObject throwableWeapon = Instantiate(throwableObject,transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
           direction = CharacterController2D.instance.gameObject.transform.position - transform.position;
           direction = direction.normalized;
           throwableWeapon.GetComponent<EnemyThrowableProjectile>().direction = direction;
           throwableWeapon.name = "ThrowableWeapon";
           print("enemyshoot");
           yield return new WaitForSeconds(2f);
       }*/
    public void ApplyDamage(float damage)
    {
            float direction = damage / Mathf.Abs(damage);
            damage = Mathf.Abs(damage);
            life -= damage;
    }
}
