using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAction : MonoBehaviour {
    private TurnManager turnManager;
    private Grid grid;
    private bool hasButtonBeenClicked;
    private bool moveMade;
    private GameObject currentActiveSoldier;
    private GameObject moveButton;
    private Dictionary<string, GameObject> listOfOptions = new Dictionary<string, GameObject>();
    private Vector3 currentSoldierPosition;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        moveButton = GameObject.Find("Move");
    }

    void Start()
    {
        Debug.Log("end turn button script started");
        hasButtonBeenClicked = false;
    }

    public void newTurn()
    {
        moveButton.SetActive(true);
        grid.clearGrid();
        foreach (GameObject gameObj in turnManager.currentSoldiers)
        {
            if(gameObj.GetComponent<AbstractSoldier>().getCurrentState().ToString().Equals("ACTIVE"))
            {
                currentActiveSoldier = gameObj;
            }
        }
        currentSoldierPosition = currentActiveSoldier.transform.position;
        moveMade = false; 
    }

    public void moveButtonClicked()
    {
        Debug.Log("Move action button has been clicked");
        if (!moveMade)
        {
            AbstractSoldier soldier = currentActiveSoldier.GetComponent<AbstractSoldier>();
            getMovementPoints(soldier);
            hasButtonBeenClicked = true;
        }
    }
    
    private void getMovementPoints(AbstractSoldier soldier)
    {
        soldier.rollDie();
        listOfOptions = grid.showMoveOption(soldier.getSoldierVector(), soldier.getCurrentStamina());
    }

    private void Update()
    {
        if (hasButtonBeenClicked)
        {
            GameObject myEventSystem = GameObject.Find("EventSystem");
            GameObject canvas = GameObject.Find("Canvas");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(canvas);
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
        float z = currentActiveSoldier.transform.position.z;

        if(Input.GetKeyDown("left"))
        {
            string key = (x - 1) + "," + z;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x - 1, 0.5f, z);
            }
        }
        if(Input.GetKeyDown("right"))
        {
            string key = (x + 1) + "," + z;
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x + 1, 0.5f, z);
            }
        }
        if(Input.GetKeyDown("up"))
        {
            string key = x + "," + (z + 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0.5f, z + 1);
            }
        }
        if(Input.GetKeyDown("down"))
        {
            string key = x + "," + (z - 1);
            if (listOfOptions.ContainsKey(key))
            {
                currentActiveSoldier.transform.position = new Vector3(x, 0.5f, z - 1);
            }
        }
    }

    public void handleMoveCancelled()
    {
        currentActiveSoldier.transform.position = currentSoldierPosition;
        grid.clearGrid();
        hasButtonBeenClicked = false;
    }

    public void handleMoveSelected()
    {
        currentActiveSoldier.transform.position = new Vector3(currentActiveSoldier.transform.position.x, 0.5f, currentActiveSoldier.transform.position.z);
        currentSoldierPosition = currentActiveSoldier.transform.position;
        grid.clearGrid();
        moveMade = true;
        hasButtonBeenClicked = false;
        moveButton.SetActive(false);
        currentActiveSoldier.GetComponent<AbstractSoldier>().setCurrentState(AbstractSoldier.TurnState.ACTIVE);
    }

    public void setMoveMade(bool moveMade)
    {
        this.moveMade = moveMade;
    }

    public bool getMoveMade()
    {
        return moveMade;
    }

    public void buttonDisable(bool isDisabled)
    {
        moveButton.SetActive(isDisabled);
    }
}
