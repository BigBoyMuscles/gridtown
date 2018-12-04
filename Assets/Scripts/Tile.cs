using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a single space on the game board
// I'm too lazy to do it now but this should probably renamed to Tile. Makes more sense that way.
public class Tile : MonoBehaviour
{
    [SerializeField]
    private Pawn occupant;
    [SerializeField]
    private Vector2 coordinates;

    private Board board;

    [Header("Shaders")]
    Renderer rend;
    private Shader standardTileShader;
    private Shader hoverTileShader;

    [Header("Neighbors")]
    public Tile north;
    public Tile east;
    public Tile south;
    public Tile west;

    //Struct for sotring whether a tile has neightbors or not
    public struct adjacentSquares
    {
        public bool north, east, south, west;

    }

    [SerializeField]
    public adjacentSquares neighbors;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();

        board = transform.parent.GetComponent<Board>();

        //Square will start with 0.0 
        //This is the bottom left corner of our board


        // Needs to initialize and know it's adjacent squares on the game board;
        setNeighbors();
        getNeighbors();
    }

    // Update is called once per frame
    void Update()
    {
        // Move tile to its physical space on the board. Offset to give space between tiles and center the board
        transform.position = new Vector3((coordinates.x * 1.125f) - 4, (coordinates.y * 1.125f) - 4, 0);

        // Move occupant pawn to the tile's new position
        if(occupant != null)
        {
            occupant.transform.position = transform.position;
        }
    }

    private void OnMouseEnter()
    {
        board.hoverTile(coordinates); 
    }

    private void OnMouseDown()
    {
        board.selectTile(coordinates);
    }

    private void OnMouseExit()
    {
        board.clearHoverTile();
    }

    // Change tile's coordinates
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

        //neighbor y
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

    //Get references to neighbor tiles
    private void getNeighbors()
    {
        if(neighbors.north)
        {
            north = board.getTile(coordinates + Vector2.up);
        }
        if (neighbors.east)
        {
            east = board.getTile(coordinates + Vector2.right);
        }
        if (neighbors.south)
        {
            south= board.getTile(coordinates + Vector2.down);
        }
        if (neighbors.west)
        {
            west = board.getTile(coordinates + Vector2.left);
        }
    }

    //Tell the tile which pawn is in its space
    public void setOccupant(Pawn p)
    {
        occupant = p;
        p.updateCoordinates(coordinates);
    }

    //Change the tile's shader, mostly for highlighting tiles
    public void setTileShader(Shader s)
    {
        rend.material.shader = s;
    }

    public void passOccupant()
    {
        occupant = null;
    }

    public  void recieveOccupant(Pawn p)
    {
        occupant = p;
    }
}
