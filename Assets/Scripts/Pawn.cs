﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    //Basic stats for now
    [Header("Pawn Stats")]
    public double health;
    public int speed;
    public int strength;

    private Board board;

    private Vector2 coordinates;
    private Tile occupiedTile;

    private SpriteRenderer spriteRenderer;

    public struct Directions
    {
        Vector2 north;
        Vector2 east;
        Vector2 south;
        Vector2 west;

        public Directions(Vector2 n, Vector2 e, Vector2 s, Vector2 w)
        {
            north = n;
            east = e;
            south = s;
            west = w;
        }
        
    }

    private Directions directions;


    //This class will hold other info about pawns, such as:
    //team ownership
    //Status Effects
    //Powerups

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Use this for initialization
    void Start () {
        health = 3.0f;
        speed = 4;
        strength = 1;
        board = transform.parent.GetComponent<Board>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead())
        {
            Debug.Log("Pawn Died");
            return;
        }

        occupiedTile = board.getTile(coordinates);
        transform.position = occupiedTile.transform.position;

	}

    // Move a single tile
    public void movePawn(Vector2 direction)
    {
        if(board.getTile(coordinates + direction) != null)
        {
            occupiedTile.passOccupant();
            occupiedTile = board.getTile(coordinates + direction);
            occupiedTile.recieveOccupant(gameObject.GetComponent<Pawn>());
            coordinates += direction;
        }
    }

    // Move multiple tiles
    public void movePawn(Vector2 direction, int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (board.getTile(coordinates + direction) != null)
            {
                occupiedTile.passOccupant();
                occupiedTile = board.getTile(coordinates + direction);
                occupiedTile.recieveOccupant(gameObject.GetComponent<Pawn>());
                coordinates += direction;
            }
        }
    }


    private bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    }

    public void kill()
    {
        health = health - health;
    }

    public Vector2 getCoordinates()
    {
        return coordinates;
    }

    public void updateCoordinates(Vector2 coords)
    {
        coordinates = coords;
    }
    // Requires calls for movement / pawn interactions


    
}
