using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{
    public AudioSource hit;
    public float currentLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hit.Play();
        currentLife -= damage;
        print(currentLife);
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
