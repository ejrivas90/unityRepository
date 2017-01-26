using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitButton : MonoBehaviour {
    private TurnManager turnManager;
    private GameObject activeSoldier;
    private MoveAction moveAction; 

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        moveAction = GameObject.Find("actionPanel").GetComponent<MoveAction>();
    }

    public void waitAction()
    {
        for(int i = 0; i < turnManager.currentSoldiers.Count; i++ )
        {
            if(turnManager.currentSoldiers[i].GetComponent<AbstractSoldier>().getCurrentState().ToString().Equals("ACTIVE"))
            {
                turnManager.currentSoldiers[i].GetComponent<AbstractSoldier>().setCurrentState(AbstractSoldier.TurnState.WAIT);
                if (i + 1 > turnManager.currentSoldiers.Count)
                {
                    turnManager.currentSoldiers[i + 1].GetComponent<AbstractSoldier>().setCurrentState(AbstractSoldier.TurnState.ACTIVE);
                }
                else
                {
                    moveAction.buttonDisable(false);
                }
            }
        }
        if(activeSoldier != null)
        {
            Debug.Log("wait button worked");
            Debug.Log(activeSoldier.name + " is active");
            Debug.Log("there are " + turnManager.currentSoldiers.Count +" soldiers in the queue");
        }
    }
}
