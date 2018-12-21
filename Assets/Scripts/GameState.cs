using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public Board gameBoard;
    public PawnPanel pawnPanel;

    private GameSpace selectedGameSpace;
    private GameSpace previousGameSpace;
    private GamePiece pawn;
    private PawnPanel redPanel;
    private bool redTurn;

    [SerializeField]
    private string title;

    [SerializeField]
    private int health;

    [SerializeField]
    private int power;

    [SerializeField]
    private int speed;

    private Vector2[] validMoves;

	// Use this for initialization
	void Start () {
        redPanel = PawnPanel.Instantiate(pawnPanel);
        redPanel.name = "Red Player";
        redPanel.transform.SetParent(gameObject.transform);
    }
	
	// Update is called once per frame
	void Update () {

        // Stage 1 should look like:
        // Click square, is it empty?
        // If no, nothing. If yes, get pawn
        // Then, find all valid movespaces for the pawn
        // Highlight those valid spaces
        // If the next space clicked is one of those squares
        // Move the game piece to that square
        // Otherwise, clear the selected gamepiece

        if (previousGameSpace != null)
        {

        }
		if(pawn != null)
        {
            health = pawn.pawnStat.health;
            power = pawn.pawnStat.power;
            speed = pawn.pawnStat.speed;
            
        }
	}

    public void setSelectedGameSpace(GameSpace s)
    {
        previousGameSpace = selectedGameSpace;
        selectedGameSpace = s;

        gameBoard.dimAllSpaces();

        

        if(s.getOccupant() != null)
        {
            pawn = s.getOccupant();
            redPanel.setSelectedPawn(pawn);

            validMoves = gameBoard.getValidMoves(pawn.getMoves());
            gameBoard.highlightGameSpaces(validMoves);

        } else if(previousGameSpace.isOccupied())
        {
            foreach(Vector2 v in validMoves)
            {
                if(v == selectedGameSpace.getCoordinates())
                {
                    //pawn.moveGamePiece(selectedGameSpace.getCoordinates() - previousGameSpace.getCoordinates(), );
                }
            }
        }
        

        
    }

    
}
