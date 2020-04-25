using System;
using HexBoardGame.UI;
using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    public class BoardElementsController : MonoBehaviour
    {
        [SerializeField] private BoardController boardController;
        [SerializeField] private UiTileMapInputHandler uiTileMapInputHandler;
        private IBoard CurrentBoard { get; set; }
        private IDataProvider ElementProvider { get; set; }
        public event Action<BoardElement, Vector3Int> OnAddElement = (element, cell) => { };
        public event Action<BoardElement, Vector3Int> OnRemoveElement = (element, cell) => { };

        public void SetElementProvider(IDataProvider provider)
        {
            ElementProvider = provider;
        }

        private void Awake()
        {
            boardController.OnCreateBoard += OnCreateBoard;
            uiTileMapInputHandler.OnClickTile += OnClickTile;
        }

        private void OnClickTile(Vector3Int cell)
        {
            var hex = GetHexCoordinate(cell);
            if (ElementProvider == null)
            {
                RemoveElement(hex);
            }
            else
            {
                var element = ElementProvider.GetElement();
                AddElement(element, hex);
            }
        }

        private void OnCreateBoard(IBoard board)
        {
            CurrentBoard = board;
        }

        private void AddElement(BoardElement element, Hex hex)
        {
            var position = CurrentBoard.GetPosition(hex);
            if (position == null)
                return;
            if (position.HasData())
                return;
            position.AddData(element);

            var cell = GetCellCoordinate(hex);
            OnAddElement(element, cell);
        }

        private void RemoveElement(Hex hex)
        {
            var position = CurrentBoard?.GetPosition(hex);
            if (position == null)
                return;
            if (!position.HasData())
                return;
            var data = position.Data;
            position.RemoveData();
            OnRemoveElement(data, GetCellCoordinate(hex));
        }

        private static Hex GetHexCoordinate(Vector3Int cell)
        {
            return OffsetCoordHelper.RoffsetToCube(OffsetCoord.Parity.Odd, new OffsetCoord(cell.x, cell.y));
        }

        private static Vector3Int GetCellCoordinate(Hex hex)
        {
            return OffsetCoordHelper.RoffsetFromCube(OffsetCoord.Parity.Odd, hex).ToVector3Int();
        }
    }
}