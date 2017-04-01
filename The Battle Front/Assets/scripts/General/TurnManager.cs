﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class TurnManager : MonoBehaviour
{
    public enum Turn{PLAYER, ENEMY};
    public Turn whosTurn;
    public List<GameObject> playerSoldiers = new List<GameObject>();
    public List<GameObject> enemySoldiers = new List<GameObject>();
    public List<GameObject> currentSoldiers = new List<GameObject>();
    public GameObject playerChampion;
    public GameObject enemyChampion;
    public GameObject attackButton;
    public PlayerChampionStateMachine champStateMachine;
    public EnemyChampionStateMachine eStateMachine;
    public MoveAction moveAction;
    public PrefabScript prefab;
    public ButtonManager buttonManager;
    public Grid grid;
    public bool isShowingRecruitOptions;
    private int i;

    void Awake()
    {        
        moveAction = GameObject.Find("actionPanel").GetComponent<MoveAction>();
        prefab = GameObject.Find("prefabInstantiator").GetComponent<PrefabScript>();
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        attackButton = GameObject.Find("AttackButton");
    }

    void Start()
    {
        whosTurn = Turn.PLAYER;
        initializePlayerField();
        initializeEnemyField();
        moveAction.newTurn();
        Debug.Log("Game Start. It is " + whosTurn + " turn");
    }

    void initializePlayerField()
    {
        playerChampion = GameObject.FindGameObjectWithTag("playerChampion");
        if (playerChampion != null)
        {
            Debug.Log("There is 1 player champion on the field");
            champStateMachine = playerChampion.GetComponent<PlayerChampionStateMachine>();
            champStateMachine.init();
            champStateMachine.setCurrentState(PlayerChampionStateMachine.TurnState.ACTIVE);
            playerSoldiers.Add(playerChampion);
            currentSoldiers.Add(playerChampion);
            champStateMachine.beginTurn(playerChampion);
            grid.addSoldierToGrid(playerChampion.transform.position, playerChampion);
        }   
    }

    public void initializeEnemyField()
    {
        enemyChampion = GameObject.FindGameObjectWithTag("enemyChampion");
        
        if (enemyChampion != null)
        {
            Debug.Log("There is 1 enemy champion on the field");
            eStateMachine = enemyChampion.GetComponent<EnemyChampionStateMachine>();
            eStateMachine.init();
            enemySoldiers.Add(enemyChampion);
            grid.addSoldierToGrid(enemyChampion.transform.position, enemyChampion);
        }
    }

    public void switchTurns()
    {
        switch (whosTurn)
        {
            case (Turn.PLAYER):
                isShowingRecruitOptions = false;
                whosTurn = Turn.ENEMY;
                champStateMachine.endTurn();
                eStateMachine.beginTurn(enemyChampion);
                currentSoldiers.Clear();
                foreach(GameObject gameObj in enemySoldiers)
                {
                    currentSoldiers.Add(gameObj);
                }
                attackButton.SetActive(true);
                GameObject.Find("actionPanel").GetComponent<Attack>().resetButton();
                moveAction.newTurn();
                break;
            case (Turn.ENEMY):
                isShowingRecruitOptions = false;
                whosTurn = Turn.PLAYER;
                eStateMachine.endTurn();
                champStateMachine.beginTurn(playerChampion);
                currentSoldiers.Clear();
                foreach (GameObject gameObj in playerSoldiers)
                {
                    string objectState = gameObj.GetComponent<AbstractSoldier>().getCurrentState().ToString();
                    currentSoldiers.Add(gameObj);
                }
                attackButton.SetActive(true);
                GameObject.Find("actionPanel").GetComponent<Attack>().resetButton();
                moveAction.newTurn();
                break;
        }
    }

    public void recruit(string recruitType)
    {
        Debug.Log("recruit was selected");
        i = 5;
        prefab.setPrefabToMake(recruitType);
        prefab.setActivePlayer(whosTurn.ToString());
        showRecruitOptions(whosTurn.ToString());
    }
    
    private void recruitOnSelection(Vector3 recruitPos)
    {
        prefab.setRecruitPosition(recruitPos);
        prefab.setIsRecruiting(true);
        prefab.Update();
        GameObject recruit = prefab.getClone();
        if (recruit != null)
        {
            prefab.setPrefabToMake("");
            prefab.setIsRecruiting(false);
            currentSoldiers.Add(recruit);
            grid.addSoldierToGrid(recruitPos, recruit);
            if (whosTurn.Equals(Turn.PLAYER))
            {
                playerSoldiers.Add(recruit);
            }
            else
            {
                enemySoldiers.Add(recruit);
            }
        }
        isShowingRecruitOptions = false;
    }

    private void showRecruitOptions(string whosTurn)
    {
        isShowingRecruitOptions = false;
        grid.clearGrid();
        grid.showRecruitOptions(whosTurn.ToString());
        isShowingRecruitOptions = true;
    }

    private void Update()
    {
        if(isShowingRecruitOptions)
        {
            List<GridObject> listOfOptions = new List<GridObject>();
            Vector3 position = new Vector3();
            Renderer rend;
            if (whosTurn.ToString().Equals("PLAYER"))
            {
                listOfOptions = grid.getPlayerRecruitOptions();
                
            }
            else
            {
                listOfOptions = grid.getEnemyRecruitOptions();
            }

            rend = listOfOptions[i].getPlane().GetComponent<Renderer>();
            rend.material.color = Color.green;

            if (Input.GetKeyDown("left"))
            {
                if (i != 0)
                {
                    i += -1;
                    rend.material.color = Color.cyan;
                    //Collider[] collider = Physics.OverlapSphere(listOfOptions[i].transform.position, .1f);                
                    rend = listOfOptions[i].getPlane().GetComponent<Renderer>();
                    rend.material.color = Color.green;
                }
            }
            if (Input.GetKeyDown("right"))
            {
                if (i < listOfOptions.Count-1)
                {
                    i += 1;
                    rend.material.color = Color.cyan;
                    rend = listOfOptions[i].getPlane().GetComponent<Renderer>();
                    //Collider[] collider = Physics.OverlapSphere(listOfOptions[i].transform.position, .1f);
                    rend.material.color = Color.green;
                }
            }
            if (Input.GetButtonDown("Submit"))
            {
                position = listOfOptions[i].getSquarePosition();
                recruitOnSelection(position);
                isShowingRecruitOptions = false;
                grid.clearGrid();
            }
            if(Input.GetButtonDown("Cancel"))
            {
                isShowingRecruitOptions = false;
                grid.clearGrid();
                rend.material.color = Color.gray;
                i = 0;
            }
        }
    }

}