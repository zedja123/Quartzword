using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PZ6.instance.PZ6Open();
    }
}
