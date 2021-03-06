﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cleaner Implementation of a game piece controller. 

// The pawn is the base class for game units. It contains the barebones 
// functionality Required to interact with the game. 

public class GamePieceController : GamePiece
{

    //public PawnStats pawnStat;

    public Vector2 coordinates;
    private Board board;
    private GameSpace occupiedTile;

    private void Awake()
    {
       
    }

    private void Start()
    {
        board = GetComponentInParent<Board>();
        pawnStat = GetComponent<PawnStats>();
    }

    private void Update()
    {
        occupiedTile = board.getTile(coordinates);
        transform.position = board.getTile(coordinates).transform.position;
    }

    public override void moveGamePiece(Vector2 direction)
    {
        for (int i = 0; i < pawnStat.speed; i++)
        {
            Vector2 destCoords = coordinates + direction;
            GameSpace destination = board.getTile(destCoords);

            // Check that the destination tile exists on the GameBoard
            if (destination != null && !pawnStat.isDead())
            {
                // Then check that tile to see if it is occupied by another GamePiece
                if (destination.isOccupied())
                {
                    collide(destination.getOccupant());
                }
                else
                {
                    // If the tile is empty and valid, pass the pawn to the next tile
                    occupiedTile.passOccupant();
                    occupiedTile = board.getTile(coordinates + direction);
                    occupiedTile.recieveOccupant(gameObject.GetComponent<GamePiece>());
                    coordinates += direction;
                }
            }
        }
    }

    public override void moveGamePiece(Vector2 direction, int speed)
    {
        for(int i = 0; i < speed; i++)
        {
            Vector2 destCoords = coordinates + direction;
            GameSpace destination = board.getTile(destCoords);

            // Check that the destination tile exists on the GameBoard
            if (destination != null && !pawnStat.isDead())
            {
                // Then check that tile to see if it is occupied by another GamePiece
                if (destination.isOccupied())
                {
                    collide(destination.getOccupant());
                }
                else
                {
                    // If the tile is empty and valid, pass the pawn to the next tile
                    occupiedTile.passOccupant();
                    occupiedTile = board.getTile(coordinates + direction);
                    occupiedTile.recieveOccupant(gameObject.GetComponent<GamePiece>());
                    coordinates += direction;
                }
            }
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

    //Pass the game piece we collide with 
    public override void collide(GamePiece p)
    {
        p.damage(pawnStat.power);        
    }

    public override void damage(int d)
    {
        pawnStat.damage(d);
        if(pawnStat.isDead())
        {
            kill();
        }
    }

    public override void kill()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        //rend.color = new Color(255, 0, 0);
        rend.sprite = graveMarker;
    }

    public override Vector2[] getMoves()
    {
        Vector2[] m = new Vector2[4];

        m[0] = Vector2.up + coordinates;
        m[1] = Vector2.right + coordinates;
        m[2] = Vector2.down + coordinates;
        m[3] = Vector2.left + coordinates;


        return m;
    }
}
