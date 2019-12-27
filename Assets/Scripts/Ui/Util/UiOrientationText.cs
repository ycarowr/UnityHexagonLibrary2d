﻿using HexCardGame.Runtime.GameBoard;
using TMPro;
using UnityEngine;

namespace Game.Ui
{
    [RequireComponent(typeof(TMP_Text))]
    public class UiOrientationText : UiTmpText
    {
        const string Vertical = "Vertical";
        const string Horizontal = "Horizontal";

        [SerializeField] BoardController controller;

        void OnEnable() => CheckOrientation();

        void CheckOrientation()
        {
            var board = controller.Board;
            if (board == null)
                return;
            var txt = board.Orientation == Orientation.FlatTop ? Vertical : Horizontal;
            SetText(txt);
        }
    }
}