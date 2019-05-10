using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSquare : MonoBehaviour, iCopyable {

    private SpriteRenderer rend;

    private Vector2 gridCoordinates;

    private GameBoard board;

    public delegate void GameSquareClicked(Vector2 coordinates);
    public static event GameSquareClicked OnGameSquareClicked;

    public delegate void GameSquareHover(Vector2 coordinates);
    public static event GameSquareHover OnGameSquareHover;

    public delegate void GameSquareHoverExit(Vector2 coordinates);
    public static event GameSquareHoverExit OnGameSquareHoverExit;

    void Start () {
        rend = GetComponent<SpriteRenderer>();
        board = GetComponentInParent<GameBoard>();
    }

	void Update () {

    }

    public void SetCoordinates(Vector2 coord)
    {
        gridCoordinates = coord;
        transform.position = new Vector3((coord.x * 1.125f) - 4, (coord.y * 1.125f) - 4, 0);
    }

    private void OnMouseEnter()
    {
        if (OnGameSquareHover != null)
        {
            OnGameSquareHover(gridCoordinates);
        }
    }

    private void OnMouseDown()
    {
        if (OnGameSquareClicked != null)
        {
            OnGameSquareClicked(gridCoordinates);
        }
    }

    private void OnMouseExit()
    {
        if (OnGameSquareHoverExit != null)
        {
            OnGameSquareHoverExit(gridCoordinates);
        }
    }

    public void setShader(Shader shader)
    {
        rend.material.shader = shader;
    }

    public iCopyable Copy()
    {
        return Instantiate(this);
    }
}
