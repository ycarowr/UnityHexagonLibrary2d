using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    [CreateAssetMenu]
    public class ItemData : ScriptableObject, IDataProvider
    {
        [SerializeField] Sprite artwork;
        [SerializeField] GameObject model;
        public BoardElement GetElement() => new BoardItem(this);
        public Sprite GetArtwork() => artwork;
        public GameObject GetModel() => model;
    }
}