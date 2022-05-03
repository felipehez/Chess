using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBoard : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Board Size:")]
    public int X_SIZE = 30;
    public int Y_SIZE = 4;

    [Space()]
    [SerializeField] private Transform _gridOrigin;
    [SerializeField] float squareSizeX;
    [SerializeField] float squareSizeY;

    private ElementPiece[,] _grid;
    private ElementPiece _selectedElement;
    private MineChessGameController _chessController;

    private void Awake()
    {
        CreateGrid();
    }

    public void SetDependencies(MineChessGameController chessController)
	{
        this._chessController = chessController;
	}

    private void CreateGrid()
    {
        _grid = new ElementPiece[X_SIZE, Y_SIZE];
    }

    public ElementPiece GetElementOnSquare(Vector2Int coords)
	{
        if (CheckIfCoordinatesAreOnBoard(coords))	
            return _grid[coords.x, coords.y];
        return null;
	}

	public bool CheckIfCoordinatesAreOnBoard(Vector2Int coords)
	{
        if (coords.x < 0 || coords.y < 0 || coords.x >= X_SIZE || coords.y >= Y_SIZE)
            return false;
        return true;
	}

	public Vector3 CalculatePositionFromCoords(Vector2Int coords)
    {
        return _gridOrigin.position + new Vector3(coords.x * squareSizeX, 0f, coords.y * squareSizeY);
    }

	internal void SetElementOnBoard(Vector2Int coords, ElementPiece element)
	{
        if (CheckIfCoordinatesAreOnBoard(coords))
            _grid[coords.x, coords.y] = element;
	}

	public void OnSquareSelected(Vector3 inputPosition)
    {
        
        Vector2Int coords = CalculateCoordsFromPosition(inputPosition);
        Debug.Log(coords);
        ElementPiece elementOnSquare = GetElementOnSquare(coords);
        if (_selectedElement)
		{
            if (elementOnSquare != null && _selectedElement == elementOnSquare)
                DeselectElement();
            else if (elementOnSquare != null && _selectedElement != elementOnSquare)
                SelectElement(elementOnSquare);
            else if (_selectedElement.CanMoveTo(coords))
                OnSelectedElementMoved(coords, _selectedElement);
		}
    }

	private void OnSelectedElementMoved(Vector2Int coords, ElementPiece element)
	{
        //TryToTakeOppositePiece(coords);
        UpdateBoardOnPieceMove(coords, element.occupiedSquare, element, null);
        _selectedElement.MoveElement(coords);
        DeselectElement();
	}

	private void UpdateBoardOnPieceMove(Vector2Int newCoords, Vector2Int oldCoords, ElementPiece newElement, ElementPiece oldElement)
	{
        _grid[oldCoords.x, oldCoords.y] = oldElement;
        _grid[newCoords.x, newCoords.y] = newElement;
    }

	private void SelectElement(ElementPiece element)
	{
        _selectedElement = element;
        List<Vector2Int> selection = _selectedElement.avaliableMoves;
        ShowSelectionSquares(selection);
	}

	private void ShowSelectionSquares(List<Vector2Int> selection)
	{
		throw new NotImplementedException();
	}

	private void DeselectElement()
	{
        _selectedElement = null;
        //squareSelector.ClearSelection();
	}

	private Vector2Int CalculateCoordsFromPosition(Vector3 inputPosition)
	{
        int x = Mathf.FloorToInt(transform.InverseTransformPoint(inputPosition).x / squareSizeX) + X_SIZE / 2;
        int y = Mathf.FloorToInt(transform.InverseTransformPoint(inputPosition).z / squareSizeY) + Y_SIZE / 2;
        return new Vector2Int(x, y);
    }

	public bool HasElement(ElementPiece element)
	{
        for (int i = 0; i < X_SIZE; i++)
		{
            for (int j = 0; j < Y_SIZE; j++)
			{
                if (_grid[i, j] == element)
                    return true;
			}
		}
        return false;
    }
}
