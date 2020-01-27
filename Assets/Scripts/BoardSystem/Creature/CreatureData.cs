using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    [CreateAssetMenu]
    public class CreatureData : ScriptableObject, IDataProvider
    {
        [SerializeField] Sprite artwork;
        [SerializeField] GameObject model;

        public BoardElement GetElement() => new BoardCreature(this);
        public Sprite GetArtwork() => artwork;
        public GameObject GetModel() => model;
    }
}