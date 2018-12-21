using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge {

    private Vector2 coordinates;

    // Differentiates between horizontal and vertical edges
    private bool vertical;

    private Edge[] continuedEdges = new Edge[2];


    public Edge()
    {
        setCoordinates(Vector2.zero, true);
    }

    public Edge(Vector2 coords, bool isVertical)
    {
        setCoordinates(coords, isVertical);
    }

    public void setCoordinates(Vector2 coords, bool isVertical)
    {
        coordinates = coords;
        this.vertical = isVertical;
        //continues();
    }

    private void continues()
    {
        if(vertical)
        {
            continuedEdges[0] = new Edge(coordinates + Vector2.down, vertical);
            continuedEdges[1] = new Edge(coordinates + Vector2.up, vertical);
        }
        else
        {
            continuedEdges[0] = new Edge(coordinates + Vector2.left, vertical);
            continuedEdges[1] = new Edge(coordinates + Vector2.right, vertical);
        }
    }

    public Edge[] getContinuedEdges()
    {
        return continuedEdges;
    }




}
