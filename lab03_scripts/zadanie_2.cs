using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_2 : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        speed = speed * -1;
    }
}
