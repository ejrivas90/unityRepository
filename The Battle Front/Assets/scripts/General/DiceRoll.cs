using UnityEngine;
using System;
using System.Collections;

public class DiceRoll : MonoBehaviour {
    public int diceRollOutcome;
    private System.Random random = new System.Random();
    private TurnManager turnManager;
    public bool hasDieRolled;

    void Start()
    {
        Debug.Log("dice roll button script started");
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }
    public void clicked()
    {
        if (!hasDieRolled)
        {
            diceRollOutcome = random.Next(1, 11);
            Debug.Log("dice roll outcome is = " + diceRollOutcome);
            String whosTurn = turnManager.whosTurn.ToString();
            if (whosTurn.Equals("PLAYER"))
            {
                turnManager.pStateMachine.rollDie();
            }
            if (whosTurn.Equals("ENEMY"))
            {
                turnManager.eStateMachine.rollDie();
            }
            hasDieRolled = true;
        } else {
            Debug.Log("Dice has already been rolled");
        }
    }
}
