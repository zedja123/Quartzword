using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy3 : MonoBehaviour
{
    public DamageCalc damageCalc;
    public AudioSource bell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(damageCalc.dead == true)
        {
            PZ2.instance.sino = true;
            PZ2.instance.PZ2Open();
        }
    }

}
