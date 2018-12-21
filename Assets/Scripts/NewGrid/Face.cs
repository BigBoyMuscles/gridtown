using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face {

    private Vector2 coordinates;
    private Vector2[] neighbors = new Vector2[4];

    public Face()
    {
        setCoordinates(Vector2.zero);
        setNeighbors();
    }

    public Face(Vector2 coords)
    {
        setCoordinates(coords);
        setNeighbors();
    }

    public void setCoordinates(Vector2 v)
    {
        coordinates = v;
        setNeighbors();
    }

    public Vector2 getCoordinates()
    {
        return coordinates;
    }

    public void setNeighbors()
    {
        neighbors[0] = coordinates + Vector2.up;
        neighbors[1] = coordinates + Vector2.right;
        neighbors[2] = coordinates + Vector2.down;
        neighbors[3] = coordinates + Vector2.left;
    }

    public Vector2[] getNeighbors()
    {
        return neighbors;
    }




}
