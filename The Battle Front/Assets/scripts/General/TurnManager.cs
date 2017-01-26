using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public enum Turn{PLAYER, ENEMY};
    public Turn whosTurn;
    public List<GameObject> playerSoldiers = new List<GameObject>();
    public List<GameObject> enemySoldiers = new List<GameObject>();
    public List<GameObject> currentSoldiers = new List<GameObject>();
    public GameObject playerChampion;
    public GameObject enemyChampion;
    public PlayerChampionStateMachine champStateMachine;
    public EnemyChampionStateMachine eStateMachine;
    public MoveAction moveAction;
    public PrefabScript prefab;
    public ButtonManager buttonManager;

    void Awake()
    {        
        moveAction = GameObject.Find("actionPanel").GetComponent<MoveAction>();
        prefab = GameObject.Find("prefabInstantiator").GetComponent<PrefabScript>();       
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
                foreach(GameObject gameObj in enemySoldiers)
                {
                    currentSoldiers.Add(gameObj);
                }
                moveAction.newTurn();
                break;
            case (Turn.ENEMY):
                whosTurn = Turn.PLAYER;
                eStateMachine.endTurn();
                champStateMachine.beginTurn(playerChampion);
                currentSoldiers.Clear();
                foreach (GameObject gameObj in playerSoldiers)
                {
                    string objectState = gameObj.GetComponent<AbstractSoldier>().getCurrentState().ToString();
                    currentSoldiers.Add(gameObj);
                }
                moveAction.newTurn();
                break;
        }
    }

    public void recruit(string recruitType)
    {
        Debug.Log("recruit was selected");
        prefab.setPrefabToMake(recruitType);
        prefab.setIsRecruiting(true);
        prefab.setActivePlayer(whosTurn.ToString());
        prefab.Update();
        GameObject recruit = prefab.getClone();
        if(recruit != null)
        {
            prefab.setPrefabToMake("");
            prefab.setIsRecruiting(false);
            currentSoldiers.Add(recruit);
            if(whosTurn.Equals(Turn.PLAYER))
            {
                playerSoldiers.Add(recruit);
            }
            else
            {
                enemySoldiers.Add(recruit);
            }
        }

    }
}