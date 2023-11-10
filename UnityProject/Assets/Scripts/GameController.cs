using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameObject player1, player2;
    public static int number = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    private static GameObject whoWins, player1Text, player2Text, quitButton;

    public AudioPlayer audioPlayer;
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<Path>().moveAllowed = false;
        player2.GetComponent<Path>().moveAllowed = false;

        whoWins = GameObject.Find("WhoWinsText");
        player1Text = GameObject.Find("Player1Text");
        player2Text = GameObject.Find("Player2Text");
        quitButton = GameObject.Find("QuitButton");

        whoWins.gameObject.SetActive(false);
        player1Text.gameObject.SetActive(true);
        player2Text.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    void Update()
    {        
        if(player1.GetComponent<Path>().waypointIndex > player1StartWaypoint + number)
        {            
            player1.GetComponent<Path>().moveAllowed = false;
            player1Text.gameObject.SetActive(false);
            player2Text.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<Path>().waypointIndex - 1;
        }
        if (player2.GetComponent<Path>().waypointIndex > player2StartWaypoint + number)
        {
            player2.GetComponent<Path>().moveAllowed = false;
            player2Text.gameObject.SetActive(false);
            player1Text.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<Path>().waypointIndex - 1;
        }
        if(player1.GetComponent<Path>().waypointIndex == player1.GetComponent<Path>().waypoints.Length)
        {
            whoWins.gameObject.SetActive(true);
            whoWins.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 Wins.";
            gameOver = true;
            audioPlayer.PlayWinAudio();
            quitButton.gameObject.SetActive(true);
        }
        if (player2.GetComponent<Path>().waypointIndex == player2.GetComponent<Path>().waypoints.Length)
        {
            whoWins.gameObject.SetActive(true);
            whoWins.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 Wins.";
            gameOver = true;
            audioPlayer.PlayWinAudio();
            quitButton.gameObject.SetActive(true);
        }
    }

    public static void PlayerMove(int player)
    {
        switch (player)
        {
            case 1:
                player1.GetComponent<Path>().moveAllowed = true;
                break;
            case 2:
                player2.GetComponent<Path>().moveAllowed = true;
                break;
        }
    }
}
