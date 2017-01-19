using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public enum Turn{PLAYER, ENEMY};
    public Turn whosTurn;
    public Dictionary<string, GameObject> playerSoldiers = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> enemySoldiers = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> currentSoldiers = new Dictionary<string, GameObject>();
    public GameObject playerChampion;
    public GameObject enemyChampion;
    public PlayerChampionStateMachine champStateMachine;
    public EnemyChampionStateMachine eStateMachine;
    public MoveAction moveAction;
    public PrefabScript prefab;

    void Awake()
    {
        whosTurn = Turn.PLAYER;
        Debug.Log("Game Start. It is " + whosTurn + " turn");
    }

    void Start()
    {
        moveAction = GameObject.Find("Canvas").GetComponent<MoveAction>();
        prefab = GameObject.Find("prefabInstantiator").GetComponent<PrefabScript>();
        initializePlayerField();
        initializeEnemyField();
        champStateMachine.beginTurn(playerChampion);
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
            playerSoldiers.Add("playerChamp", playerChampion);
            currentSoldiers.Add("ACTIVE", playerChampion);
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
            enemySoldiers.Add("enemyChamp", enemyChampion);
        }
    }

    private void Update()
    {
    }

    public void switchTurns()
    {
        switch (whosTurn)
        {
            case (Turn.PLAYER):
                whosTurn = Turn.ENEMY;
                champStateMachine.endTurn();
                eStateMachine.beginTurn(enemyChampion);
                currentSoldiers.Clear();
                foreach(KeyValuePair<string, GameObject> kvp in enemySoldiers)
                {
                    string objectState = kvp.Value.GetComponent<EnemyChampionStateMachine>().getCurrentState().ToString();
                    currentSoldiers.Add(objectState, kvp.Value);
                }
                moveAction.newTurn();
                break;
            case (Turn.ENEMY):
                whosTurn = Turn.PLAYER;
                eStateMachine.endTurn();
                champStateMachine.beginTurn(playerChampion);
                currentSoldiers.Clear();
                foreach (KeyValuePair<string, GameObject> kvp in playerSoldiers)
                {
                    string objectState = kvp.Value.GetComponent<PlayerChampionStateMachine>().getCurrentState().ToString();
                    currentSoldiers.Add(objectState, kvp.Value);
                }
                moveAction.newTurn();
                break;
        }
    }

    public void recruit()
    {
        Debug.Log("recruit was selected");
        GameObject test = prefab.createTankClone();

    }
}