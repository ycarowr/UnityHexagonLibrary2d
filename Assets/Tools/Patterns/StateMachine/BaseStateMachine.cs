using System;
using System.Collections.Generic;

namespace Tools.Patterns.StateMachine
{
    public abstract class BaseStateMachine
    {
        readonly Dictionary<Type, IState> register = new Dictionary<Type, IState>();

        readonly Stack<IState> stack = new Stack<IState>();

        /// <summary> Constructor for the state machine. A handler is optional. </summary>
        protected BaseStateMachine(IStateMachineHandler handler = null) => Handler = handler;

        /// <summary> Boolean that indicates whether the FSM has been initialized or not. </summary>
        public bool IsInitialized { get; protected set; }

        /// <summary> Handler for the FSM. Usually the Monobehavior which holds this FSM. </summary>
        public IStateMachineHandler Handler { get; set; }

        /// <summary> Returns the state on the top of the stack. Can be Null. </summary>
        public IState Current => PeekState();


        /// <summary> Register a state into the state machine. </summary>
        public void RegisterState(IState state)
        {
            if (state == null)
                throw new ArgumentNullException("Null is not a valid state");

            var type = state.GetType();
            register.Add(type, state);
        }

        /// <summary> Initialize all states. All states have to be registered before the initialization. </summary>
        public void Initialize()
        {
            OnBeforeInitialize();
            foreach (var state in register.Values)
                state.OnInitialize();
            IsInitialized = true;
            OnInitialize();
        }

        /// <summary> Do something before the initialization. </summary>
        protected virtual void OnBeforeInitialize()
        {
        }

        /// <summary> Do something after the initialization. </summary>
        protected virtual void OnInitialize()
        {
        }

        /// <summary> Update the state on the top of the stack. </summary>
        public void Update() => Current?.OnUpdate();

        /// <summary> Checks if a state is the current state. </summary>
        public bool IsCurrent<T>() where T : IState => Current?.GetType() == typeof(T);

        /// <summary> Checks if a state is the current state. </summary>
        public bool IsCurrent(IState state)
        {
            if (state == null)
                throw new ArgumentNullException();

            return Current?.GetType() == state.GetType();
        }

        /// <summary> Pushes a state </summary>
        public void PushState<T>(bool isSilent = false) where T : IState
        {
            var stateType = typeof(T);
            var state = register[stateType];
            PushState(state, isSilent);
        }

        /// <summary> Pushes a state </summary>
        public void PushState(IState state, bool isSilent = false)
        {
            var type = state.GetType();
            if (!register.ContainsKey(type))
                throw new ArgumentException("State " + state + " not registered yet.");

            if (stack.Count > 0 && !isSilent)
                Current?.OnExitState();

            stack.Push(state);
            state.OnEnterState();
        }

        /// <summary> Peeks a state from the stack. A peek returns null if the stack is empty. It doesn't trigger any call. </summary>
        public IState PeekState() => stack.Count > 0 ? stack.Peek() : null;

        /// <summary> Pops a state from the stack. </summary>
        public IState PopState(bool isSilent = false)
        {
            if (Current == null)
                return null;

            var state = stack.Pop();
            state.OnExitState();

            if (!isSilent)
                Current?.OnEnterState();
            return state;
        }

        /// <summary> Clears and restart the states register. </summary>
        public virtual void Clear()
        {
            foreach (var state in register.Values)
                state.OnClear();

            stack.Clear();
            register.Clear();
        }
    }
}