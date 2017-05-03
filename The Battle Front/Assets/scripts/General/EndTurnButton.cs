using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTurnButton : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject attackButton;
    private GameObject moveButton;
    private GameObject waitButton;
    private GameObject recruitButton;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        attackButton = GameObject.Find("AttackButton");
        moveButton = GameObject.Find("Move");
        recruitButton = GameObject.Find("Recruit");
        waitButton = GameObject.Find("Wait");
    }

    void Start() {
        Debug.Log("end turn button script started");        
    }

    public void endTurnButtonClicked() {
        Debug.Log("End Turn button has been clicked");
        Debug.Log("It is currently " + turnManager.whosTurn + " turn");
        turnManager.switchTurns();
        moveButton.GetComponent<Button>().interactable = true;
        waitButton.GetComponent<Button>().interactable = true;
        recruitButton.GetComponent<Button>().interactable = true;
        Debug.Log("After switch, it is " + turnManager.whosTurn + " turn");
    }
    
}
