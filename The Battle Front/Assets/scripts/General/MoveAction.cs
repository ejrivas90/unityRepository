using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : MonoBehaviour {
    private TurnManager turnManager;
    private Grid grid;
    private bool hasButtonBeenClicked;
    private bool hasCancelledBeenClicked;
    private bool moveMade;
    private GameObject currentActiveSoldier;
    private Dictionary<string, GameObject> listOfOptions = new Dictionary<string, GameObject>();
    private Vector3 currentSoldierPosition;

    void Start()
    {
        Debug.Log("end turn button script started");
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        hasButtonBeenClicked = false;
        newTurn();
    }

    public void newTurn()
    {
        grid.clearGrid();
        currentActiveSoldier = turnManager.currentSoldiers["ACTIVE"];
        currentSoldierPosition = currentActiveSoldier.transform.position;
        hasCancelledBeenClicked = false;
        moveMade = false; 
    }

    public void clear()
    {
        grid.clearGrid();
    }

    public void click()
    {
        Debug.Log("Move action button has been clicked");
        if (!moveMade)
        {
            if ("PLAYER".Equals(turnManager.whosTurn.ToString().Trim()))
            {
                if (currentActiveSoldier.name.Equals("player"))
                {
                    PlayerChampionStateMachine champ = currentActiveSoldier.GetComponent<PlayerChampionStateMachine>();
                    getMovementPoints(champ);
                }
                else
                {
                    PlayerStateMachine playerSoldier = currentActiveSoldier.GetComponent<PlayerStateMachine>();
                    getMovementPoints(playerSoldier);
                }
            }
            else
            {

            }
            hasButtonBeenClicked = true;
        }
    }

    private void getMovementPoints(PlayerChampionStateMachine pChamp)
    {
        pChamp.rollDie();
        listOfOptions = grid.showMoveOption(pChamp.playerChamp.playerChampionLocation, pChamp.playerChamp.currentStamina);
    }

    private int getMovementPoints(PlayerStateMachine pSoldier)
    {
        return 0;
    }

    private int getMovementPoints(EnemyStateMachine eSoldier)
    {
        return 0;
    }

    /*
    private int getMovementPoints(EnemyChampionStateMachine pChamp)
    {
        return 0;
    }
    */


    private void Update()
    {
        if (hasButtonBeenClicked)
        {
            tileSelectedToMove();
            if (Input.GetButtonDown("Submit"))
            {
                handleMoveSelected();
                Debug.Log("Player has made a selection");
            }
            if (Input.GetButtonDown("Cancel"))
            {
                handleMoveCancelled();
                Debug.Log("Player has cancel move");
            }
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

    public void handleMoveCancelled()
    {
        currentActiveSoldier.transform.position = currentSoldierPosition;
        grid.clearGrid();
        hasButtonBeenClicked = true;
    }

    public void handleMoveSelected()
    {
        currentSoldierPosition = currentActiveSoldier.transform.position;
        grid.clearGrid();
        moveMade = true;
    }

    public void setMoveMade(bool moveMade)
    {
        this.moveMade = moveMade;
    }

    public bool getMoveMade()
    {
        return moveMade;
    }
}
