using UnityEngine;
using System.Collections;

public abstract class GamePiece : MonoBehaviour
{
    
    public abstract void moveGamePiece(Vector2 direction);
    public abstract void setCoordinates(Vector2 coords);
    public abstract Vector2 getCoordinates();

}
