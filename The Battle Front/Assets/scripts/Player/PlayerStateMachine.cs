using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE}
    public PlayerController player;
    public TurnState currentState;    

	void Start () {
	    
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
        }         
	}

    void updatePlayerHealth() {

    }

    void movePlayer(int movementPoints) {
       
    }
}
