using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ3 : MonoBehaviour
{
    public bool balista1;
    public bool balista2;
    public OpenDoor door;

    public static PZ3 instance;

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

    public void PZ3Open()
    {
        if (balista1 && balista2)
        {
            door.OpenDoor1();
        }
    }
}
