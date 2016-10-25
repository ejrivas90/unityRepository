using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyStateMachine : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN, DICE_ROLL}
    public EnemyController enemy;
    public TurnState currentState;
    private TurnManager turnManager;
    private DiceRoll diceRollButton;
    private EndTurnButton endTurnButton;

    void Start()
    {
        Debug.Log("Enemy State Machine Initiated");
        currentState = TurnState.WAIT;
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        diceRollButton = GameObject.Find("Canvas").GetComponent<DiceRoll>();
        endTurnButton = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
    }

    void Update()
    {
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

    public void beginTurn()
    {
        Debug.Log("Enemy turn has just begun");
        currentState = TurnState.BEGIN_TURN;
        diceRollButton.hasDieRolled = false;
        enemy.currentStamina = 0;
        
    }

    public void endTurn()
    {
        currentState = TurnState.WAIT;
    }

    public void rollDie()
    {
        enemy.currentStamina = diceRollButton.diceRollOutcome;
        Debug.Log("Player has " + enemy.currentStamina + " movement points");
    }
}
