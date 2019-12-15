using NUnit.Framework;
using Tools.Patterns.StateMachineSO;
using UnityEngine;

namespace Tools.Fsm.Tests
{
    public class FsmTests
    {
        //C# classes 
        readonly State AState = new State();

        //Scriptable Object 
        readonly StateMachine Fsm = ScriptableObject.CreateInstance<StateMachine>();

        [SetUp]
        public void Setup() => Fsm.Clear();

        [Test]
        public void PushState()
        {
            Fsm.PushState(AState);
            Assert.IsTrue(Fsm.IsCurrent(AState));
            Assert.AreEqual(AState, Fsm.Current);
        }

        [Test]
        public void PushCount()
        {
            var countBefore = Fsm.Count;
            Fsm.PushState(AState);
            Assert.AreEqual(++countBefore, Fsm.Count);
        }

        [Test]
        public void PopState()
        {
            Fsm.PushState(AState);
            var popped = Fsm.PopState();
            Assert.AreEqual(AState, popped);
        }

        [Test]
        public void PopCount()
        {
            Fsm.PushState(AState);
            var countBefore = Fsm.Count;
            Fsm.PopState();
            Assert.AreEqual(--countBefore, Fsm.Count);
        }

        [Test]
        public void Init()
        {
            Assert.IsTrue(Fsm.Current == null);
            Assert.IsTrue(Fsm.Count == 0);
        }

        [Test]
        public void Clear()
        {
            Fsm.Clear();
            Assert.AreEqual(0, Fsm.Count);
            Assert.AreEqual(null, Fsm.Current);
        }

        [Test]
        public void IsCurrent()
        {
            Fsm.PushState(AState);
            Assert.AreEqual(AState, Fsm.Current);
            Assert.IsTrue(Fsm.IsCurrent(AState));
        }
    }
}