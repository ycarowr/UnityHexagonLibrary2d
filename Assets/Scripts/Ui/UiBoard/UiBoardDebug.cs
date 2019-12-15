using System.Linq;
using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using HexCardGame.SharedData;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Ui
{
    public class UiBoardDebug : UiEventListener, ICreateBoard<BoardElement>
    {
        [SerializeField] BoardController controller;
        GameObject[] positions;
        [SerializeField] GameObject textPosition;
        [SerializeField] Tilemap tileMap;
        IBoard<BoardElement> CurrentBoard { get; set; }

        [Button]
        void DrawPositions()
        {
            const string uiPosition = "UiPosition_";
            var identity = Quaternion.identity;
            ClearPositions();
            positions = new GameObject[CurrentBoard.Positions.Length];
            for (var i = 0; i < CurrentBoard.Positions.Length; i++)
            {
                var hex = CurrentBoard.Positions[i].Hex;
                var cell = HexHelper.YOffsetFromCubeEven(hex);
                var worldPosition = tileMap.CellToWorld(cell);
                var gameObj = Instantiate(textPosition, worldPosition, identity, transform);
                positions[i] = gameObj;
                var tmpText = gameObj.GetComponent<TMP_Text>();
                var sPosition = $"x:{hex.x}\ny:{hex.y}";
                tmpText.text = sPosition;
                tmpText.name = uiPosition + sPosition;
            }
        }

        [Button]
        void ClearPositions()
        {
            if (positions == null)
                return;

            foreach (var i in positions)
                Destroy(i);
        }

        void OnDrawGizmos()
        {
            foreach (var hex in controller.Data.GetHexPositions())
            {
                var cell = HexHelper.YOffsetFromCubeEven(hex);
                var worldPosition = tileMap.CellToWorld(cell);
                Gizmos.DrawWireSphere(worldPosition, 0.93f);
            }
        }

        void ICreateBoard<BoardElement>.OnCreateBoard(IBoard<BoardElement> board)
        {
            CurrentBoard = board;
            DrawPositions();
        }
    }
}