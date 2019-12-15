namespace HexCardGame.UI
{
    public interface IUiInputElement
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}