using HexCardGame.Runtime;
using HexCardGame.Runtime.GameBoard;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Ui
{
    public class UiBoardDebug : MonoBehaviour
    {
        GameObject[] _positions;
        [SerializeField] BoardController controller;
        [SerializeField] GameObject textPosition;
        [SerializeField] Tilemap tileMap;
        IBoard CurrentBoard { get; set; }

        protected void Awake() => controller.OnCreateBoard += OnCreateBoard;

        [Button]
        void DrawPositions()
        {
            const string uiPosition = "UiPosition_";
            var identity = Quaternion.identity;
            ClearPositions();
            _positions = new GameObject[CurrentBoard.Positions.Length];
            for (var i = 0; i < CurrentBoard.Positions.Length; i++)
            {
                var hex = CurrentBoard.Positions[i].Hex;
                var cell = CurrentBoard.Orientation == Orientation.PointyTop
                    ? BoardManipulationPointOddR.GetCellCoordinate(hex)
                    : BoardManipulationFlatOddR.GetCellCoordinate(hex);
                var worldPosition = tileMap.CellToWorld(cell);
                var gameObj = Instantiate(textPosition, worldPosition, identity, transform);
                _positions[i] = gameObj;
                var tmpText = gameObj.GetComponent<TMP_Text>();
                var sPosition = $"x:{hex.q}\ny:{hex.r}\nz:{hex.s}";
//                var sPosition = $"x:{cell.x}\ny:{cell.y}";
                tmpText.text = sPosition;
                tmpText.name = uiPosition + sPosition;
            }
        }

        [Button]
        void ClearPositions()
        {
            if (_positions == null)
                return;

            foreach (var i in _positions)
                Destroy(i);
        }

        void OnDrawGizmos()
        {
            if (CurrentBoard == null)
                return;

            foreach (var hex in controller.data.GetHexPoints())
            {
                var cell = CurrentBoard.Orientation == Orientation.PointyTop
                    ? BoardManipulationPointOddR.GetCellCoordinate(hex)
                    : BoardManipulationFlatOddR.GetCellCoordinate(hex);
                var worldPosition = tileMap.CellToWorld(cell);
                Gizmos.DrawWireSphere(worldPosition, 0.93f);
            }
        }

        void OnCreateBoard(IBoard board)
        {
            CurrentBoard = board;
            DrawPositions();
        }
    }
}