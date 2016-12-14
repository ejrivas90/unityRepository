using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : MonoBehaviour {
    private TurnManager turnManager;
    private Grid grid;
    private bool hasButtonBeenClicked;
    private GameObject currentActiveSoldier;
    private Dictionary<string, GameObject> listOfOptions = new Dictionary<string, GameObject>(); 

    void Start()
    {
        Debug.Log("end turn button script started");
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        hasButtonBeenClicked = false;
    }

    public void newTurn()
    {
        if(grid != null)
        {
            grid.clearGrid();
        }
        currentActiveSoldier = turnManager.currentSoldiers["ACTIVE"];
    }

    public void clear()
    {
        grid.clearGrid();
    }

    public void click()
    {
        Debug.Log("Move action button has been clicked");
        if ("PLAYER".Equals(turnManager.whosTurn.ToString().Trim()))
        {
            if(currentActiveSoldier.name.Equals("player"))
            {
                PlayerChampionStateMachine champ = currentActiveSoldier.GetComponent<PlayerChampionStateMachine>();
                if(!champ.hasDiceBeenRolled)
                {
                    champ.rollDie();
                    listOfOptions = grid.showMoveOption(champ.playerChamp.playerChampionLocation, champ.playerChamp.currentStamina);
                    hasButtonBeenClicked = true;
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
                hasButtonBeenClicked = true;
            }
        } else
        {

        }
    }

    private void Update()
    {
        if (hasButtonBeenClicked)
        {
            tileSelectedToMove();
        }
        if(Input.GetButtonDown("Submit"))
        {
            Debug.Log("Player has made a selection");
        }
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Player has cancel move");
        }
    }

    void tileSelectedToMove()
    {
        float x = currentActiveSoldier.transform.position.x;
        float y = currentActiveSoldier.transform.position.z;

        if(Input.GetKeyDown("left"))
        {
            string key = (x - 1) + "," + y;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x - 1, 0, y);
            }
        }
        if(Input.GetKeyDown("right"))
        {
            string key = (x + 1) + "," + y;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x + 1, 0, y);
            }
        }
        if(Input.GetKeyDown("up"))
        {
            string key = x + "," + (y + 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0, y + 1);
            }
        }
        if(Input.GetKeyDown("down"))
        {
            string key = x + "," + (y - 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0, y - 1);
            }
        }
    }
}
