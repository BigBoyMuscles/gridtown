using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : GamePiece {

    public GamePieceController controller;
    private PawnStats stats;
    //private new Sprite graveMarker;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<GamePieceController>();
        this.graveMarker = controller.graveMarker;
        stats = GetComponent<PawnStats>();
        
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
        controller.moveGamePiece(direction);
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
}
