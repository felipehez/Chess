﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MineBoard))]
public class BoardInputHandler : MonoBehaviour, IInputHandler
{
    private MineBoard board;

    private void Awake()
    {
        board = GetComponent<MineBoard>();
    }

    public void ProcessInput(Vector3 inputPosition, GameObject selectedObject, Action onClick)
    {
        board.OnSquareSelected(inputPosition);
    }
}