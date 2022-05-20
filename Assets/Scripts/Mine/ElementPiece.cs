using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPiece : MonoBehaviour
{
	private MaterialSetter materialSetter;
	public MineBoard board { get; set; }
	public Vector2Int occupiedSquare { get; set; }
	public ElementPieceType elementType { get; set; } 
}
