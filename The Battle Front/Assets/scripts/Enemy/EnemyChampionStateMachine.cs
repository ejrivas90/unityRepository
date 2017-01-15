using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyChampionStateMachine : MonoBehaviour
{
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN, DICE_ROLL, ACTIVE }
    public EnemyController enemyChamp;
    public GameObject enemyChampObject;
    public TurnState currentState;
    public EndTurnButton endTurnButton;
    public bool hasDiceBeenRolled;
    private DiceRoll diceRoll;

    void Start()
    {
        Debug.Log("Enemy Champ State Machine Initiated");
        endTurnButton = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
        enemyChamp.soldierType = EnemyController.SoldierType.CHAMPION;
        diceRoll = new DiceRoll();
    }

    public void init()
    {
        enemyChamp.name = "Enemy Champion";
        enemyChamp.enemyPosition = (GameObject)GameObject.Find("square: 7,14");
        enemyChamp.enemyChampionLocation = (Vector3)GameObject.Find("square: 7,14").transform.position;
        transform.position = enemyChamp.enemyChampionLocation;
        currentState = TurnState.ACTIVE;
        Debug.Log("champ is at " + enemyChamp.enemyPosition);
    }

    void Update()
    {
        Debug.Log("champ vector: " + this.transform.position.x + ", " + this.transform.position.y + ", " + this.transform.position.z);

    }

    public void beginTurn(GameObject enemyObject)
    {
        Debug.Log("Enemy turn has just begun");
        Debug.Log("Champ is at " + enemyChamp.enemyPosition);
        currentState = TurnState.ACTIVE;
        hasDiceBeenRolled = false;
        enemyChamp.currentStamina = 0;
    }

    public void endTurn()
    {
        currentState = TurnState.WAIT;
    }

    public void rollDie()
    {
        if (!hasDiceBeenRolled)
        {
            currentState = TurnState.MOVE;
            enemyChamp.currentStamina = diceRoll.clicked();
            Debug.Log("Champ has " + enemyChamp.currentStamina + " movement points");
            hasDiceBeenRolled = true;
        }
    }

    public void cancelMove()
    {
        hasDiceBeenRolled = false;
        enemyChamp.currentStamina = 0;
        currentState = TurnState.ACTIVE;
    }

    public void moveClicked()
    {
        Debug.Log("Move action selected");
    }

}
