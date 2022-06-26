using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    public void Destructible()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
