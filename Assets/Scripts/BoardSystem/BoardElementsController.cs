using System;
using HexBoardGame.UI;
using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    public class BoardElementsController : MonoBehaviour
    {
        [SerializeField] BoardController boardController;
        [SerializeField] UiTileMapInputHandler uiTileMapInputHandler;
        IBoard CurrentBoard { get; set; }
        IDataProvider ElementProvider { get; set; }
        public event Action<BoardElement, Vector3Int> OnAddElement = (element, cell) => { };
        public event Action<BoardElement, Vector3Int> OnRemoveElement = (element, cell) => { };
        public void SetElementProvider(IDataProvider provider) => ElementProvider = provider;

        void Awake()
        {
            boardController.OnCreateBoard += OnCreateBoard;
            uiTileMapInputHandler.OnClickTile += OnClickTile;
        }

        void OnClickTile(Vector3Int cell)
        {
            var hex = GetHexCoordinate(cell);
            if (ElementProvider == null)
                RemoveElement(hex);
            else
            {
                var element = ElementProvider.GetElement();
                AddElement(element, hex);
            }
        }

        void OnCreateBoard(IBoard board) => CurrentBoard = board;

        void AddElement(BoardElement element, Hex hex)
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

        void RemoveElement(Hex hex)
        {
            var position = CurrentBoard?.GetPosition(hex);
            if(position == null) 
                return;
            if (!position.HasData())
                return;
            var data = position.Data;
            position.RemoveData();
            OnRemoveElement(data, GetCellCoordinate(hex));
        }

        static Hex GetHexCoordinate(Vector3Int cell) =>
            OffsetCoordHelper.RoffsetToCube(OffsetCoord.Parity.Odd, new OffsetCoord(cell.x, cell.y));

        static Vector3Int GetCellCoordinate(Hex hex) =>
            OffsetCoordHelper.RoffsetFromCube(OffsetCoord.Parity.Odd, hex).ToVector3Int();
    }
}