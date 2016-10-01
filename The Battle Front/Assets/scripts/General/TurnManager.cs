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

    public enum Turn {
        PLAYER,
        ENEMY,
        PLAYER_RECRUIT,
        ENEMY_RECRUIT,
    }
	// Use this for initialization
	void Start () {
        whosTurn = Turn.PLAYER;
        playerChampion = GameObject.FindGameObjectWithTag("playerChampion");
        enemyChampion = GameObject.FindGameObjectWithTag("enemyChampion");
        enemySoldiers.AddRange(GameObject.FindGameObjectsWithTag("enemyRecruit"));
        playerSoldiers.AddRange(GameObject.FindGameObjectsWithTag("playerRecruit"));

    }
	
	// Update is called once per frame
	void Update () {
        updateScenePlayerEnemy();

	    switch (whosTurn)
        {
            case (Turn.PLAYER):
                break;
            case (Turn.PLAYER_RECRUIT):
                break;
            case (Turn.ENEMY):
                break;
            case (Turn.ENEMY_RECRUIT):
                break;
        }
	}

    void updateScenePlayerEnemy() {
        playerChampion = GameObject.FindGameObjectWithTag("playerChampion");
        enemyChampion = GameObject.FindGameObjectWithTag("enemyChampion");
        enemySoldiers.AddRange(GameObject.FindGameObjectsWithTag("enemyRecruit"));
        playerSoldiers.AddRange(GameObject.FindGameObjectsWithTag("playerRecruit"));
    }
}
