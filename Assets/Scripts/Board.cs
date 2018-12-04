using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    [SerializeField]
    private Tile[,] squares;

    [Header("Tile Info")]
    public Tile baseSquare;
    private Tile hoveredTile;
    private Tile selectedTile;
    [Header("Title Shaders")]
    private Shader standardTileShader;
    private Shader hoverTileShader;
    private Shader neighborTileShader;

    //Needed: List of pawns to place onto the board at initialization
    //Will use a single pawn for now.
    [Header("Pawn Info")]
    public Pawn basePawn;
    public Pawn[] pawns = new Pawn[1];

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
        squares = new Tile[8,8];
       
        //iterate X
        for (int x = 0; x < squares.GetLength(0); x++){

            //iterate y
            for (int y =0; y < squares.GetLength(1); y++)
            {
                //Make each square of our gameboard an empty square object
                squares[x, y] = GameObject.Instantiate(baseSquare);

                // Give each square a name in the editor (Name will be griid coordinates for ease of use)
                squares[x, y].name = "(" + x + "," + y + ")";

                // Make each new square a child of the board
                //squares[x,y].transform.parent = gameObject.transform;
                squares[x, y].transform.SetParent(gameObject.transform);

                //Make sure the new square's coordinate match its position on the board
                squares[x,y].setCoordinates(new Vector2(x,y));
                                                
            }
        }



        /**
         *  Now we must place our pawn onto the board. Eventually we will have a list of pawns 
         *  that need placing but for now we will make do with just one.
         **/
        
        Pawn p = GameObject.Instantiate(basePawn);
        p.transform.parent = gameObject.transform;
        squares[4,4].setOccupant(p);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called when the mouse enters a tile's collision box
    public void hoverTile(Vector2 coords)
    {
        hoveredTile = squares[(int)coords.x, (int)coords.y];
        hoveredTile.setTileShader(hoverTileShader);
        highlightNeighbors();
    }

    // Called when the mouse leaves a tile's collision box
    public void clearHoverTile()
    {
        hoveredTile.setTileShader(standardTileShader);
        clearNeighborHightlight();
        hoveredTile = null;
    }

    // Called when a tile is clicked on
    public void selectTile(Vector2 coords)
    {
        selectedTile = squares[(int)coords.x, (int)coords.y];
        Debug.Log("Tile: " + coords);
    }

    // Called when we need to access a specific tile from the game board array
    public Tile getTile(Vector2 coords)
    {
        return squares[(int)coords.x, (int)coords.y];
    }

    // Applies a shader to highligh tiles adjacent to tile mouse is hovering above
    public void highlightNeighbors()
    {
        if(hoveredTile.hasNeighbor.north)
        {
            hoveredTile.neighbors[0].setTileShader(neighborTileShader);
        }
        if (hoveredTile.hasNeighbor.east)
        {
            hoveredTile.neighbors[1].setTileShader(neighborTileShader);
        }
        if (hoveredTile.hasNeighbor.south)
        {
            hoveredTile.neighbors[2].setTileShader(neighborTileShader);
        }
        if (hoveredTile.hasNeighbor.west)
        {
            hoveredTile.neighbors[3].setTileShader(neighborTileShader);
        }
    }

    // Replaces neighbor highlight shader with standard tile shader when tile is no longer hovered over
    public void clearNeighborHightlight()
    {
        if (hoveredTile.hasNeighbor.north)
        {
            hoveredTile.neighbors[0].setTileShader(standardTileShader);
        }
        if (hoveredTile.hasNeighbor.east)
        {
            hoveredTile.neighbors[1].setTileShader(standardTileShader);
        }
        if (hoveredTile.hasNeighbor.south)
        {
            hoveredTile.neighbors[2].setTileShader(standardTileShader);
        }
        if (hoveredTile.hasNeighbor.west)
        {
            hoveredTile.neighbors[3].setTileShader(standardTileShader);
        }
    }

    public void movePawn(Pawn p, Vector2 direction)
    {
        Tile originTile = getTile(p.getCoordinates());

        // Get the coordinates of the desired tile to move to
        Tile recievingTile = getTile(originTile.getCoordinates() + direction);
    }

}
