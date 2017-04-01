using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {
    private static System.Random random = new System.Random();

    private void Awake()
    {
    }

    public static int roll4Die()
    {
        int outcome = 0;
        outcome = random.Next(1, 5);
        return outcome;
    }

    public static int roll6Die()
    {
        int outcome = 0;
        outcome = random.Next(1, 7);
        return outcome;
    }

    public static int roll8Die()
    {
        int outcome = 0;
        outcome = random.Next(1, 9);
        return outcome;
    }

    public static int roll10Die()
    {
        int outcome = 0;
        outcome = random.Next(1, 11);
        return outcome;
    }

    public static int rollDie()
    {
        
        int diceRollOutcome = 0;
        diceRollOutcome = random.Next(1, 11);
        Debug.Log("dice roll outcome is = " + diceRollOutcome);
        return diceRollOutcome;
    }

}
