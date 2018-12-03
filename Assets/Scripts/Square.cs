using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a single space on the game board

public class Square : MonoBehaviour
{
    [SerializeField]
    private Pawn occupant;
    [SerializeField]
    private Vector2 coordinates;
    [SerializeField]
    private string title = "empty";

    [Header("Shaders")]
    Renderer rend;
    private Shader standardTileShader;
    private Shader hoverTileShader;

    //Adjacent Squares
    public struct adjacentSquares
    {
        public bool north, east, south, west;

    }

    private adjacentSquares neighbors;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        standardTileShader = Shader.Find("StandardTileShader");
        hoverTileShader = Shader.Find("HoverTileShader");

        //Square will start with 0.0 
        //This is the top left corner of our board
      

        // Needs to initialize and know it's adjacent squares on the game board;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((coordinates.x * 1.125f) - 4, (coordinates.y * 1.125f) - 4, 0);
        if(occupant != null)
        {
            occupant.transform.position = transform.position;
        }
    }

    private void OnMouseEnter()
    {
        rend.material.shader = hoverTileShader;
    }

    private void OnMouseExit()
    {
        rend.material.shader = standardTileShader;
    }

    public void setCoordinates(Vector2 newCoords)
    {
        coordinates = newCoords;
    }

    public Vector2 getCoordinates()
    {
        return coordinates;
    }

    public override string ToString()
    {
        return coordinates.ToString();
    }

    public void setTitle(string t)
    {
        title = t;
    }

    public void writeTitle()
    {
        Debug.Log(title);
    }

    private void setNeighbors()
    {
        //neighbor X
        
        if (coordinates.x == 0)
        {
            neighbors.west = false;
        } else if(coordinates.x == 7)
        {
            neighbors.east = false;
        } else
        {
            neighbors.west = true;
            neighbors.east = true;
        }

        if (coordinates.y == 0)
        {
            neighbors.north = false;
        }
        else if (coordinates.y == 7)
        {
            neighbors.south = false;
        }
        else
        {
            neighbors.north = true;
            neighbors.south = true;
        }

    }

    public void setOccupant(Pawn p)
    {
        occupant = p;
    }
}
