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
                squares[x, y].name = "(" + x + "," + y + ")";
                squares[x,y].transform.parent = gameObject.transform;
                Vector2 coord = new Vector2(x, y);

                //Make sure the new square's coordinate match its position on the board
                squares[x,y].setCoordinates(coord);
                                                
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
    }

    // Called when we need to access a specific tile from the game board array
    public Tile getTile(Vector2 coords)
    {
        return squares[(int)coords.x, (int)coords.y];
    }

    // Applies a shader to highligh tiles adjacent to tile mouse is hovering above
    public void highlightNeighbors()
    {
        if(hoveredTile.neighbors.north)
        {
            hoveredTile.north.setTileShader(neighborTileShader);
        }
        if (hoveredTile.neighbors.east)
        {
            hoveredTile.east.setTileShader(neighborTileShader);
        }
        if (hoveredTile.neighbors.south)
        {
            hoveredTile.south.setTileShader(neighborTileShader);
        }
        if (hoveredTile.neighbors.west)
        {
            hoveredTile.west.setTileShader(neighborTileShader);
        }
    }

    // Replaces neighbor highlight shader with standard tile shader when tile is no longer hovered over
    public void clearNeighborHightlight()
    {
        if (hoveredTile.neighbors.north)
        {
            hoveredTile.north.setTileShader(standardTileShader);
        }
        if (hoveredTile.neighbors.east)
        {
            hoveredTile.east.setTileShader(standardTileShader);
        }
        if (hoveredTile.neighbors.south)
        {
            hoveredTile.south.setTileShader(standardTileShader);
        }
        if (hoveredTile.neighbors.west)
        {
            hoveredTile.west.setTileShader(standardTileShader);
        }
    }

}
