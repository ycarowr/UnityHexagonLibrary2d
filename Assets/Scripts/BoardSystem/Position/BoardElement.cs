using UnityEngine;

namespace HexBoardGame.Runtime.GameBoard
{
    /// <summary>
    ///     Any kind of data which can be positioned onto the board.
    ///     <remarks> Inherit this class to create itens, monsters and stuff to populate the board. </remarks>
    ///     >
    /// </summary>
    public abstract class BoardElement
    {
        protected BoardElement(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public IDataProvider DataProvider { get; }
    }

    public interface IDataProvider
    {
        BoardElement GetElement();
        GameObject GetModel();
        Sprite GetArtwork();
    }
}