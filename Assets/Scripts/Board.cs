using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    [SerializeField]
    private Square[,] squares;
    [Header("Tile Info")]
    public Square baseSquare;

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

        /**
         * The board will be created, starting with (0,0) in the bottom left corner
         * and increasing tp (7, 7) in the top right corner.
         * 
         * **/

        //Create an 8x8 playing field
        squares = new Square[8,8];
       
        //iterate X
        for (int x = 0; x < squares.GetLength(0); x++){

            //iterate y
            for (int y =0; y < squares.GetLength(1); y++)
            {
                //Make each square of our gameboard an empty square object
                squares[x, y] = GameObject.Instantiate(baseSquare);

                Vector2 coord = new Vector2(x, y);

                //Make sure the new square's coordinate match its position on the board
                squares[x,y].setCoordinates(coord);
                                                
            }
        }

        /**
         *  Now we must place our pawn onto the board. Eventually we will have a list of pawns 
         *  that need placing but for now we will make do with just one.
         **/

        //pawns = new Pawn[1];
        
            Pawn p = GameObject.Instantiate(basePawn);
        squares[0,0].setOccupant(p);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
