using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject attackButton;
    private string whosTurn;
    private Grid grid;
    private GameObject currentActiveSoldier;
    private Dictionary<string, List<GridObject>> listOfOptions;
    private List<GridObject> verticalList;
    private List<GridObject> horizontalList;
    private bool attackButtonClicked;
    private Vector3 currentSoldierPosition;
    List<GridObject> activeGrid = new List<GridObject>();
    int vIndex;
    int hIndex;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        attackButton = GameObject.Find("Attack");
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    public void attackAction()
    {
        activeGrid.Clear();
        whosTurn = turnManager.whosTurn.ToString();
        foreach (GameObject gameObj in turnManager.currentSoldiers)
        {
            if (gameObj.GetComponent<AbstractSoldier>().getCurrentState().ToString().Equals("ACTIVE"))
            {
                currentActiveSoldier = gameObj;
                currentSoldierPosition = currentActiveSoldier.transform.position;
            }
        }

        listOfOptions = grid.showAttackOption(currentActiveSoldier);
        verticalList = listOfOptions["vertical"];
        horizontalList = listOfOptions["horizontal"];
        vIndex = currentActiveSoldier.GetComponent<AbstractSoldier>().getAtkRange();
        hIndex = currentActiveSoldier.GetComponent<AbstractSoldier>().getAtkRange();
        attackButtonClicked = true;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(attackButtonClicked)
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

    private void handleMoveSelected()
    {

    }

    private void handleMoveCancelled()
    {
        currentActiveSoldier.transform.position = currentSoldierPosition;
        grid.addSoldierToGrid(currentActiveSoldier.transform.position, currentActiveSoldier);
        grid.clearGrid();
        attackButtonClicked = false;
    }

    void tileSelectedToMove()
    {
        Renderer rend;
        float x = currentSoldierPosition.x;
        float z = currentSoldierPosition.z;
        string baseKey = currentActiveSoldier.transform.position.x + "," + currentActiveSoldier.transform.position.z;  

        if (Input.GetKeyDown("left"))
        {
            if(hIndex > 0)
            {
                hIndex += -1;
                if(hIndex == horizontalList.Count / 2)
                {
                    hIndex += -1;
                }
                rend = horizontalList[hIndex].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.yellow;
                if (activeGrid.Count == 0)
                {
                    activeGrid.Add(horizontalList[hIndex]);
                }
                else
                {
                    Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                    tempRend.material.color = Color.red;

                    activeGrid.Clear();
                    activeGrid.Add(horizontalList[hIndex]);
                }
            }
            
        }
        if (Input.GetKeyDown("right"))
        {
            if (hIndex < horizontalList.Count-1)
            {
                hIndex += 1;
                if (hIndex == horizontalList.Count / 2)
                {
                    hIndex += 1;
                }
                rend = horizontalList[hIndex].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.yellow;

                if (activeGrid.Count == 0)
                {
                    activeGrid.Add(horizontalList[hIndex]);
                }
                else
                {
                    Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                    tempRend.material.color = Color.red;

                    activeGrid.Clear();
                    activeGrid.Add(horizontalList[hIndex]);
                }
            }
            
        }
        if (Input.GetKeyDown("up"))
        {
        }
        if (Input.GetKeyDown("down"))
        {
            if(vIndex < verticalList.Count - 1)
            {
                string a = "testbreak";
            }
        }
    }
}
