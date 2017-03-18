using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject attackButton;
    private string whosTurn;
    private Grid grid;
    private GameObject currentActiveSoldier;
    private Dictionary<string, GridObject> listOfOptions;
    private bool attackButtonClicked;
    private Vector3 currentSoldierPosition;
    List<GridObject> activeGrid = new List<GridObject>();

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
            string key = (x - 1) + "," + z;
            if (!baseKey.Equals(key))
            {
                if (listOfOptions.ContainsKey(key))
                {
                    currentSoldierPosition = new Vector3(x - 1, 0, z);
                    rend = listOfOptions[key].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key]);
                    }

                }
            }
            else
            {
                string key2 = (x - 2) + "," + z;
                if (listOfOptions.ContainsKey(key2))
                {
                    currentSoldierPosition = new Vector3(x - 2, 0, z);
                    rend = listOfOptions[key2].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key2]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key2]);
                    }

                }
            }
        }
        if (Input.GetKeyDown("right"))
        {
            string key = (x + 1) + "," + z;
            if (!baseKey.Equals(key))
            {
                if (listOfOptions.ContainsKey(key))
                {
                    currentSoldierPosition = new Vector3(x + 1, 0, z);
                    rend = listOfOptions[key].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key]);
                    }
                }
            }
            else
            {
                string key2 = (x + 2) + "," + z;
                if (listOfOptions.ContainsKey(key2))
                {
                    currentSoldierPosition = new Vector3(x + 2, 0, z);
                    rend = listOfOptions[key2].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key2]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key2]);
                    }
                }
            }
        }
        if (Input.GetKeyDown("up"))
        {
            string key = x + "," + (z + 1);
            if (!baseKey.Equals(key))
            {
                if (listOfOptions.ContainsKey(key))
                {
                    currentSoldierPosition = new Vector3(x, 0, z + 1);
                    rend = listOfOptions[key].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key]);
                    }
                }
            }
            else
            {
                string key2 = x + "," + (z + 2);
                if (listOfOptions.ContainsKey(key2))
                {
                    currentSoldierPosition = new Vector3(x, 0, z + 2);
                    rend = listOfOptions[key2].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key2]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key2]);
                    }
                }
            }
        }
        if (Input.GetKeyDown("down"))
        {
            string key = x + "," + (z - 1);
            if (!baseKey.Equals(key))
            {
                if (listOfOptions.ContainsKey(key))
                {
                    currentSoldierPosition = new Vector3(x, 0, z - 1);
                    rend = listOfOptions[key].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key]);
                    }
                }
            }
            else
            {
                string key2 = x + "," + (z - 2);
                if (listOfOptions.ContainsKey(key2))
                {
                    currentSoldierPosition = new Vector3(x, 0, z - 2);
                    rend = listOfOptions[key2].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.yellow;

                    if (activeGrid.Count == 0)
                    {
                        activeGrid.Add(listOfOptions[key2]);
                    }
                    else
                    {
                        Renderer tempRend = activeGrid[0].getPlane().GetComponent<Renderer>();
                        tempRend.material.color = Color.red;

                        activeGrid.Clear();
                        activeGrid.Add(listOfOptions[key2]);
                    }
                }
            }
        }
    }
}
