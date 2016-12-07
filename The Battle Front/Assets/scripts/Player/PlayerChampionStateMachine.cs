using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerChampionStateMachine : MonoBehaviour
{
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN, DICE_ROLL, ACTIVE }
    public PlayerController playerChamp;
    public GameObject playerChampObject;
    public TurnState currentState;
    public EndTurnButton endTurnButton;
    public bool hasDiceBeenRolled;
    private DiceRoll diceRoll;

    void Start()
    {
        Debug.Log("Player Champ State Machine Initiated");
        endTurnButton = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
        playerChamp.playerType = PlayerController.PlayerType.CHAMPION;
        diceRoll = new DiceRoll();
    }

    public void init()
    {
        playerChamp.name = "Player Champion";
        playerChamp.playerPosition = (GameObject)GameObject.Find("square: 7,14");
        playerChamp.playerChampionLocation = (Vector3)GameObject.Find("square: 7,14").transform.position;
        transform.position = playerChamp.playerChampionLocation;
        currentState = TurnState.ACTIVE;
        Debug.Log("champ is at " + playerChamp.playerPosition);
    }

    void Update()
    {
        Debug.Log("champ vector: " + this.transform.position.x + ", "+ this.transform.position.y + ", " + this.transform.position.z);

    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Players turn has just begun");
        Debug.Log("Champ is at " + playerChamp.playerPosition);
        currentState = TurnState.ACTIVE;
        hasDiceBeenRolled = false;
        playerChamp.currentStamina = 0;
    }

    public void endTurn()
    {
        currentState = TurnState.WAIT;
    }

    public void rollDie()
    {
        playerChamp.currentStamina = diceRoll.clicked();
        Debug.Log("Champ has " + playerChamp.currentStamina + " movement points");
        hasDiceBeenRolled = true;
    }

    public void moveClicked()
    {
        Debug.Log("Move action selected");
    }
    
}
