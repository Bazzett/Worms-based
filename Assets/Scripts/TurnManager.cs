using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private GameObject _myTurn;

    private void Awake()
    {
        _myTurn = player1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_myTurn == player1)
            {
                print("1");
                
                _myTurn.GetComponent<PlayerMovement>().enabled = false;
                _myTurn.transform.GetChild(4).gameObject.SetActive(false);
                
                player2.GetComponent<PlayerMovement>().enabled = true;
                player2.transform.GetChild(4).gameObject.SetActive(true);
                
                _myTurn = player2;
            } 
            else if (_myTurn == player2)
            {
                print("2");

                _myTurn.GetComponent<PlayerMovement>().enabled = false;
                _myTurn.transform.GetChild(4).gameObject.SetActive(false);
                
                player1.GetComponent<PlayerMovement>().enabled = true;
                player1.transform.GetChild(4).gameObject.SetActive(true);
                
                _myTurn = player1;
            }
        }
    }
}
