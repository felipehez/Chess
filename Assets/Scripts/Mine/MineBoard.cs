using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBoard : MonoBehaviour
{
    // Start is called before the first frame update

    public int board_size_x = 30;
    public int board_size_z = 4;

    [SerializeField] private Transform gridOrigin;    
    [SerializeField] float squareSizeX;
    [SerializeField] float squareSizeY;

    private Piece[,] grid;
    private Piece selectedPiece;
    private MineChessGameController chessController;

    private void Awake()
    {
        //squareSelector = GetComponent<SquareSelectorCreator>();
        CreateGrid();
    }

    public void SetDependencies(MineChessGameController chessController)
    {
        this.chessController = chessController;
    }

    void Start()
    {
        
    }
    private void CreateGrid()
    {
        grid = new Piece[board_size_x, board_size_z];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
