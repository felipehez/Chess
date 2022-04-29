using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] elementsPrefabs;

    private Dictionary<string, GameObject> nameToElementDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach (var item in elementsPrefabs)
        {
            //nameToElementDict.Add()
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
