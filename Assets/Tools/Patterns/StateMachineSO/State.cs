namespace Tools.Patterns.StateMachineSO
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
        void Clear();
    }

    public class State : IState
    {
        void IState.Clear() => OnClearState();

        void IState.Enter() => OnEnterState();

        void IState.Exit() => OnExitState();

        void IState.Update() => OnUpdateState();

        protected virtual void OnInitializeState()
        {
        }

        protected virtual void OnEnterState()
        {
        }

        protected virtual void OnExitState()
        {
        }

        protected virtual void OnUpdateState()
        {
        }

        protected virtual void OnClearState()
        {
        }
    }
}