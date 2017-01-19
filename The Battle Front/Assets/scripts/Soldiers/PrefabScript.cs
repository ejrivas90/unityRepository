using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour {
    public GameObject tankPre;
    public GameObject artilleryPre;
    public GameObject infantryPre;
    public GameObject marksmanPre;
    GameObject tankClone;
    GameObject artClone;
    GameObject infClone;
    GameObject marksClone;
    private bool isRecruiting;

    void Update()
    {
        if(isRecruiting)
        {
            createArtClone();
            createInfClone();
            createMarkClone();
            createTankClone();
        }
    }

    public GameObject createTankClone()
    {
        tankClone = Instantiate(tankPre, transform.position, Quaternion.identity) as GameObject;
        return tankClone;
    }

    public GameObject createArtClone()
    {
        artClone = Instantiate(artilleryPre, transform.position, Quaternion.identity) as GameObject;
        return artClone;
    }

    public GameObject createInfClone()
    {
        infClone = Instantiate(infantryPre, transform.position, Quaternion.identity) as GameObject;
        return infClone;
    }

    public GameObject createMarkClone()
    {
        marksClone = Instantiate(marksmanPre, transform.position, Quaternion.identity) as GameObject;
        return marksClone;
    }

    public void setIsRecruiting(bool isRecruiting)
    {
        this.isRecruiting = isRecruiting;
    }

    public bool getIsRecruiting()
    {
        return isRecruiting;
    }
}
