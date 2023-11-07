using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_01 : MonoBehaviour
{
    public GameObject group;
    private int trig;
    void Start()
    {
        
    }

    void Update()
    {
        if (trig == 1) StartCoroutine(Move());        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) trig = 1;
    }

    IEnumerator Move()
    {
        group.transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        group.transform.Translate(-Vector3.forward * 2.0f * Time.deltaTime);

        trig = 0;
        StopCoroutine(Move());
    }
}
