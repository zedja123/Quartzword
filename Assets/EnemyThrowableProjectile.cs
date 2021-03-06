using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowableProjectile : MonoBehaviour
{
	// Start is called before the first frame update
	public Vector3 direction;
	public bool hasHit = false;
	public float speed = 10f;

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!hasHit)
			GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			CharacterController2D.instance.ApplyDamage(10f, this.transform.position);
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
