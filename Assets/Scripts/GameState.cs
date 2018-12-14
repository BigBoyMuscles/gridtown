using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public Board gameBoard;
    public PawnPanel pawnPanel;

    private GameSpace selectedGameSpace;
    private GamePiece pawn;
    private PawnPanel redPanel;    

    [SerializeField]
    private string title;

    [SerializeField]
    private int health;

    [SerializeField]
    private int power;

    [SerializeField]
    private int speed;

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

		if(pawn != null)
        {
            health = pawn.pawnStat.health;
            power = pawn.pawnStat.power;
            speed = pawn.pawnStat.speed;

            
        }
	}

    public void setSelectedGameSpace(GameSpace s)
    {
        selectedGameSpace = s;
        if(s.getOccupant() != null)
        {
            pawn = s.getOccupant();
            redPanel.setSelectedPawn(pawn);
        } else
        {
            pawn = null;
            redPanel.clearSelectedPawn();
        }
        
        
    }
}
