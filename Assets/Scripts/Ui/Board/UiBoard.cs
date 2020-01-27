using HexBoardGame.Runtime;
using HexBoardGame.Runtime.GameBoard;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexBoardGame.UI
{
    public class UiBoard : MonoBehaviour
    {
        [SerializeField] BoardController controller;
        [SerializeField] BoardElementsController elementsController;
        [SerializeField] TileBase test;
        IBoard CurrentBoard { get; set; }
        Tilemap TileMap { get; set; }

        void OnCreateBoard(IBoard board)
        {
            CurrentBoard = board;
            CreateBoardUi();
        }

        void Awake()
        {
            TileMap = GetComponentInChildren<Tilemap>();
            controller.OnCreateBoard += OnCreateBoard;
            elementsController.OnAddElement += OnAddElement;
        }

        void OnAddElement(BoardElement element, Vector3Int cell)
        {
            var data = element.DataProvider;
            var model = data.GetModel();
            var obj = ObjectPooler.Instance.Get(model);
            var uiBoardElement = obj.GetComponent<UiBoardElement>();
            var worldPosition = TileMap.CellToWorld(cell);
            uiBoardElement.SetRuntimeElementData(element);
            uiBoardElement.SetWorldPosition(worldPosition);
        }

        void CreateBoardUi()
        {
            TileMap.ClearAllTiles();
            foreach (var pos in CurrentBoard.Positions)
            {
                var hex = pos.Point;
                var cell = BoardManipulationOddR.GetCellCoordinate(hex);
                TileMap.SetTile(cell, test);
            }
        }
    }
}