using HexCardGame.Runtime.GameBoard;
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
        void Start() => controller.OnCreateBoard += OnCreateBoard;

        void OnCreateBoard(IBoard obj)
        {
            var txt = obj.Orientation == Orientation.FlatTop ? Vertical : Horizontal;
            SetText(txt);
        }
    }
}