using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_02 : MonoBehaviour
{
    private int isTriggered;
    void Start()
    {
        
    }

    void Update()
    {
        if (isTriggered == 1)
        {
            //StartCoroutine(DoorMove());
            StartCoroutine(DoorMovement());
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");       

        isTriggered = 1;
    }

    IEnumerator DoorMove()
    {
        transform.position = transform.position + new Vector3(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        transform.position = transform.position;

        isTriggered = 0;
        StopCoroutine(DoorMove());
    }

    IEnumerator DoorMoveBack()
    {
        transform.position = transform.position - new Vector3(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        transform.position = transform.position;

        StopCoroutine(DoorMoveBack());
    }

    IEnumerator DoorMovement()
    {
        yield return DoorMove();
        yield return new WaitForSeconds(3);
        yield return DoorMoveBack();
    }
}
