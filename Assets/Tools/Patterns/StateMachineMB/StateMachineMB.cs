using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Patterns.StateMachineMB
{
    public abstract class StateMachineMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        readonly Stack<StateMB<T>> stack = new Stack<StateMB<T>>();
        readonly Dictionary<Type, StateMB<T>> statesRegister = new Dictionary<Type, StateMB<T>>();
        public bool EnableLogs = true;

        public bool IsInitialized { get; private set; }
        //--------------------------------------------------------------------------------------------------------------

        void Log(string log, string colorName = "black")
        {
            if (EnableLogs)
            {
                log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
                Debug.Log(log);
            }
        }


        /// <summary> Register all the states </summary>
        public void Initialize()
        {
            OnBeforeInitialize();
            var allStates = GetComponents<StateMB<T>>();
            foreach (var state in allStates)
            {
                var type = state.GetType();
                statesRegister.Add(type, state);
                state.InjectStateMachine(this);
            }

            IsInitialized = true;
            OnInitialize();
            Log("Initialized!", "green");
        }

        /// <summary>
        ///     If you need to do something before the initialization, override this method.
        /// </summary>
        protected virtual void OnBeforeInitialize()
        {
        }

        /// <summary>
        ///     If you need to do something after the initialization, override this method.
        /// </summary>
        protected virtual void OnInitialize()
        {
        }

        #region Unity Callbacks

        /// <summary>
        ///     Initialize the BaseStateMachine and Awake all registered states
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();

            foreach (var state in statesRegister.Values)
                state.OnAwake();

            Log("States Awaken", "blue");
        }

        /// <summary>
        ///     Start all registered states
        /// </summary>
        protected virtual void Start()
        {
            foreach (var state in statesRegister.Values)
                state.OnStart();

            Log("States Started", "blue");
        }


        /// <summary>
        ///     Update all registered states (uncomment it if you need this callback).
        ///     TODO: Consider to replace 'foreach' by 'for' to minimize the garbage collection.
        /// </summary>
        protected virtual void Update()
        {
            var current = PeekState();
            if (current != null)
                current.OnUpdate();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        # region Operations

        /// <summary>
        ///     Checks if a an StateType is the current state.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        public bool IsCurrent<T1>() where T1 : StateMB<T>
        {
            var current = PeekState();
            if (current == null)
                return false;
            return current.GetType() == typeof(T1);
        }

        /// <summary>
        ///     Checks if a an StateType is the current state.
        /// </summary>
        public bool IsCurrent(StateMB<T> state)
        {
            if (state == null)
                throw new ArgumentNullException();

            var current = PeekState();
            if (current == null)
                return false;
            return current.GetType() == state.GetType();
        }


        /// <summary>
        ///     Pushes a state by Type triggering OnEnterState for the pushed
        ///     state and OnExitState for the previous state in the stack.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        public void PushState<T1>(bool isSilent = false) where T1 : StateMB<T>
        {
            var stateType = typeof(T1);
            var state = statesRegister[stateType];
            PushState(state, isSilent);
        }

        /// <summary>
        ///     Pushes state by instance of the class triggering OnEnterState for the
        ///     pushed state and if not silent OnExitState for the previous state in the stack.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="isSilent"></param>
        public void PushState(StateMB<T> state, bool isSilent = false)
        {
            if (!statesRegister.ContainsKey(state.GetType()))
                throw new ArgumentException("State " + state + " not registered yet.");

            Log("Operation: Push, state: " + state.GetType(), "purple");
            if (stack.Count > 0 && !isSilent)
            {
                var previous = stack.Peek();
                previous.OnExitState();
            }

            stack.Push(state);
            state.OnEnterState();
        }

        /// <summary>
        ///     Peeks a state from the stack. A peek returns null if the stack is empty. It doesn't trigger any call.
        /// </summary>
        /// <returns></returns>
        public StateMB<T> PeekState()
        {
            StateMB<T> state = null;

            if (stack.Count > 0)
                state = stack.Peek();

            return state;
        }

        /// <summary>
        ///     Pops a state from the stack. It triggers OnExitState for the
        ///     popped state and if not silent OnEnterState for the subsequent stacked state.
        /// </summary>
        /// <param name="isSilent"></param>
        public void PopState(bool isSilent = false)
        {
            if (stack.Count > 0)
            {
                var state = stack.Pop();
                Log("Operation: Pop, state: " + state.GetType(), "purple");
                state.OnExitState();
            }

            if (stack.Count > 0 && !isSilent)
            {
                var state = stack.Peek();
                state.OnEnterState();
            }
        }

        #endregion
    }
}