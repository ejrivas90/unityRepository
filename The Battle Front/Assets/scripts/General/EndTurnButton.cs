using UnityEngine;
using System.Collections;

public class EndTurnButton : MonoBehaviour {
    private TurnManager turnManager;
    private string whosTurn;

    void Start() {
        Debug.Log("end turn button script started");
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        whosTurn = turnManager.whosTurn.ToString();
    }
    public void click() {
        Debug.Log("End Turn button has been clicked");
        Debug.Log("It is currently " + whosTurn + " turn");

        switchPlayers();
        Debug.Log("After switch, it is " + whosTurn + " turn");
    }

    void switchPlayers() {
        switch (whosTurn) {
            case ("PLAYER"):
                turnManager.whosTurn = TurnManager.Turn.ENEMY;
                whosTurn = turnManager.whosTurn.ToString();
                break;
            case ("ENEMY"):
                turnManager.whosTurn = TurnManager.Turn.PLAYER;
                whosTurn = turnManager.whosTurn.ToString();
                break;
        }
    }
}
