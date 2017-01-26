using UnityEngine;
using System.Collections;

public class EndTurnButton : MonoBehaviour {
    private TurnManager turnManager;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    void Start() {
        Debug.Log("end turn button script started");        
    }

    public void endTurnButtonClicked() {
        Debug.Log("End Turn button has been clicked");
        Debug.Log("It is currently " + turnManager.whosTurn + " turn");
        turnManager.switchTurns();
        Debug.Log("After switch, it is " + turnManager.whosTurn + " turn");
    }
    
}
