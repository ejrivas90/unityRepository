using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject attackButton;
    private string whosTurn;
    private Grid grid;
    private GameObject attackingSoldier;
    private Dictionary<string, List<GridObject>> listOfOptions;
    private List<GridObject> verticalList;
    private List<GridObject> horizontalList;
    private bool attackButtonClicked;
    private Vector3 attackingSoldierPosition;
    private List<GridObject> activeGrid = new List<GridObject>();
    private int vIndex;
    private int hIndex;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        attackButton = GameObject.Find("AttackButton");
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
                gameObj.GetComponent<AbstractSoldier>().setCurrentState(AbstractSoldier.TurnState.ATTACK);
                attackingSoldier = gameObj;
                attackingSoldierPosition = attackingSoldier.transform.position;
                gameObj.GetComponent<AbstractSoldier>().setCurrentState(AbstractSoldier.TurnState.ATTACK);
            }
        }

        if (attackingSoldier != null)
        {
            listOfOptions = grid.showAttackOption(attackingSoldier);
            verticalList = listOfOptions["vertical"];
            horizontalList = listOfOptions["horizontal"];
            vIndex = findStartIndex(verticalList);
            hIndex = findStartIndex(horizontalList);
            attackButtonClicked = true;
        }
    }

    private int findStartIndex(List<GridObject> list)
    {
        int startIndex = 0 ;

        foreach(GridObject gridObj in list)
        {
            if(gridObj.getOccupiedSoldier() != null)
            {
                startIndex = list.IndexOf(gridObj);
                break;
            }
            
        }

        return startIndex;
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
        GameObject receivingSoldier = activeGrid[0].getOccupiedSoldier();
        if(receivingSoldier != null)
        {
            int atkRoll = attackingSoldier.GetComponent<AbstractSoldier>().atkRoll();
            int defRoll = receivingSoldier.GetComponent<AbstractSoldier>().atkRoll();

            if(defRoll > atkRoll)
            {
                //do nothing
                //defending soldier dodged attack
                Debug.Log("defending soldier dodged attack");
            }
            else if(defRoll == atkRoll)
            {
                Debug.Log("re-roll");
                handleMoveSelected();
            }
            else
            {
                //attack will land, calculate damage
                AbstractSoldier defSoldier = receivingSoldier.GetComponent<AbstractSoldier>();
                AbstractSoldier atkSoldier = attackingSoldier.GetComponent<AbstractSoldier>();
                Debug.Log("defending soldier current health: " + defSoldier.getCurrentHealth());
                defSoldier.takeDamage(atkSoldier.getAttackPower());
            }
        }
        resetButton();
        attackButton.SetActive(false);
    }

    public void resetButton()
    {
        grid.clearGrid();
        hIndex = findStartIndex(horizontalList);
        vIndex = findStartIndex(verticalList);
        grid.clearGrid();
        attackButtonClicked = false;
    }

    private void handleMoveCancelled()
    {
        resetButton();
    }

    void tileSelectedToMove()
    {
        Renderer rend;
        float x = attackingSoldierPosition.x;
        float z = attackingSoldierPosition.z;
        string baseKey = attackingSoldier.transform.position.x + "," + attackingSoldier.transform.position.z;  

        if (Input.GetKeyDown("left"))
        {
            if(hIndex > 0)
            {
                vIndex = findStartIndex(verticalList);
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
                vIndex = findStartIndex(verticalList);
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
            if (vIndex > 0 )
            {
                hIndex = findStartIndex(horizontalList);
                vIndex += -1;
                if ((verticalList[vIndex].getOccupiedSoldier() != null) &&
                    verticalList[vIndex].getOccupiedSoldier().GetComponent<AbstractSoldier>().getCurrentState().Equals(AbstractSoldier.TurnState.ATTACK))
                {
                    vIndex += -1;
                }
                if (vIndex > -1)
                {
                    rend = verticalList[vIndex].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(verticalList[vIndex]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(verticalList[vIndex]);
                    }
                }
            }
        }
        if (Input.GetKeyDown("down"))
        {
            if(vIndex < verticalList.Count - 1)
            {
                hIndex = findStartIndex(horizontalList);
                vIndex += 1;
                if((verticalList[vIndex].getOccupiedSoldier()  != null) &&
                    verticalList[vIndex].getOccupiedSoldier().GetComponent<AbstractSoldier>().getCurrentState().Equals(AbstractSoldier.TurnState.ATTACK))
                {
                    vIndex += 1;
                }
                rend = verticalList[vIndex].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.yellow;

                if (activeGrid.Count == 0)
                {
                    activeGrid.Add(verticalList[vIndex]);
                }
                else
                {
                    Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                    tempRend.material.color = Color.red;

                    activeGrid.Clear();
                    activeGrid.Add(verticalList[vIndex]);
                }
            }
        }
    }
}
