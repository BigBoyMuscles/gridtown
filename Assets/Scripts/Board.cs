using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    [SerializeField]
    private GameSpace[,] gameBoard;

    [Header("Tile Info")]
    public GameSpace baseGameSpace;         // The board's default tile prefab
    private GameSpace hoveredGameSpace;     // Holds a reference to a tile when the mouse is hovering above it
    private GameSpace selectedGameSpace;    // Holds a reference to a tile when it is clicked on

    // Shaders used to inidcate a tile's selection status
    [Header("Title Shaders")]
    private Shader standardTileShader;
    private Shader hoverTileShader;
    private Shader neighborTileShader;


    [Header("Pawn Info")]
    public GamePiece basePawn;
    public GamePiece rook;
    // A list of all the pawns in the game. Currently unused.
    public GamePiece[] pawns = new GamePiece[1];
   
    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {

        // Get references to our shaders
        standardTileShader = Shader.Find("StandardTileShader");
        hoverTileShader = Shader.Find("HoverTileShader");
        neighborTileShader = Shader.Find("NeighborFileShader");

        /**
         * The board will be created, starting with (0,0) in the bottom left corner
         * and increasing tp (7, 7) in the top right corner.
         * 
         * **/

        //Create an 8x8 playing field
        gameBoard = new GameSpace[8,8];
       
        //iterate X
        for (int x = 0; x < gameBoard.GetLength(0); x++){

            //iterate y
            for (int y =0; y < gameBoard.GetLength(1); y++)
            {
                //Make each square of our gameboard an empty square object
                gameBoard[x, y] = GameObject.Instantiate(baseGameSpace);

                // Give each square a name in the editor (Name will be griid coordinates for ease of use)
                gameBoard[x, y].name = "(" + x + "," + y + ")";

                // Make each new square a child of the board
                gameBoard[x, y].transform.SetParent(gameObject.transform);

                //Make sure the new square's coordinate match its position on the board
                gameBoard[x,y].setCoordinates(new Vector2(x,y));
                                                
            }
        }



        /**
         *  Now we must place our pawn onto the board.
         *  Eventually this will be more sophisticated and allow for
         *  multiple pawns for each player to be placed randomly
         *  on the board at the beginning of the game
         **/
        
        GamePiece p = GameObject.Instantiate(basePawn);
        GamePiece p1 = GameObject.Instantiate(basePawn);
        GamePiece p2 = GameObject.Instantiate(basePawn);
        GamePiece p3 = GameObject.Instantiate(rook);
        p.transform.parent = gameObject.transform;
        p1.transform.parent = gameObject.transform;
        p2.transform.parent = gameObject.transform;
        p3.transform.parent = gameObject.transform;
        gameBoard[4,4].setOccupant(p);
        gameBoard[3, 3].setOccupant(p1);
        gameBoard[5, 3].setOccupant(p2);
        gameBoard[4, 2].setOccupant(p3);

    }
	
	// Update is called once per frame
	void Update () {

	}

    // Called when the mouse enters a tile's collision box
    public void hoverTile(Vector2 coords)
    {
        hoveredGameSpace = gameBoard[(int)coords.x, (int)coords.y];
        hoveredGameSpace.setTileShader(hoverTileShader);
        highlightNeighbors();
    }

    // Called when the mouse leaves a tile's collision box
    public void clearHoverTile()
    {
        hoveredGameSpace.setTileShader(standardTileShader);
        clearNeighborHightlight();
        hoveredGameSpace = null;
    }

    // Called when a tile is clicked on
    public void selectTile(Vector2 coords)
    {
        selectedGameSpace = gameBoard[(int)coords.x, (int)coords.y];

        Debug.Log("Selected Tile: " + coords);

        foreach(GameSpace g in selectedGameSpace.neighbors)
        {
            Vector2 direction = new Vector2(0, 0);

            // If the tile exists
            if(g != null)
            {
                // Get the direction of the tile relative to the selected tile (North/South/East/West)
                direction = g.getCoordinates() - coords;

                // Then, if the tile contains a pawn
                if (g.isOccupied())
                {
                    // Move that pawn directly away from the selected tile
                    Debug.Log("Try to move that pawn");
                    g.getOccupant().moveGamePiece(direction);
                }
            }
            
            

        }

        
    }

    // Called when we need to access a specific tile from the game board array
    public GameSpace getTile(Vector2 coords)
    {
        return gameBoard[(int)coords.x, (int)coords.y];
    }

    // Applies a shader to highligh tiles adjacent to tile mouse is hovering above
    public void highlightNeighbors()
    {
        if(hoveredGameSpace.hasNeighbor.north)
        {
            hoveredGameSpace.neighbors[0].setTileShader(neighborTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.east)
        {
            hoveredGameSpace.neighbors[1].setTileShader(neighborTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.south)
        {
            hoveredGameSpace.neighbors[2].setTileShader(neighborTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.west)
        {
            hoveredGameSpace.neighbors[3].setTileShader(neighborTileShader);
        }
    }

    // Replaces neighbor highlight shader with standard tile shader when tile is no longer hovered over
    public void clearNeighborHightlight()
    {
        if (hoveredGameSpace.hasNeighbor.north)
        {
            hoveredGameSpace.neighbors[0].setTileShader(standardTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.east)
        {
            hoveredGameSpace.neighbors[1].setTileShader(standardTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.south)
        {
            hoveredGameSpace.neighbors[2].setTileShader(standardTileShader);
        }
        if (hoveredGameSpace.hasNeighbor.west)
        {
            hoveredGameSpace.neighbors[3].setTileShader(standardTileShader);
        }
    }

}
