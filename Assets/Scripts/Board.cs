using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public bool isHex = false;

    [SerializeField]
    private GameSpace[,] gameBoard;
    public int boardSize = 8;

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
    //This pawn drawer will replace basePawn/rook etc. We will get that info from the drawer;
    //The drawer will also determin wh
    public PawnDrawer pawnDrawer;
    public GamePiece basePawn;
    public GamePiece rook;

    // A list of all the pawns in the game. Currently unused.
    public GamePiece[] pawns = new GamePiece[1];

    public GameState game;
   
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
        gameBoard = new GameSpace[boardSize,boardSize];
       
        //iterate X
        for (int x = 0; x < gameBoard.GetLength(0); x++){

            //iterate y
            for (int y =0; y < gameBoard.GetLength(1); y++)
            {
                //Make each square of our gameboard an empty square object
                gameBoard[x, y] = GameObject.Instantiate(baseGameSpace);

                // Give each square a name in the editor (Name will be grid coordinates for ease of use)
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

        
        placePawn(4, 4, rook);
        placePawn(3, 3, basePawn);
        placePawn(5, 3, basePawn);
        placePawn(4, 2, basePawn);

    }
	
	// Update is called once per frame
	void Update () {

	}

    // Called when the mouse enters a tile's collision box
    public void hoverTile(Vector2 coords)
    {
        hoveredGameSpace = gameBoard[(int)coords.x, (int)coords.y];
        hoveredGameSpace.setTileShader(hoverTileShader);
        //highlightNeighbors();
    }

    // Called when the mouse leaves a tile's collision box
    public void clearHoverTile()
    {
        hoveredGameSpace.setTileShader(standardTileShader);
        //clearNeighborHightlight();
        hoveredGameSpace = null;
    }

    // Called when a tile is clicked on
    public void selectTile(Vector2 coords)
    {
        selectedGameSpace = getTile(coords);

        Debug.Log("Selected Tile: " + coords);

        game.setSelectedGameSpace(selectedGameSpace);

    }

    // Called when we need to access a specific tile from the game board array
    public GameSpace getTile(Vector2 coords)
    {

        int length = boardSize - 1;

        if(coords.x > length || coords.x < 0 || coords.y > length || coords.y < 0)
        {
            return null;
        }

        return gameBoard[(int)coords.x, (int)coords.y];
    }

    public GameSpace getTile(int x, int y)
    {

        int length = boardSize - 1;

        if (x > length || x < 0 || y > length || y < 0)
        {
            return null;
        }

        return gameBoard[x, y];
    }

    public GameSpace[] getRow(int y)
    {
        GameSpace[] row = new GameSpace[boardSize];

        for(int x = 0; x < row.Length; x++)
        {
            row[x] = getTile(x, y);
        }

        return row;
    } 

    public void highlightGameSpace(GameSpace s)
    {
        s.setTileShader(hoverTileShader);
    }

    public void highlightGameSpace(GameSpace[] spaces)
    {
        foreach(GameSpace s in spaces)
        {
            s.setTileShader(hoverTileShader);
        }
    }

    public void dimGameSpace(GameSpace[] spaces)
    {
        foreach (GameSpace s in spaces)
        {
            s.setTileShader(standardTileShader);
        }
    }

    public void dimGameSpace(GameSpace s)
    {
        s.setTileShader(standardTileShader);
    }

    //// Applies a shader to highligh tiles adjacent to tile mouse is hovering above
    //public void highlightNeighbors()
    //{
    //    if(hoveredGameSpace.hasNeighbor.north)
    //    {
    //        hoveredGameSpace.neighbors[0].setTileShader(neighborTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.east)
    //    {
    //        hoveredGameSpace.neighbors[1].setTileShader(neighborTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.south)
    //    {
    //        hoveredGameSpace.neighbors[2].setTileShader(neighborTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.west)
    //    {
    //        hoveredGameSpace.neighbors[3].setTileShader(neighborTileShader);
    //    }
    //}

    // Replaces neighbor highlight shader with standard tile shader when tile is no longer hovered over
    //public void clearNeighborHightlight()
    //{
    //    if (hoveredGameSpace.hasNeighbor.north)
    //    {
    //        hoveredGameSpace.neighbors[0].setTileShader(standardTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.east)
    //    {
    //        hoveredGameSpace.neighbors[1].setTileShader(standardTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.south)
    //    {
    //        hoveredGameSpace.neighbors[2].setTileShader(standardTileShader);
    //    }
    //    if (hoveredGameSpace.hasNeighbor.west)
    //    {
    //        hoveredGameSpace.neighbors[3].setTileShader(standardTileShader);
    //    }
    //}

    public void placePawn(Vector2 coords, GamePiece t)
    {
        GamePiece p = GameObject.Instantiate(t);
        p.transform.parent = gameObject.transform;
        gameBoard[(int)coords.x, (int)coords.y].setOccupant(p);
    }

    public void placePawn(int x, int y, GamePiece t)
    {
        GamePiece p = GameObject.Instantiate(t);
        p.transform.parent = gameObject.transform;
        gameBoard[x, y].setOccupant(p);
    }

}
