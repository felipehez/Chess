using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum FrenteColor
{
    // Black, White, Red, Orange, Yellow, Green, Cyan, Blue, Pink
}

public enum ElementType
{
    // Pawn, Bishop, Knight, Rook, Queen, King
}

//[CreateAssetMenu(menuName = "Scriptable Objects/Board/MineLayout")]
public class MineBoardLayout : ScriptableObject
{
    
    private class MineBoardSquareSetup
    {
        public Vector3 position;
        public PieceType pieceType;
        public TeamColor teamColor;
    }

    [SerializeField] private MineBoardSquareSetup[] boardSquares;


    /*
    public int GetPiecesCount()
    {
        return boardSquares.Length;
    }

    public Vector2Int GetSquareCoordsAtIndex(int index)
    {
        return new Vector2Int(boardSquares[index].position.x - 1, boardSquares[index].position.y - 1);
    }
    public string GetSquarePieceNameAtIndex(int index)
    {
        return boardSquares[index].pieceType.ToString();
    }
    public TeamColor GetSquareTeamColorAtIndex(int index)
    {
        return boardSquares[index].teamColor;
    }
    */

}
