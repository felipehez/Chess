using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metadata : MonoBehaviour
{
    public string[] keys;
    public string[] values;

    public float dayPlaneado;
    public float dayBuilt;
    public bool scalling = false;
    public float localScaleZ = 0;
    public float calcLevel;
    public float calcSector;
    public float semana;
    public float diaDeSemana;

    //DataDisplay dataDisplay;
    public bool selected = false;
    public Material mat;
    public Material originalMat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalMat = mat;
        //dataDisplay = FindObjectOfType<DataDisplay>();
    }

    private void OnMouseDown()
    {
        originalMat = mat;
        if (!selected) 
        {
            selected = true;
            mat.color += Color.blue;
        }
        else if(selected) 
        {
            selected = false;
            mat.color = Color.grey;
        }
        
        //dataDisplay.DisplayElementInfo(keys, values);
    }

}


