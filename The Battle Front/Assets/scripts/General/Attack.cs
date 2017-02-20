using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject attackButton;
    private string whosTurn;
    private Grid grid;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        attackButton = GameObject.Find("Attack");
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    public void attackAction()
    {
        whosTurn = turnManager.whosTurn.ToString();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
