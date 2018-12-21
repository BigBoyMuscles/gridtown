using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex {

    [SerializeField]
    private Vector2 coordinates;

    public Vertex()
    {
        coordinates = Vector2.zero;
    }

    public Vertex(Vector2 coords)
    {
        setCoordinates(coordinates);
    }
    
    public void setCoordinates(Vector2 coords)
    {
        coordinates = coords;
    }

    public Vector2 getCoordinates()
    {
        return coordinates;
    }

}
