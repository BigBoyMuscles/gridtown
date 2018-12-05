using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cleaner Implementation of a game piece controller. 

// The pawn is the base class for game units. It contains the barebones 
// functionality Required to interact with the game. 

public class Pawn : GamePiece
{
    private Vector2 coordinates;
    private Board board;
    private GameSpace occupiedTile;

    private void Awake()
    {
       
    }

    private void Start()
    {
        board = GetComponentInParent<Board>();
    }

    private void Update()
    {
        occupiedTile = board.getTile(coordinates);
        transform.position = board.getTile(coordinates).transform.position;
    }

    public override void moveGamePiece(Vector2 direction)
    {
        Vector2 destination = coordinates + direction;

        if (board.getTile(coordinates + direction) != null && !board.getTile(coordinates + direction).isOccupied())
        {
            occupiedTile.passOccupant();
            occupiedTile = board.getTile(coordinates + direction);
            occupiedTile.recieveOccupant(gameObject.GetComponent<GamePiece>());
            coordinates += direction;
        }
    }

    public override void setCoordinates(Vector2 coords)
    {
        coordinates = coords;
        
    }

    public override Vector2 getCoordinates()
    {
        return coordinates;
    }

}
