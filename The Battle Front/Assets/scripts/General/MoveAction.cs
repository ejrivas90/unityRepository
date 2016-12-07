using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : MonoBehaviour {
    private TurnManager turnManager;
    private DiceRoll diceRoll;
    private Grid grid;
    private bool hasBeenClicked;
    private GameObject currentActiveSoldier;
    private Dictionary<string, GameObject> listOfOptions = new Dictionary<string, GameObject>(); 

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
        currentActiveSoldier = turnManager.currentSoldiers["ACTIVE"];
        if ("PLAYER".Equals(turnManager.whosTurn.ToString().Trim()))
        {
            if(currentActiveSoldier.name.Equals("player"))
            {
                PlayerChampionStateMachine champ = currentActiveSoldier.GetComponent<PlayerChampionStateMachine>();
                if(!champ.hasDiceBeenRolled)
                {
                    champ.rollDie();
                    listOfOptions = grid.showMoveOption(champ.playerChamp.playerChampionLocation, champ.playerChamp.currentStamina);
                    hasBeenClicked = true;
                }
                else
                {
                    Debug.Log("Dice has already been rolled");
                }
            }
            else
            {
                PlayerStateMachine playerSoldier = currentActiveSoldier.GetComponent<PlayerStateMachine>();
                playerSoldier.rollDie();
                //grid.showMoveOption(playerSoldier.)
                hasBeenClicked = true;
            }
        } else
        {

        }
    }

    private void Update()
    {
        if (hasBeenClicked)
        {
            tileSelectedToMove();
        }
    }

    void tileSelectedToMove()
    {
        float x = currentActiveSoldier.transform.position.x;
        float y = currentActiveSoldier.transform.position.z;

        if(Input.GetKeyDown("left"))
        {
            Vector3 newPosition = new Vector3(x - 1, 0, y);
            string key = (x - 1) + "," + y;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x - 1, 0, y);
            }
        }
        if(Input.GetKeyDown("right"))
        {
            Vector3 newPosition = new Vector3(x + 1, 0, y);
            string key = (x + 1) + "," + y;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x + 1, 0, y);
            }
        }
        if(Input.GetKeyDown("up"))
        {
            Vector3 newPosition = new Vector3(x, 0, y+1);
            string key = x + "," + (y + 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0, y + 1);
            }
        }
        if(Input.GetKeyDown("down"))
        {
            Vector3 newPosition = new Vector3(x, 0, y - 1);
            string key = x + "," + (y - 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0, y - 1);
            }
        }
    }
}
