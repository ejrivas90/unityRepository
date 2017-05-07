using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public GameObject plane;
    public float width = 14;
    public float height = 16;
    private GridObject[,] grid = new GridObject[14, 16];
    private Dictionary<string, GridObject> gridDictionary = new Dictionary<string, GridObject>();
    private List<GridObject> playerRecruitOptions = new List<GridObject>();
    private List<GridObject> enemyRecruitOptions = new List<GridObject>();

    void Awake()
    {
        Debug.Log("Grid initialized");
        for (int i = 0; i < width; i++)
        {
            for (int h = 0; h < height; h++)
            {

                GameObject gridPlane = (GameObject)Instantiate(plane);
                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + i,
                    gridPlane.transform.position.y, gridPlane.transform.position.z + h);
                gridPlane.name = "square: " + i + "," + h;
                GridObject planeObject = new GridObject();
                planeObject.setPlane(gridPlane);
                grid[i, h] = planeObject;
                string coords = grid[i, h].getSquarePosition().x + "," + grid[i, h].getSquarePosition().z;
                gridDictionary.Add(coords, grid[i, h]);
            }
        }
        addBasesToBoard();
        addToPlayerRecruitList();
        addToEnemyRecruitList();
        clearGrid();
    }

    private void addBasesToBoard()
    {
        GameObject playerBase = GameObject.Find("Base1");
        GameObject enemyBase = GameObject.Find("Base2");
    
        gridDictionary["1.5,7.5"].setOccupiedSoldier(playerBase);
        gridDictionary["0.5,7.5"].setOccupiedSoldier(playerBase);
        gridDictionary["-0.5,7.5"].setOccupiedSoldier(playerBase);

        gridDictionary["-1.5,-7.5"].setOccupiedSoldier(enemyBase);
        gridDictionary["0.5,-7.5"].setOccupiedSoldier(enemyBase);
        gridDictionary["-0.5,-7.5"].setOccupiedSoldier(enemyBase);
    }

    private bool checkBasePosition(Vector3 positionToCheck)
    {
        bool isValid = true;
        Vector3 pBase1 = new Vector3(1.5f, 0f, 7.5f);
        Vector3 pBase2 = new Vector3(.5f, 0f, 7.5f);
        Vector3 pBase3 = new Vector3(-.5f, 0f, 7.5f);

        Vector3 eBase1 = new Vector3(-1.5f, 0f, -7.5f);
        Vector3 eBase2 = new Vector3(.5f, 0f, -7.5f);
        Vector3 eBase3 = new Vector3(-.5f, 0f, -7.5f);

        if(positionToCheck.Equals(pBase1) || positionToCheck.Equals(pBase2)
            || positionToCheck.Equals(pBase3))
        {
            isValid = false;
        }
        if (positionToCheck.Equals(eBase1) || positionToCheck.Equals(eBase2)
            || positionToCheck.Equals(eBase3))
        {
            isValid = false;
        }

        return isValid;
    }

    private void addToPlayerRecruitList()
    {
        playerRecruitOptions.Add(gridDictionary["-1.5,7.5"]);
        playerRecruitOptions.Add(gridDictionary["-1.5,6.5"]);
        playerRecruitOptions.Add(gridDictionary["-0.5,6.5"]);
        playerRecruitOptions.Add(gridDictionary["1.5,6.5"]);
        playerRecruitOptions.Add(gridDictionary["2.5,6.5"]);
        playerRecruitOptions.Add(gridDictionary["2.5,7.5"]);
    }

    private void addToEnemyRecruitList()
    {
        enemyRecruitOptions.Add(gridDictionary["-2.5,-7.5"]);
        enemyRecruitOptions.Add(gridDictionary["-2.5,-6.5"]);
        enemyRecruitOptions.Add(gridDictionary["-1.5,-6.5"]);
        enemyRecruitOptions.Add(gridDictionary["0.5,-6.5"]);
        enemyRecruitOptions.Add(gridDictionary["1.5,-6.5"]);
        enemyRecruitOptions.Add(gridDictionary["1.5,-7.5"]);
     }

    public Dictionary<string, GridObject> showMoveOption(Vector3 position, int points)
    {
        Renderer rend;
        Dictionary<string, GridObject> listOfOptions = new Dictionary<string, GridObject>();
        string squarePosition = position.x + "," + position.z;
        listOfOptions.Add(squarePosition, gridDictionary[squarePosition]);
        float x = position.x;
        float z = position.z;
        GridObject square = gridDictionary[squarePosition];   
        Renderer mainRend = square.getPlane().GetComponent<Renderer>();
        mainRend.material.color = Color.black;
        
        for (int i = 0; i < points + 1; i++)
        {
            for (int h = 1; h < points + 1; h++)
            {

                if ((i + h != (points + 1)) && (i + h < (points + 1)))
                {
                    Debug.Log("painted: " + (x + i) + ", " + (z + h));
                    Debug.Log(i + ", " + h);

                    if (gridDictionary.ContainsKey((x + i) + "," + (z + h)))
                    {
                        string key = (x + i) + "," + (z + h);
                        rend = gridDictionary[key].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if(!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                        
                    }
                    if (gridDictionary.ContainsKey((x + h) + "," + (z + i)))
                    {
                        string key = (x + h) + "," + (z + i);
                        rend = gridDictionary[(x + h) + "," + (z + i)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - i) + "," + (z - h)))
                    {
                        string key = (x - i) + "," + (z - h);
                        rend = gridDictionary[(x - i) + "," + (z - h)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x + i) + "," + (z - h)))
                    {
                        string key = (x + i) + "," + (z - h);
                        rend = gridDictionary[(x + i) + "," + (z - h)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x + h) + "," + (z - i)))
                    {
                        string key = (x + h) + "," + (z - i);
                        rend = gridDictionary[(x + h) + "," + (z - i)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - i) + "," + (z + h)))
                    {
                        string key = (x - i) + "," + (z + h);
                        rend = gridDictionary[(x - i) + "," + (z + h)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - h) + "," + (z + i)))
                    {
                        string key = (x - h) + "," + (z + i);
                        rend = gridDictionary[(x - h) + "," + (z + i)].getPlane().GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }
                }
            }

        }
        Debug.Log(position.ToString());
        Debug.Log("Items in list of options: " + listOfOptions.Count);
        return listOfOptions;
    }

    public List<GridObject> showRecruitOptions(string playerTurn)
    {
        List<GridObject> listOfOptions = new List<GridObject>();
        Renderer rend;
        if(playerTurn.Equals("PLAYER"))
        {
            listOfOptions = playerRecruitOptions;
            listOfOptions = checkOccupiedSpaces(playerRecruitOptions);
            foreach(GridObject obj in listOfOptions)
            {
                rend = obj.getPlane().GetComponent<Renderer>();
                rend.material.color = Color.cyan;
            }
        }
        else
        {
            listOfOptions = enemyRecruitOptions;
            listOfOptions = checkOccupiedSpaces(enemyRecruitOptions);
            foreach (GridObject obj in listOfOptions)
            {
                rend = obj.getPlane().GetComponent<Renderer>();
                rend.material.color = Color.cyan;
            }
        }

        return listOfOptions;
    }

    public List<GridObject> checkOccupiedSpaces(List<GridObject> listOfOptions)
    {
        for (int i = 0; i < listOfOptions.Count; i++)
        {
            if(listOfOptions[i].getOccupiedSoldier() != null)
            {
                listOfOptions.RemoveAt(i);
            }
        }

        return listOfOptions;
    }

    public void clearGrid()
    {
        foreach(KeyValuePair<string, GridObject> obj in gridDictionary)
        {
            Renderer rend;
            rend = obj.Value.getPlane().GetComponent<Renderer>();
            rend.material.color = Color.gray;
        }
    }

    public List<GridObject> getPlayerRecruitOptions()
    {
        return playerRecruitOptions;
    }

    public List<GridObject> getEnemyRecruitOptions()
    {
        return enemyRecruitOptions;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setGridDictionary(Dictionary<string, GridObject> gridDictionary)
    {
        this.gridDictionary = gridDictionary;
    }

    public Dictionary<string, GridObject> getGridDictionary()
    {
        return gridDictionary;
    }

    public void addSoldierToGrid(Vector3 position, GameObject recruit)
    {
        string square = position.x + "," + position.z;

        gridDictionary[square].setOccupiedSoldier(recruit);
    }

    public void liftSoldier(AbstractSoldier soldierToLift)
    {
        string square = soldierToLift.transform.position.x + "," + soldierToLift.transform.position.z;
        gridDictionary[square].setOccupiedSoldier(null);
    }

    public Dictionary<string, List<GridObject>> showAttackOption(GameObject soldierObject)
    {
        AbstractSoldier soldier = soldierObject.GetComponent<AbstractSoldier>();
        string soldierSquare = soldier.transform.position.x + "," + soldier.transform.position.z;
        GridObject occupiedSpace = gridDictionary[soldierSquare];
        Dictionary<string, List<GridObject>> listOfOptions = new Dictionary<string, List<GridObject>>();
        listOfOptions = highlightOptions(occupiedSpace, soldier.getAtkRange());
        return listOfOptions;
    }

    private Dictionary<string, List<GridObject>> highlightOptions(GridObject occupiedSpace, int atkRange)
    {
        Renderer rend;
        Dictionary<string, List<GridObject>> listOfOptions = new Dictionary<string, List<GridObject>>();
        List<GridObject> verticalOptions = new List<GridObject>();
        List<GridObject> horizontalOptions = new List<GridObject>();
        verticalOptions.Add(occupiedSpace);
        horizontalOptions.Add(occupiedSpace);
        Renderer mainRend = occupiedSpace.getPlane().GetComponent<Renderer>();
        mainRend.material.color = Color.black;
        GameObject plane = occupiedSpace.getPlane();
        float x = plane.transform.position.x;
        float z = plane.transform.position.z;

        for (int i = 1; i < atkRange + 1; i++)
        {
            if (gridDictionary.ContainsKey((x + i) + "," + (z)))
            {
                string key = (x + i) + "," + (z);
                rend = gridDictionary[(x + i) + "," + (z)].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.red;
                if (!horizontalOptions.Contains(gridDictionary[key]))
                {
                    horizontalOptions.Add(gridDictionary[key]);
                }
            }
            if (gridDictionary.ContainsKey((x - i) + "," + (z)))
            {
                string key = (x - i) + "," + (z);
                rend = gridDictionary[(x - i) + "," + (z)].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.red;
                if (!horizontalOptions.Contains(gridDictionary[key]))
                {
                    horizontalOptions.Add(gridDictionary[key]);

                }
            }
            if (gridDictionary.ContainsKey((x) + "," + (z + i)))
            {
                string key = (x) + "," + (z + i);
                rend = gridDictionary[(x) + "," + (z + i)].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.red;
                if (!verticalOptions.Contains(gridDictionary[key]))
                {
                    verticalOptions.Add(gridDictionary[key]);

                }
            }
            if (gridDictionary.ContainsKey((x) + "," + (z - i)))
            {
                string key = (x) + "," + (z - i);
                rend = gridDictionary[(x) + "," + (z - i)].getPlane().GetComponent<Renderer>();
                rend.material.color = Color.red;
                if (!verticalOptions.Contains(gridDictionary[key]))
                {
                    verticalOptions.Add(gridDictionary[key]);
                }
            }
        }
        
        listOfOptions.Add("horizontal", sortListOfOptions(horizontalOptions));
        listOfOptions.Add("vertical", sortVerticalList(verticalOptions));

        return listOfOptions;
    }

    private List<GridObject> sortListOfOptions(List<GridObject> listToBeSorted)
    {
        listToBeSorted.Sort((o1, o2) => o1.getPlane().name.CompareTo(o2.getPlane().name));
        return listToBeSorted;
    }

    private List<GridObject> sortVerticalList(List<GridObject> listToBeSorted)
    {
        listToBeSorted.Sort((o1, o2) => o1.getPlane().transform.position.z.CompareTo(o2.getPlane().transform.position.z));
        listToBeSorted.Reverse();
        return listToBeSorted;
    }
}
