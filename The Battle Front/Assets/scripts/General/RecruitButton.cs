using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitButton : MonoBehaviour {
    private TurnManager turnManager;

    private void Awake()
    {
        
    }

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();

    }
    
	public void recruitAction()
    {
        createSubmenu();
    }

    private void createSubmenu()
    {

    }

    public void recTank()
    {
        turnManager.recruit("tank");
    }

    public void recArt()
    {
        turnManager.recruit("artillery");
    }

    public void recInf()
    {
        turnManager.recruit("infantry");
    }

    public void recMark()
    {
        turnManager.recruit("marksman");
    }

}
