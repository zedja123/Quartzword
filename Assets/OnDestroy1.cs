using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy1 : MonoBehaviour
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
        PZ3.instance.balista1 = true;
        PZ3.instance.PZ3Open();
    }
}
