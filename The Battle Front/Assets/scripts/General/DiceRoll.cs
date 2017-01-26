using UnityEngine;
using System;
using System.Collections;

public class DiceRoll {
    public int diceRollOutcome;
    private System.Random random = new System.Random();

    public int clicked()
    {
        diceRollOutcome = random.Next(1, 11);
        Debug.Log("dice roll outcome is = " + diceRollOutcome);
        return diceRollOutcome;
    }
}
