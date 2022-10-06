using System;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{

    public GameObject[] players;
    private int turn;
    public TextMeshProUGUI timerText;
    private float playTimer;
    public GameObject[] cameras;
    public GameObject[] guns;

    public float turnTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase timer
        playTimer += Time.deltaTime;
        timerText.text = "Time left: " + (turnTime - Mathf.RoundToInt(playTimer));


        if (players[turn] != null && players[(turn + 1) % 2] != null)
        {
            //active player
            players[turn].GetComponent<PlayerMovement>().enabled = true;
            cameras[turn].SetActive(true);
            guns[turn].GetComponent<CharacterWeapon>().enabled = true;

            //inactive player
            players[(turn + 1) % 2].GetComponent<PlayerMovement>().enabled = false;
            cameras[(turn + 1) % 2].SetActive(false);
            guns[(turn + 1) % 2].GetComponent<CharacterWeapon>().enabled = false;
            

            //changes turn after 10s
            if(playTimer > turnTime)
            {
                turn = ((turn + 1) % 2);
                playTimer = 0;
            }
        }
       


        //win check
        if (players[0].activeSelf == false)
        {
            print("player 2 won!");
        }
        else if (players[1].activeSelf == false)
        {
            print("player 1 won!");
        }
    }
}
