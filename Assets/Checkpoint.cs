using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject instance;
    // Start is called before the first frame update

    void Start()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterController2D.instance.lastCheckpoint = this.transform;
        }
        
    }
}
