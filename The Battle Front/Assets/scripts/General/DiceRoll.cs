using UnityEngine;
using System;
using System.Collections;

public class DiceRoll {

    public int clicked()
    {
        System.Random random = new System.Random();
        int diceRollOutcome = 0;
        diceRollOutcome = random.Next(1, 11);
        Debug.Log("dice roll outcome is = " + diceRollOutcome);
        return diceRollOutcome;
    }

    public int roll4Die()
    {
        int outcome = 0;
        System.Random random = new System.Random();
        outcome = random.Next(1, 5);
        return outcome;
    }

    public int roll6Die()
    {
        int outcome = 0;
        System.Random random = new System.Random();
        outcome = random.Next(1, 7);
        return outcome;
    }

    public int roll8Die()
    {
        int outcome = 0;
        System.Random random = new System.Random();
        outcome = random.Next(1, 9);
        return outcome;
    }

    public int roll10Die()
    {
        int outcome = 0;
        System.Random random = new System.Random();
        outcome = random.Next(1, 11);
        return outcome;
    }
}
