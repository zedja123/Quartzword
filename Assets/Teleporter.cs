using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update]



    void Start()
    {
        CharacterController2D.instance.GoToCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
