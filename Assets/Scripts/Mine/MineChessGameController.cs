using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ElementCreator))]
public class MineChessGameController : MonoBehaviour
{    
    private enum GameState
    {
        Init, Play, Finished
    }

    [SerializeField] private MineBoardLayout startingBoardLayout;
    [SerializeField] private MineBoard board;

    private ElementCreator _elementCreator;

	private void Awake()
	{
        SetDependencies(this);
    }

	private void SetDependencies(MineChessGameController mineChessGameController)
	{
        _elementCreator = GetComponent<ElementCreator>();
	}

	void Start()
    {
        CreatePiecesFromLayout(startingBoardLayout);
    }

    private void CreatePiecesFromLayout(MineBoardLayout layout)
    {
        for (int i = 0; i < layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            FrenteColor frente = layout.GetSquareFrenteColorAtIndex(i);
            string typeName = layout.GetCepaElementNameAtIndex(i);

            Type type = Type.GetType(typeName);
            CreateElementAndInitialize(squareCoords, frente, type);
        }
    }


	public void CreateElementAndInitialize(Vector2Int squareCoords, FrenteColor frente, Type type)
	{
		ElementPiece newElement = _elementCreator.CreateElement(type).GetComponent<ElementPiece>();
        newElement.SetData(squareCoords, frente, board);

        board.SetElementOnBoard(squareCoords, newElement);

		//ChessPlayer currentPlayer = team == TeamColor.White ? whitePlayer : blackPlayer;
		//currentPlayer.AddPiece(newElement);
	}

}
