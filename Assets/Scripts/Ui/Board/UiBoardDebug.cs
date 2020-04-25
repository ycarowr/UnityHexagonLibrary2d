using HexBoardGame.Runtime;
using HexBoardGame.Runtime.GameBoard;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Ui
{
    public class UiBoardDebug : MonoBehaviour
    {
        private GameObject[] _positions;
        [SerializeField] private BoardController controller;
        [SerializeField] private GameObject textPosition;
        [SerializeField] private Tilemap tileMap;
        private IBoard CurrentBoard { get; set; }

        protected void Awake()
        {
            controller.OnCreateBoard += OnCreateBoard;
        }

        [Button]
        private void DrawPositions()
        {
            const string uiPosition = "UiPosition_";
            var identity = Quaternion.identity;
            ClearPositions();
            _positions = new GameObject[CurrentBoard.Positions.Length];
            for (var i = 0; i < CurrentBoard.Positions.Length; i++)
            {
                var hex = CurrentBoard.Positions[i].Point;
                var cell = BoardManipulationOddR.GetCellCoordinate(hex);
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
        private void ClearPositions()
        {
            if (_positions == null)
                return;

            foreach (var i in _positions)
                Destroy(i);
        }

        private void OnDrawGizmos()
        {
            if (CurrentBoard == null)
                return;

            foreach (var hex in controller.boardShape.GetHexPoints())
            {
                var cell = BoardManipulationOddR.GetCellCoordinate(hex);
                var worldPosition = tileMap.CellToWorld(cell);
                Gizmos.DrawWireSphere(worldPosition, 0.93f);
            }
        }

        private void OnCreateBoard(IBoard board)
        {
            CurrentBoard = board;
            DrawPositions();
        }
    }
}