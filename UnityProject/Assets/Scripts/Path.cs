using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] waypoints;
    public bool moveAllowed = false;
    [SerializeField] private float moveSpeed = 2.0f;
    [HideInInspector] public int waypointIndex = 0;

    private void Start()
    {        
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (moveAllowed)
        {
            Sequence();
        }
    }

    private IEnumerator Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        yield return null;
    }

    private IEnumerator Teleport(int start, int end)
    {
        string name = CheckPlayer();
        if (name == "Player1")
        {
            if (GameController.player1StartWaypoint == start)
            {
                transform.position = waypoints[end].transform.position;
                GameController.player1StartWaypoint = end;
                waypointIndex = end;
            }
        }
        else
        {
            if (GameController.player2StartWaypoint == start)
            {
                transform.position = waypoints[end].transform.position;
                GameController.player2StartWaypoint = end;
                waypointIndex = end;
            }
        }
        yield return null;
    }

    private string CheckPlayer()
    {
        return gameObject.name;
    }

    private IEnumerator Seq()
    {
        yield return Move();
        yield return Teleport(1, 14);
        yield return Teleport(6, 27);
        yield return Teleport(9, 5);
        yield return Teleport(12, 2);
        yield return Teleport(13, 26);
        yield return Teleport(18, 31);
        yield return Teleport(24, 37);
        yield return Teleport(29, 8);
        yield return Teleport(34, 20);
        yield return Teleport(40, 23);
    }

    private void Sequence()
    {
        StartCoroutine(Seq());
    }
}
