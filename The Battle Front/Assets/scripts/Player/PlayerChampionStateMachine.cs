using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerChampionStateMachine : MonoBehaviour
{
    public enum TurnState { ATTACK, MOVE, WAIT, SUMMON, DEAD, TAKE_DAMAGE, BEGIN_TURN, DICE_ROLL }
    public PlayerController playerChamp;
    public GameObject playerChampObject;
    public TurnState currentState;
    public EndTurnButton endTurnButton;
    public DiceRoll diceRollButton;

    void Start()
    {
        Debug.Log("Player Champ State Machine Initiated");
        diceRollButton = GameObject.Find("Canvas").GetComponent<DiceRoll>();
        endTurnButton = GameObject.Find("Canvas").GetComponent<EndTurnButton>();
        playerChamp.playerType = PlayerController.PlayerType.CHAMPION;
    }

    public void init()
    {
        playerChampObject = new GameObject();
        playerChamp.name = "Player Champion";
        playerChamp.playerPosition = (GameObject)GameObject.Find("square: 6,1");
        playerChamp.playerChampionLocation = (Vector3)GameObject.Find("square: 6,1").transform.position;
        playerChampObject.AddComponent<PlayerChampionStateMachine>();
        playerChampObject.AddComponent<MeshFilter>();

    }

    void Update()
    {

    }

    public void handleChangeStates(string whosTurn)
    {
        switch (currentState)
        {
            case (TurnState.ATTACK):
                break;
            case (TurnState.DEAD):
                break;
            case (TurnState.MOVE):
                break;
            case (TurnState.SUMMON):
                break;
            case (TurnState.WAIT):
                break;
            case (TurnState.TAKE_DAMAGE):
                break;
        }
    }

    public void beginTurn(GameObject playerObject)
    {
        Debug.Log("Players turn has just begun");
    }

    public void endTurn()
    {
        currentState = TurnState.WAIT;
    }

    public void rollDie()
    {
        playerChamp.currentStamina = diceRollButton.diceRollOutcome;
        Debug.Log("Player has " + playerChamp.currentStamina + " movement points");
    }
}
