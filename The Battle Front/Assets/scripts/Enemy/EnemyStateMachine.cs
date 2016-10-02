using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyStateMachine : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN}
    public EnemyController enemy;
    public TurnState currentState;
    private TurnManager turnManager;

    void Start()
    {
        Debug.Log("Enemy State Machine Initiated");
        currentState = TurnState.WAIT;
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
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
            case (TurnState.BEGIN_TURN):
                Debug.Log("Enemy's turn has just begun");
                break;
        }
    }

    void updatePlayerHealth() {

    }

    void moveEnemy(int movementPoints) {

    }
}
