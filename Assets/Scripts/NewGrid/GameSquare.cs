using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSquare : MonoBehaviour {

    private SpriteRenderer rend;

    // Each gamespace has 1 face, 2 edges (left and bottom) and 1 vertex (bottom left) to
    // Uniquely identify each space. 

    private Face face;
    private Edge sideEdge;
    private Edge bottomEdge;
    private Vertex vertex;

    private GameBoard board;

    // Use this for initialization
    void Start () {

        rend = GetComponent<SpriteRenderer>();
        board = GetComponentInParent<GameBoard>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(Vector2 coord)
    {
        face = new Face(coord);
        sideEdge = new Edge(coord, true);
        bottomEdge = new Edge(coord, false);
        vertex = new Vertex(coord);

        transform.position = new Vector3((coord.x * 1.125f) - 4, (coord.y * 1.125f) - 4, 0);
        
        //transform.position = (coord);
    }

    private void OnMouseEnter()
    {
        board.squareMouseEnter(this);
    }

    private void OnMouseDown()
    {
        board.selectTile(face.getCoordinates());
    }

    private void OnMouseExit()
    {
        board.squareMouseExit(this);
    }

    public void setShader(Shader shader)
    {
        rend.material.shader = shader;
    }
}
