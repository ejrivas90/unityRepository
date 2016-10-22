﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN, DICE_ROLL}
    public PlayerController player;
    public TurnState currentState; 
    public EndTurnButton endTurnButton;
    public DiceRoll diceRollButton;

    void Start () {
        Debug.Log("Player State Machine Initiated");
        diceRollButton = GameObject.Find("Canvas").GetComponent<DiceRoll>();        
        endTurnButton = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
        beginTurn();
    }
	
	
	void Update () {
	}

    public void handleChangeStates(string whosTurn ) {
        switch (currentState)
        {
            case (TurnState.ATTACK):
                break;
            case (TurnState.DEAD):
                break;
            case (TurnState.MOVE):
                break;
            case (TurnState.SUMMON):
                break;
            case (TurnState.WAIT):
                break;
            case (TurnState.TAKE_DAMAGE):
                break;
        }
    }

    public void beginTurn() {
        Debug.Log("Players turn has just begun");
        currentState = TurnState.BEGIN_TURN;
        diceRollButton.hasDieRolled = false;
        player.currentStamina = 0;
    }

    public void endTurn(){
        currentState = TurnState.WAIT;
    }

    public void rollDie() {
        player.currentStamina = diceRollButton.diceRollOutcome;
        Debug.Log("Player has " + player.currentStamina + " movement points");
    }
}
