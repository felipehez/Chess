using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineChessGameController : MonoBehaviour
{    
    private enum GameState
    {
        Init, Play, Finished
    }

    private PiecesCreator pieceCreator;
    private ChessPlayer whitePlayer;
    private ChessPlayer blackPlayer;
    private ChessPlayer activePlayer;

    [SerializeField] private MineBoardLayout startingBoardLayout;
    [SerializeField] private MineBoard mineBoard;
    [SerializeField] private ChessUIManager UIManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
