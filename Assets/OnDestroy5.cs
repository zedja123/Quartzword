using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy5 : MonoBehaviour
{

    public OpenDoor door;
    public DamageCalc damageCalc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damageCalc.dead == true)
        {
            door.OpenDoor1();
        }
    }

}
