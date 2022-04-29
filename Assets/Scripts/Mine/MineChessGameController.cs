using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineChessGameController : MonoBehaviour
{    
    private enum GameState
    {
        Init, Play, Finished
    }

    [SerializeField] private MineBoard board;

    private ElementCreator elementCreator;
    private ChessPlayer whitePlayer;
    private ChessPlayer blackPlayer;
    private ChessPlayer activePlayer;

    [SerializeField] private MineBoardLayout startingBoardLayout;
    [SerializeField] private MineBoard mineBoard;
    //[SerializeField] private ChessUIManager UIManager;

    void Start()
    {
        //CreatePiecesFromLayout(startingBoardLayout);
        board.SetDependencies(this);
    }

    private void CreatePiecesFromLayout(MineBoardLayout layout)
    {
        for (int i = 0; i < layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            FrenteColor frente = layout.GetSquareFrenteColorAtIndex(i);
            string typeName = layout.GetCepaElementNameAtIndex(i);

            Type type = Type.GetType(typeName);
            //CreateElementAndInitialize(squareCoords, frente, type);
        }
    }

    /*
    public void CreateElementAndInitialize(Vector2Int squareCoords, FrenteColor frente, Type type)
    {
        ElementCreator newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, frente, board);

        //Material teamMaterial = pieceCreator.GetTeamMaterial(team);
        //newPiece.SetMaterial(teamMaterial);

        board.SetPieceOnBoard(squareCoords, newPiece, FrenteColor);

        ChessPlayer currentPlayer = team == TeamColor.White ? whitePlayer : blackPlayer;
        currentPlayer.AddPiece(newPiece);

    }
    */
}
