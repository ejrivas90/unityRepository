using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {
    public Turn whosTurn;
    public List<HandleTurn> turnList = new List<HandleTurn>();
    public List<GameObject> playerSoldiers = new List<GameObject>();
    public List<GameObject> enemySoldiers = new List<GameObject>();
    public GameObject playerChampion;
    public GameObject enemyChampion;
    public PlayerStateMachine pStateMachine;
    public EnemyStateMachine eStateMachine;

    public enum Turn {
        PLAYER,
        ENEMY,
        PLAYER_RECRUIT,
        ENEMY_RECRUIT,
    }

    void Awake() {
        whosTurn = Turn.PLAYER;
        Debug.Log("Game Start. It is " + whosTurn + " turn");
    }
	void Start () {
        playerChampion = GameObject.FindGameObjectWithTag("playerChampion");
        pStateMachine = playerChampion.GetComponent<PlayerStateMachine>();
        if (playerChampion != null) {
            Debug.Log("There is 1 player champion on the field");
        }
        enemyChampion = GameObject.FindGameObjectWithTag("enemyChampion");
        eStateMachine = enemyChampion.GetComponent<EnemyStateMachine>();
        if (enemyChampion != null)
        {
            Debug.Log("There is 1 enemy champion on the field");
        }
        enemySoldiers.AddRange(GameObject.FindGameObjectsWithTag("enemyRecruit"));
        if (enemySoldiers != null)
        {
            Debug.Log("There is " + enemySoldiers.Count +  " enemy(s) on the field");
        }
        playerSoldiers.AddRange(GameObject.FindGameObjectsWithTag("playerRecruit"));
        if (playerSoldiers != null)
        {
            Debug.Log("There is " + playerSoldiers.Count + " enemy(s) on the field");
        }

    }
	
	// Update is called once per frame
	void Update () {
        updateScenePlayerEnemy();

	    switch (whosTurn)
        {
            case (Turn.PLAYER):
                pStateMachine.currentState = PlayerStateMachine.TurnState.BEGIN_TURN;
                eStateMachine.currentState = EnemyStateMachine.TurnState.WAIT;
                break;
            case (Turn.PLAYER_RECRUIT):
                break;
            case (Turn.ENEMY):
                eStateMachine.currentState = EnemyStateMachine.TurnState.BEGIN_TURN;
                pStateMachine.currentState = PlayerStateMachine.TurnState.WAIT;
                break;
            case (Turn.ENEMY_RECRUIT):
                break;
        }
	}

    void updateScenePlayerEnemy() {
      
    }
}
