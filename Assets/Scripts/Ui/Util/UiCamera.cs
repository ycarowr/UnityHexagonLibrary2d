﻿using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UiCamera : MonoBehaviour
{
    Transform _myTransform;
    [SerializeField] BoardController controller;
    [SerializeField] Tilemap tileMap;
    Camera MainCamera { get; set; }

    void Awake()
    {
        MainCamera = Camera.main;
        controller.OnCreateBoard += OnCreateBoard;
        _myTransform = transform;
    }

    void OnCreateBoard(IBoard board)
    {
        var maxPosY = float.MinValue;
        var maxPosX = float.MinValue;
        var minPosY = float.MaxValue;
        var minPosX = float.MaxValue;

        foreach (var pos in board.Positions)
        {
            var hex = pos.Point;
            var cell = BoardManipulationOddR.GetCellCoordinate(hex);
            var worldCellPos = tileMap.CellToWorld(cell);

            if (worldCellPos.x > maxPosX)
                maxPosX = worldCellPos.x;
            if (worldCellPos.y > maxPosY)
                maxPosY = worldCellPos.y;

            if (worldCellPos.x < minPosX)
                minPosX = worldCellPos.x;
            if (worldCellPos.y < minPosY)
                minPosY = worldCellPos.y;
        }

        Centralize(minPosX, minPosY, maxPosX, maxPosY);
    }

    void Centralize(float minPosX, float minPosY, float maxPosX, float maxPosY)
    {
        var mediumX = (minPosX + maxPosX) / 2;
        var mediumY = (minPosY + maxPosY) / 2;
        _myTransform.position = new Vector3(mediumX, mediumY, _myTransform.position.z);
    }
}