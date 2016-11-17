using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyController {
    public string name;
    public float baseHealth;
    public float currentHealth;
    public int attackPower;
    public int baseStamina;
    public int currentStamina;
    public bool hasDieRolled;
    public GameObject enemyChampionLocation;
}
