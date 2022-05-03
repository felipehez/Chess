using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementPiece : MonoBehaviour
{
	//private MaterialSetter materialSetter;
	public MineBoard board { get; set; }
	public Vector2Int occupiedSquare { get; set; }
	public ElementPieceType elementType { get; set; }

	public List<Vector2Int> avaliableMoves;

	public abstract List<Vector2Int> SelectAvaliableSquares();

	private void Awake()
	{
		avaliableMoves = new List<Vector2Int>();
	}

	public bool CanMoveTo(Vector2Int coords)
	{
		return avaliableMoves.Contains(coords);
	}

	internal void MoveElement(Vector2Int coords)
	{
		Vector3 targetPosition = board.CalculatePositionFromCoords(coords);
		occupiedSquare = coords;
		transform.position = targetPosition;
	}

	protected void TryToAddMove(Vector2Int coords)
	{
		avaliableMoves.Add(coords);
	}

	internal void SetData(Vector2Int coords, FrenteColor frente, MineBoard board)
	{
		occupiedSquare = coords;
		this.board = board;
		transform.position = board.CalculatePositionFromCoords(coords);
	}
}
