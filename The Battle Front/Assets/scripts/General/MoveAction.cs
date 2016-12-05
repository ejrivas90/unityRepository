using UnityEngine;
using System.Collections;

public class MoveAction : MonoBehaviour {
    private TurnManager turnManager;
    private DiceRoll diceRoll;
    private Grid grid;
    private bool hasBeenClicked;

    void Start()
    {
        Debug.Log("end turn button script started");
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        diceRoll = GameObject.Find("Canvas").GetComponent<DiceRoll>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        hasBeenClicked = false;
    }

    public void click()
    {
        Debug.Log("Move action button has been clicked");
        int currentCount = turnManager.currentSoldiers.Count;
        if ("PLAYER".Equals(turnManager.whosTurn.ToString().Trim()))
        {
            GameObject activeSoldier = turnManager.currentSoldiers["ACTIVE"];
            if(activeSoldier.name.Equals("player"))
            {
                PlayerChampionStateMachine champ = activeSoldier.GetComponent<PlayerChampionStateMachine>();
                champ.rollDie();
                grid.showMoveOption(champ.playerChamp.playerChampionLocation, champ.playerChamp.currentStamina);
                hasBeenClicked = true;
            }
            else
            {
                Debug.Log("who is the active soldier: " + activeSoldier.GetComponent<PlayerStateMachine>().name);
            }
        } else
        {

        }
    }

    void Update()
    {
        
        if (hasBeenClicked && Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse has been clicked");
        }
    }
}
