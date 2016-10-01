using UnityEngine;
using System;
using System.Collections;

public class DiceRoll : MonoBehaviour {
    private int diceRollOutcome;
    private System.Random random = new System.Random();
    private TurnManager turnManager;

    void start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }
    public void clicked()
    {
        diceRollOutcome = random.Next(1, 11);
        Debug.Log("dice roll outcome is = " + diceRollOutcome);


    }
}
