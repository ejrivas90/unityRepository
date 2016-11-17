using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public enum Turn{PLAYER, ENEMY};
    public Turn whosTurn;
    public List<GameObject> playerSoldiers = new List<GameObject>();
    public List<GameObject> enemySoldiers = new List<GameObject>();
    public GameObject playerChampion;
    public GameObject enemyChampion;
    public PlayerChampionStateMachine pStateMachine;
    public EnemyStateMachine eStateMachine;

    void Awake()
    {
        whosTurn = Turn.PLAYER;
        Debug.Log("Game Start. It is " + whosTurn + " turn");
    }

    void Start()
    {
        initializePlayerChampion();
        playerChampion = GameObject.FindGameObjectWithTag("playerChampion");
        pStateMachine = playerChampion.GetComponent<PlayerChampionStateMachine>();
        if (playerChampion != null)
        {
            Debug.Log("There is 1 player champion on the field");
        }
        enemyChampion = GameObject.FindGameObjectWithTag("enemyChampion");
        eStateMachine = enemyChampion.GetComponent<EnemyStateMachine>();
        if (enemyChampion != null)
        {
            Debug.Log("There is 1 enemy champion on the field");
        }
        /*
        enemySoldiers.AddRange(GameObject.FindGameObjectsWithTag("enemyRecruit"));
        if (enemySoldiers != null)
        {
            Debug.Log("There is " + enemySoldiers.Count + " enemy(s) on the field");
        }
        playerSoldiers.AddRange(GameObject.FindGameObjectsWithTag("playerRecruit"));
        if (playerSoldiers != null)
        {
            Debug.Log("There is " + playerSoldiers.Count + " enemy(s) on the field");
        }
        */
        pStateMachine.beginTurn(playerChampion);
    }

    void initializePlayerChampion()
    {
        pStateMachine.init();
    }

    void Update()
    {
    }

    public void switchTurns()
    {
        switch (whosTurn)
        {
            case (Turn.PLAYER):
                whosTurn = Turn.ENEMY;
                pStateMachine.endTurn();
                eStateMachine.beginTurn();
                break;
            case (Turn.ENEMY):
                whosTurn = Turn.PLAYER;
                eStateMachine.endTurn();
                pStateMachine.beginTurn(playerChampion);
                break;
        }
    }
}
