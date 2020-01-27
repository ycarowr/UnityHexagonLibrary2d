using HexBoardGame.Runtime.GameBoard;
using UnityEngine;

namespace HexBoardGame.UI
{
    public class UiBoardElement : MonoBehaviour
    {
        BoardElement RuntimeData { get; set; }
        SpriteRenderer SpriteRenderer { get; set; }
        Transform Transform { get; set; }

        protected virtual void Awake()
        {
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

            Transform = transform;
        }

        public void SetRuntimeElementData(BoardElement data)
        {
            RuntimeData = data;
            UpdateView();
        }

        public void SetWorldPosition(Vector3 position) => Transform.position = position;

        void UpdateView() => SpriteRenderer.sprite = RuntimeData.DataProvider.GetArtwork();
    }
}