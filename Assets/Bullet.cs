using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 700f;
    public Rigidbody rb;
    public Transform target;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>().transform;
        moveDirection = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("PlayerFinal"))
        {
            print("hit");
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(2);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
