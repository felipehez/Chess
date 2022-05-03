using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] _elementsPrefabs;

    private Dictionary<string, GameObject> _nameToElementDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach (var item in _elementsPrefabs)
        {
            _nameToElementDict.Add(item.GetComponent<ElementPiece>().GetType().ToString(), item);
        }
    }

    public GameObject CreateElement(Type type)
	{
        GameObject prefab = _nameToElementDict[type.ToString()];
        if (prefab)
		{
            GameObject newElement = Instantiate(prefab);
            return newElement;
		}
        return null;
	}
}
