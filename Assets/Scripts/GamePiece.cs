﻿using UnityEngine;
using System.Collections;
using System;

// All interactable game pieces will be GamePieces
public abstract class GamePiece : MonoBehaviour
{

    public PawnStats pawnStat;
    public Sprite graveMarker;
    public Vector2[] moves;
    
    public abstract void moveGamePiece(Vector2 direction);
    public abstract void moveGamePiece(Vector2 direction, int speed);
    public abstract void setCoordinates(Vector2 coords);
    public abstract Vector2 getCoordinates();
    public abstract void collide(GamePiece p);
    public abstract void damage(int d);
    public abstract void kill();
    public abstract Vector2[] getMoves();
}
