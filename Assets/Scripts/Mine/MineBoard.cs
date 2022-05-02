using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBoard : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Board Size:")]
    public int X_SIZE = 30;
    public int Z_SIZE = 4;

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

    private void CreateGrid()
    {
        _grid = new ElementPiece[X_SIZE, Z_SIZE];
    }

    public Vector3 CalculatePositionFromCoords(Vector2Int coords)
    {
        return _gridOrigin.position + new Vector3(coords.x * squareSizeX, 0f, coords.y * squareSizeY);
    }

    public void OnSquareSelected(Vector3 inputPosition)
    {
        throw new NotImplementedException();
    }

    public bool HasElement(ElementPiece element)
	{
        throw new NotImplementedException();
    }
}
