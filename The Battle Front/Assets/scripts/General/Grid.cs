﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public GameObject plane;
    public float width = 14;
    public float height = 16;
    private GameObject[,] grid = new GameObject[14, 16];
    private Dictionary<string, GameObject> gridDictionary = new Dictionary<string, GameObject>();
    private List<GameObject> playerRecruitOptions = new List<GameObject>();
    private List<GameObject> enemyRecruitOptions = new List<GameObject>();

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
                if(checkBasePosition(gridPlane.transform.position))
                {
                    gridPlane.name = "square: " + i + "," + h;
                    grid[i, h] = gridPlane;
                    string coords = grid[i, h].transform.position.x + "," + grid[i, h].transform.position.z;
                    gridDictionary.Add(coords, grid[i, h]);
                }
                else
                {
                    Destroy(gridPlane);
                }
            }
        }
        addToPlayerRecruitList();
        addToEnemyRecruitList();
        clearGrid();
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

    public Dictionary<string, GameObject> showMoveOption(Vector3 position, int points)
    {
        Renderer rend;
        Dictionary<string, GameObject> listOfOptions = new Dictionary<string, GameObject>();
        string squarePosition = position.x + "," + position.z;
        listOfOptions.Add(squarePosition, gridDictionary[squarePosition]);
        float x = position.x;
        float z = position.z;
        GameObject square = gridDictionary[squarePosition];   
        Renderer mainRend = square.GetComponent<Renderer>();
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
                        rend = gridDictionary[key].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if(!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                        
                    }
                    if (gridDictionary.ContainsKey((x + h) + "," + (z + i)))
                    {
                        string key = (x + h) + "," + (z + i);
                        rend = gridDictionary[(x + h) + "," + (z + i)].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - i) + "," + (z - h)))
                    {
                        string key = (x - i) + "," + (z - h);
                        rend = gridDictionary[(x - i) + "," + (z - h)].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x + i) + "," + (z - h)))
                    {
                        string key = (x + i) + "," + (z - h);
                        rend = gridDictionary[(x + i) + "," + (z - h)].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x + h) + "," + (z - i)))
                    {
                        string key = (x + h) + "," + (z - i);
                        rend = gridDictionary[(x + h) + "," + (z - i)].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - i) + "," + (z + h)))
                    {
                        string key = (x - i) + "," + (z + h);
                        rend = gridDictionary[(x - i) + "," + (z + h)].GetComponent<Renderer>();
                        rend.material.color = Color.red;
                        if (!listOfOptions.ContainsKey(key))
                        {
                            listOfOptions.Add(key, gridDictionary[key]);
                        }
                    }

                    if (gridDictionary.ContainsKey((x - h) + "," + (z + i)))
                    {
                        string key = (x - h) + "," + (z + i);
                        rend = gridDictionary[(x - h) + "," + (z + i)].GetComponent<Renderer>();
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

    public List<GameObject> showRecruitOptions(string playerTurn)
    {
        List<GameObject> listOfOptions = new List<GameObject>();
        Renderer rend;
        if(playerTurn.Equals("PLAYER"))
        {
            listOfOptions = playerRecruitOptions;
            foreach(GameObject obj in listOfOptions)
            {
                rend = obj.GetComponent<Renderer>();
                rend.material.color = Color.cyan;
            }
        }
        else
        {
            listOfOptions = enemyRecruitOptions;
            foreach (GameObject obj in listOfOptions)
            {
                rend = obj.GetComponent<Renderer>();
                rend.material.color = Color.cyan;
            }
        }

        return listOfOptions;
    }

    public void clearGrid()
    {
        foreach(KeyValuePair<string,GameObject> obj in gridDictionary)
        {
            Renderer rend;
            rend = obj.Value.GetComponent<Renderer>();
            rend.material.color = Color.gray;
        }
    }

    public List<GameObject> getPlayerRecruitOptions()
    {
        return playerRecruitOptions;
    }

    public List<GameObject> getEnemyRecruitOptions()
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
}
