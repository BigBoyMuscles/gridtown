using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a single space on the game board
// Refactored Square class to Tile. Might still be some loose references somewhere.
public class GameSpace : MonoBehaviour
{
    [SerializeField]
    private GamePiece occupant;
    [SerializeField]
    private Vector2 coordinates;

    private Board board;

    [Header("Shaders")]
    Renderer rend;
    private Shader standardTileShader;
    private Shader hoverTileShader;

    [Header("Neighbors")]
    // see if it's possible to place this array inside the adjacent squares
    // struct so we can call neighbors.north and instead of neighbors[0]
    public GameSpace[] neighbors;
    private GameSpace north;
    private GameSpace east;
    private GameSpace south;
    private GameSpace west;

    public bool isOdd = false;

    //Struct for sorting whether a tile has neightbors or not
    //Look into using this struct to hold all neighbor data so we can 
    public struct adjacentSquares
    {
        public bool north, east, south, west;

    }

    [SerializeField]
    public adjacentSquares hasNeighbor;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();

        board = transform.parent.GetComponent<Board>();

        //Square will start with 0.0 
        //This is the bottom left corner of our board


        // Needs to initialize and know its adjacent squares on the game board;
        setNeighbors();
        getNeighbors();

        neighbors = new GameSpace[4];
        neighbors[0] = north;
        neighbors[1] = east;
        neighbors[2] = south;
        neighbors[3] = west;



    }

    // Update is called once per frame
    void Update()
    {
        // Move tile to its physical space on the board. Offset to give space between tiles and center the board
        transform.position = new Vector3((coordinates.x * 1.125f) - (board.boardSize / 2), (coordinates.y * 1.125f) - (board.boardSize / 2), 0);

        //If the board is set to hex, offset the spaces. THis probably won't be used.
        if (board.isHex) {


            if (coordinates.x % 2 == 1)
            {
                transform.position += new Vector3(0, 0.25f, 0);
            } else
            {
                transform.position += new Vector3(0, -0.25f, 0);
            }

            // Move occupant pawn to the tile's new position
            if (occupant != null)
            {
                occupant.transform.position = transform.position;
            }
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
            hasNeighbor.west = false;
            hasNeighbor.east = true;
        }
        else if (coordinates.x == board.boardSize - 1)
        {
            hasNeighbor.east = false;
            hasNeighbor.west = true;
        }
        else
        {
            hasNeighbor.west = true;
            hasNeighbor.east = true;
        }

        //neighbor y
        if (coordinates.y == 0)
        {
            hasNeighbor.north = true;
            hasNeighbor.south = false;
        }
        else if (coordinates.y == board.boardSize - 1)
        {
            hasNeighbor.south = true;
            hasNeighbor.north = false;
        }
        else
        {
            hasNeighbor.north = true;
            hasNeighbor.south = true;
        }

    }

    //Get references to neighbor tiles
    private void getNeighbors()
    {
        if (hasNeighbor.north)
        {
            north = board.getTile(coordinates + Vector2.up);
        }

        if (hasNeighbor.east)
        {
            east = board.getTile(coordinates + Vector2.right);
        }

        if (hasNeighbor.south)
        {
            south = board.getTile(coordinates + Vector2.down);
        }

        if (hasNeighbor.west)
        {
            west = board.getTile(coordinates + Vector2.left);
        }
    }

    //Tell the tile which pawn is in its space
    public void setOccupant(GamePiece p)
    {
        occupant = p;
        p.setCoordinates(coordinates);
    }

    public GamePiece getOccupant()
    {
        if (isOccupied())
        {
            return occupant;
        }
        else return null;
        
    }
    
    public bool isOccupied()
    {
        if(occupant != null)
        {
            return true;
        }

        return false;
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

    public void recieveOccupant(GamePiece p)
    {
        occupant = p;
    }
}
