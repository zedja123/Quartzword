using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    public static SwordScript instance;
    Vector3 destino;
    public float velocidade = 4f;
    [SerializeField] public Transform swordLocation;
    public Rigidbody rb;
    [SerializeField] public Camera mainCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        destino = swordLocation.position;
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, destino);
        if(distancia < 0.2f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            Vector3 direcao = destino - transform.position;
            rb.velocity = direcao.normalized * velocidade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDestino();
        Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }

    public void ChangeDestino()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("chamou clique");
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 90;
            destino = mouseWorldPosition;
            Vector3 direcao = destino - transform.position;
            rb.velocity = direcao.normalized * velocidade;
        }

    }
}
