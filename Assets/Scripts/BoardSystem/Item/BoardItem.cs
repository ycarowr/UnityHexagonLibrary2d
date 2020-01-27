namespace HexBoardGame.Runtime.GameBoard
{
    public class BoardItem : BoardElement
    {
        public BoardItem(ItemData data) : base(data)
        {
        }

        public ItemData Data => DataProvider as ItemData;
    }
}