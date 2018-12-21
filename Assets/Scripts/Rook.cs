using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : GamePiece {

    public GamePieceController controller;
    public Board gameBoard;
    private PawnStats stats;
    
    //private new Sprite graveMarker;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<GamePieceController>();
        this.graveMarker = controller.graveMarker;
        stats = GetComponent<PawnStats>();
        gameBoard = GetComponentInParent<Board>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void collide(GamePiece p)
    {
        controller.collide(p);
    }

    public override void damage(int d)
    {
        controller.damage(d);
    }

    public override Vector2 getCoordinates()
    {
        return controller.getCoordinates();
    }

    public override void moveGamePiece(Vector2 direction)
    {
        controller.moveGamePiece(direction, 1);     
    }

    public override void setCoordinates(Vector2 coords)
    {
        controller.setCoordinates(coords);
    }

    public override void kill()
    {
        controller.kill();
    }

    public override void moveGamePiece(Vector2 direction, int speed)
    {
        controller.moveGamePiece(direction, speed);
    }

    public override Vector2[] getMoves()
    {

        GameSpace[] row = gameBoard.getRow((int)controller.getCoordinates().y);
        GameSpace[] column = gameBoard.getColumn((int)controller.getCoordinates().x);

        int mSize = row.Length + column.Length;

        GameSpace[] m = new GameSpace[mSize];

        Array.Copy(row, m, row.Length);
        Array.Copy(column, 0, m, row.Length, column.Length);

        Vector2[] validMoves = new Vector2[m.Length];

        for(int i = 0; i < validMoves.Length; i++)
        {
            validMoves[i] = m[i].getCoordinates();
            Debug.Log("Valid Move: " + validMoves[i]);
        }

        return validMoves;


    }
}
