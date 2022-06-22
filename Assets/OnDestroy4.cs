using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy4 : MonoBehaviour
{
    public GameObject barreira;
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
            PZ3.instance.balista2 = true;
            PZ3.instance.PZ3Open();
            Destroy(barreira);
            door.OpenDoor1();
        }
    }
}
