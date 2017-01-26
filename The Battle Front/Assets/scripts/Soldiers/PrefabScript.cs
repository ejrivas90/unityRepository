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
    GameObject clone;
    private bool isRecruiting;
    private string prefabToMake;
    private string activePlayer;

    public void Update()
    {
        switch (prefabToMake)
        {
            case ("tank"):
                if (isRecruiting)
                {
                    clone = createTankClone();
                }
                break;
            case ("marksman"):
                if (isRecruiting)
                {
                    clone = createMarkClone();
                }
                break;
            case ("infantry"):
                if (isRecruiting)
                {
                    clone = createInfClone();
                }
                break;
            case ("artillery"):
                if (isRecruiting)
                {
                    clone = createArtClone();
                }
                break;
        }
     }

    public GameObject createTankClone()
    {
        Vector3 position;
        if (activePlayer.Equals("PLAYER"))
        {
            position = new Vector3(-1.5f, .38f, 6.5f);
        }
        else
        {
            position = new Vector3(1.5f, .38f, -6.5f);
        }
        
        tankClone = Instantiate(tankPre, position, Quaternion.identity) as GameObject;
        tankClone.GetComponent<Tank>().init(activePlayer.ToString());
        return tankClone;
    }

    public GameObject createArtClone()
    {
        Vector3 position;
        if (activePlayer.Equals("PLAYER"))
        {
            position = new Vector3(-.5f, .5f, 6.5f);
        }
        else
        {
            position = new Vector3(.5f, .5f, -6.5f);
        }
        artClone = Instantiate(artilleryPre, position, Quaternion.identity) as GameObject;
        artClone.GetComponent<Artillery>().init(activePlayer.ToString());
        return artClone;
    }

    public GameObject createInfClone()
    {
        Vector3 position;
        if (activePlayer.Equals("PLAYER"))
        {
            position = new Vector3(1.5f, .5f, 6.5f);
        }
        else
        {
            position = new Vector3(-1.5f, .5f, -6.5f);
        }
        infClone = Instantiate(infantryPre, position, Quaternion.identity) as GameObject;
        infClone.GetComponent<Infantry>().init(activePlayer.ToString());
        return infClone;
    }

    public GameObject createMarkClone()
    {
        Vector3 position;
        if (activePlayer.Equals("PLAYER"))
        {
            position = new Vector3(2.5f, .5f, 6.5f);
        }
        else
        {
            position = new Vector3(-2.5f, .5f, -6.5f);
        }
        marksClone = Instantiate(marksmanPre, position, Quaternion.identity) as GameObject;
        marksClone.GetComponent<Marksman>().init(activePlayer.ToString());
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

    public void setPrefabToMake(string prefabToMake)
    {
        this.prefabToMake = prefabToMake;
    }

    public string getPrefabToMake()
    {
        return prefabToMake;
    }

    public void setActivePlayer(string activePlayer)
    {
        this.activePlayer = activePlayer;
    }

    public string getActivePlayer()
    {
        return activePlayer;
    }

    public GameObject getClone()
    {
        return clone;
    }
}
