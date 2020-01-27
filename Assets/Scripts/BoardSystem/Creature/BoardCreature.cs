namespace HexBoardGame.Runtime.GameBoard
{
    public class BoardCreature : BoardElement
    {
        public BoardCreature(CreatureData data) : base(data)
        {
        }

        public CreatureData Data => DataProvider as CreatureData;
    }
}