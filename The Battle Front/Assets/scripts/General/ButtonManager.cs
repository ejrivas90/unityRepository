using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject recruitPanel;
    public GameObject actionPanel;
    private GameObject rPanelActual;
    private GameObject aPanelActual;

	// Use this for initialization
	void Start () {
        //aPanelActual = Instantiate(actionPanel, transform.position, Quaternion.identity);
        //aPanelActual.transform.SetParent(GameObject.Find("Canvas").transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createRecruitPanel()
    {
        rPanelActual = Instantiate(recruitPanel, transform.position, Quaternion.identity);
    }
}
