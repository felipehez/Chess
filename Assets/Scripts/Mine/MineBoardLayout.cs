using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum FrenteColor
{
     Black, White, Red, Orange, Yellow, Green, Cyan, Blue, Pink
}

public enum ElementType
{
    Pilote, VigaCepado, VigaProyecto, PlataformaRodado, PlataformaAnclaje, PlataformaEquipos, Grua
}

[CreateAssetMenu(menuName = "Scriptable Objects/Board/MineLayout")]
public class MineBoardLayout : ScriptableObject
{
    [Serializable]
    private class PosturaInicial
    {
        public Vector2Int position;
        public ElementType elementType;
        public FrenteColor frenteColor;
    }

    [SerializeField] PosturaInicial[] posturaInicial;


    public int GetPiecesCount()
    {
        return posturaInicial.Length;
    }

    public Vector2Int GetSquareCoordsAtIndex(int index)
    {
        return new Vector2Int(posturaInicial[index].position.x - 1, posturaInicial[index].position.y - 1);
    }
    public string GetCepaElementNameAtIndex(int index)
    {
        return posturaInicial[index].elementType.ToString();
    }
    
    public FrenteColor GetSquareFrenteColorAtIndex(int index)
    {
         return posturaInicial[index].frenteColor;
    }
    
    

}
