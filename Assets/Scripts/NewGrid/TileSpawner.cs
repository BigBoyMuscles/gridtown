using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour
{
    public iCopyable m_Copy;

    public GameSquare SpawnGameSquare(GameSquare prototype)
    {
        m_Copy = prototype.Copy();
        return (GameSquare)m_Copy;
    }
}
