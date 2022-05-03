using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRodado : ElementPiece
{
	Vector2Int[] directions = new Vector2Int[]
	{
		new Vector2Int(1,0),
		new Vector2Int(-1,0)
	};

	public override List<Vector2Int> SelectAvaliableSquares()
	{
		avaliableMoves.Clear();
		AssignStandardMoves();
		return avaliableMoves;
	}

	private void AssignStandardMoves()
	{
		float range = 1;
		foreach (var direction in directions)
		{
			for (int i = 1; i <= range; i++)
			{
				Vector2Int nextCoords = occupiedSquare + direction * i;
				ElementPiece element = board.GetElementOnSquare(nextCoords);
				if (!board.CheckIfCoordinatesAreOnBoard(nextCoords))
					break;
				if (element == null)
					TryToAddMove(nextCoords);
				else
					break;
			}
		}
	}
}
