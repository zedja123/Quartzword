using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ6 : MonoBehaviour
{
    public static PZ6 instance;
    public destructible door;

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

    public void PZ6Open()
    {
        door.Destructible();
    }
}
