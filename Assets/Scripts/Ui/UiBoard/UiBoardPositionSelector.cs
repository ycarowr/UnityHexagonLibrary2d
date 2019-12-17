using Game.Ui;
using HexCardGame.Runtime;
using UnityEngine;

namespace HexCardGame.UI
{
    [Event]
    public interface ISelectBoardPosition
    {
        void OnSelectBoardPosition(Vector3Int cell);
    }

    [RequireComponent(typeof(ITileMapInput))]
    public class UiBoardPositionSelector : UiEventListener, IUiInputElement, IOnClickTile
    {
        void IOnClickTile.OnClickTile(Vector3Int cell)
        {
            if (IsLocked) return;
            Dispatcher.Notify<ISelectBoardPosition>(i => i.OnSelectBoardPosition(cell));
        }

        public bool IsLocked { get; private set; }
        public void Lock() => IsLocked = true;
        public void Unlock() => IsLocked = false;
    }
}