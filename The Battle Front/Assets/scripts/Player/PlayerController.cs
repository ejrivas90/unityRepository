using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController {
    public enum PlayerType {CHAMPION, INFANTRY, MARKSMAN, TANK, ARTILLERY };
    public PlayerType playerType;
    public string name;
    public float baseHealth;
    public float currentHealth;
    public int attackPower;
    public int baseStamina;
    public int currentStamina;
    public bool hasDieRolled;
    public Vector3 playerChampionLocation;
    public GameObject playerPosition;

}
