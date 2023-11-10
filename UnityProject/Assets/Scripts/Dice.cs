using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    public static Vector3 velocity;
    private int playerTurn = 1;
    public bool coroutineAllowed = true;
    public int diceNumber;
    public GameObject[] Sides;
    private float temp;
    public AudioPlayer audioPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //void OnMouseDown()
    //{
    //    if (!GameController.gameOver && coroutineAllowed)
    //    {            
    //        StartCoroutine("RollDice");
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!GameController.gameOver && coroutineAllowed)
            {
                StartCoroutine("RollDice");
            }
        }
    }

    private IEnumerator RollDice()
    {
        coroutineAllowed = false;
        audioPlayer.PlayDiceAudio();
        Dice3D();

        yield return new WaitForSeconds(3);

        GameController.number = diceNumber;
        if(playerTurn == 1) { GameController.PlayerMove(1); }
        else if(playerTurn == -1) { GameController.PlayerMove(2); }
        playerTurn *= -1;
        coroutineAllowed = true;
    }

    private void FixedUpdate()
    {
        if (rb.IsSleeping()
            /*rb.velocity.x == 0f && rb.velocity.y == 0f && rb.velocity.z == 0f*/)
        {
            temp = -1;
            foreach (GameObject side in Sides)
            {
                if (side.transform.position.y > temp)
                {
                    temp = side.transform.position.y;
                    diceNumber = CheckSide(side);
                }
            }
        }
    }
    private void Dice3D()
    {
        float dirX = Random.Range(0, 100);
        float dirY = Random.Range(0, 100);
        float dirZ = Random.Range(0, 100);

        transform.SetPositionAndRotation(new Vector3(6.5f, 3, 1.5f), Quaternion.identity);
        rb.AddForce(transform.up * 100);
        rb.AddTorque(dirX, dirY, dirZ);
    }
    private int CheckSide(GameObject side)
    {
        switch (side.name)
        {
            case "Side1":
                return 1;
            case "Side2":
                return 2;
            case "Side3":
                return 3;
            case "Side4":
                return 4;
            case "Side5":
                return 5;
            case "Side6":
                return 6;
            default:
                return 0;
        }
    }
}
