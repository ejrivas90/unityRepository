using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour {
    public PlayerController player;
    public TurnState currentState;

    public enum TurnState {
        ATTACK,
        MOVE,
        WAIT,
        SUMMON,
        DEAD,
        TAKE_DAMAGE,
    }   

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
}
