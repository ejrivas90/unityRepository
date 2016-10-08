using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN}
    public PlayerController player;
    public TurnState currentState; 
    public int counter = 0;
    public EndTurnButton endTurn;

    void Start () {
        Debug.Log("Player State Machine Initiated");
        endTurn = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
    }
	
	
	void Update () {
        switch (currentState) {
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
                
                Debug.Log("Players turn has just begun" + counter);
                counter++;
               
                    if(counter == 5)
                    {
                        endTurn.click();
                    }
                break;
        }         
	}

    void updatePlayerHealth() {

    }

    void movePlayer(int movementPoints) {
       
    }
}
