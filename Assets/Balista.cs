using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{

    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform firePoint;
    [SerializeField]public Transform target;
    public AudioSource shoot;

    float fireRate;
    float nextFire;

    public float currentLife;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = 20;
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= 20f)
        {
            CheckTimeToFire();
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            shoot.Play();
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}
