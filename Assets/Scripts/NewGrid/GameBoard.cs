﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public GameSquare square;
    public Shader squareHighlight;
    public TileSpawner t_spawn;

    private GameSquare[,] board = new GameSquare[8, 8];
    private GameSquare selectedSquare;

	// Use this for initialization
	void Start () {

        //Subscribe to game events
        GameSquare.OnGameSquareHover += highlightGameSpace;
        GameSquare.OnGameSquareHoverExit += dimGameSpace;
        GameSquare.OnGameSquareClicked += selectTile;

        for (int x = 0; x < board.GetLength(0); x++)
        {
            for(int y = 0; y < board.GetLength(1); y++)
            {
                GameSquare s = t_spawn.SpawnGameSquare(square);
                //s.Initialize(new Vector2(x, y));
                s.name = "(" + x + "," + y + ")";
                s.transform.SetParent(gameObject.transform);
                s.SetCoordinates(new Vector2(x, y));
                board[x, y] = s;

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void highlightGameSpace(GameSquare s)
    {
        s.setShader(squareHighlight);
    }

    public void highlightGameSpaces(GameSquare[] squares)
    {
        foreach(GameSquare s in squares)
        {
            highlightGameSpace(s);
        }
    }

    public void dimGameSpaces(GameSquare[] squares)
    {
        foreach (GameSquare s in squares)
        {
            dimGameSpace(s);
        }
    }

    public void highlightGameSpace(Vector2 v)
    {
        board[(int)v.x, (int)v.y].setShader(squareHighlight);
        
    }

    public void dimGameSpace(Vector2 v)
    {
        dimGameSpace(board[(int)v.x, (int)v.y]);
    }

    public void dimGameSpace(GameSquare s)
    {
        s.setShader(Shader.Find("Sprites/Default"));
    }

    public void selectTile(Vector2 coord)
    {
        selectedSquare = board[(int)coord.x, (int)coord.y];
        Debug.Log("Selected Square: " + selectedSquare.name);
    }
}
