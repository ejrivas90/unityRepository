using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    private Renderer rend;
    public GameObject plane;
    public int width = 14;
    public int height = 16;
    private GameObject[,] grid = new GameObject[14, 16];

    void Awake()
    {
        Debug.Log("Grid initialized");
        for (int i = 0; i < width; i++)
        {
            for (int h = 0; h < height; h++)
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
        if (GUI.Button(new Rect(10, 10, 150, 100), "show options"))
        {
            showMoveOption(grid[4, 5].transform.position, 3);
        }
    }

    void showMoveOption(Vector3 position, int points)
    {
        Renderer rend;
        Renderer mainRend = grid[(int)position.x, (int)position.z].GetComponent<Renderer>();
        mainRend.material.color = Color.black;
        int xCord = (int)position.x;
        int zCord = (int)position.z;
        for (int i = 0; i < points + 1; i++)
        {
            for (int h = 1; h < points + 1; h++)
            {

                if ((i + h != (points + 1)) && (i + h < (points + 1)))
                {
                    Debug.Log("painted: " + (xCord + i) + ", " + (zCord + h));
                    Debug.Log(i + ", " + h);
                    rend = grid[xCord + i, zCord + h].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord + h, zCord + i].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord - i, zCord - h].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord + i, zCord - h].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord + h, zCord - i].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord - i, zCord + h].GetComponent<Renderer>();
                    rend.material.color = Color.red;

                    rend = grid[xCord - h, zCord + i].GetComponent<Renderer>();
                    rend.material.color = Color.red;
                }
            }

        }

        Debug.Log(position.ToString());
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
