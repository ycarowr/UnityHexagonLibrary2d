using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    [CreateAssetMenu]
    public class CreatureData : ScriptableObject, IDataProvider
    {
        [SerializeField] private Sprite artwork;
        [SerializeField] private GameObject model;

        public BoardElement GetElement()
        {
            return new BoardCreature(this);
        }

        public Sprite GetArtwork()
        {
            return artwork;
        }

        public GameObject GetModel()
        {
            return model;
        }
    }
}