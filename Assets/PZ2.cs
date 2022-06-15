using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ2 : MonoBehaviour
{
    public OpenDoor door;
    public bool sino;

    public static PZ2 instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PZ2Open()
    {
        if (sino)
        {
            door.OpenDoor1();
        }
    }
}
