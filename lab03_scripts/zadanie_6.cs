using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_6 : MonoBehaviour
{
    public GameObject prefab;    
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.x, prefab.transform.position.x, ref yVelocity, smoothTime);
        transform.position = new Vector3(newPosition, Mathf.Lerp(0, 6, 0.5f), transform.position.z);
    }
}
