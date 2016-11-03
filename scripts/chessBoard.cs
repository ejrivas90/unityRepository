using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    private Material[] materials;
    private Renderer rend;
    public GameObject plane;
    public int width = 10;
    public int height = 10;
    private GameObject[,] grid = new GameObject[10, 10];
	
    void Awake()
    {
        for(int i = 0; i < width; i++)
        {
            for(int h = 0; h < height; h++ )
            {
                GameObject gridPlane = (GameObject)Instantiate(plane);
                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + i,
                    gridPlane.transform.position.y, gridPlane.transform.position.z + h);
                gridPlane.name = "square: " + i + "," + h;
                grid[i, h] = gridPlane;
            }
        }
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 150, 100), "show options"))
        {
            showMoveOption(grid[4, 5].transform.position, 3);
        }
    }

    void showMoveOption(Vector3 position, int points)
    {
        Renderer rend;
        Renderer rend2;
        Renderer rend3;
        Renderer rend4;
        Renderer rend5;
        Renderer rend6;
        Renderer mainRend = grid[(int)position.x, (int)position.z].GetComponent<Renderer>();
        mainRend.material.color = Color.black;
        int xCord = (int)position.x;
        int zCord = (int)position.z;
        for (int i = 0; i < points + 1; i++)
        {
            for(int h = 1; h < points + 1; h++)
            {
                
                if((i+h != (points+1)) && (i+h < (points+1))) 
                {
                    Debug.Log("painted: " + (xCord + i) + ", " + (zCord + h));
                    Debug.Log(i + ", " + h);
                    rend = grid[xCord + i, zCord + h].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend2 = grid[xCord + h, zCord + i].GetComponent<Renderer>();
                    rend2.material.color = Color.red;

                    rend3 = grid[xCord - i, zCord - h].GetComponent<Renderer>();
                    rend3.material.color = Color.red;

                    rend5 = grid[xCord + i, zCord - h].GetComponent<Renderer>();
                    rend5.material.color = Color.red;

                    rend6 = grid[xCord + h, zCord - i].GetComponent<Renderer>();
                    rend6.material.color = Color.red;

                    rend5 = grid[xCord - i, zCord + h].GetComponent<Renderer>();
                    rend5.material.color = Color.red;

                    rend6 = grid[xCord - h, zCord + i].GetComponent<Renderer>();
                    rend6.material.color = Color.red;
                }
            }
            
        }

        Debug.Log(position.ToString());
    }
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
