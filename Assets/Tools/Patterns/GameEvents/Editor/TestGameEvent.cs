using NUnit.Framework;
using Tools.Patterns.Observer;
using UnityEngine;

namespace Tools.Patterns.GameEvents.Editor
{
    public class TestGameEvent : IListener, ISampleEvent1, ISampleEvent2
    {
        readonly int sampleArgument = 1123412351;
        readonly int sampleArgument2 = 812391722;
        readonly int sampleArgument3 = 817239812;
        GameEvents GameEvents { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void ISampleEvent1.OnISampleEvent1(int a) => Assert.True(a == sampleArgument);

        public void OnISampleEvent2(int a, int b)
        {
            //check if received parameters are the same as sent
            Assert.True(a == sampleArgument2);
            Assert.True(b == sampleArgument3);
        }

        [SetUp]
        public void Setup()
        {
            if (!GameEvents)
            {
                // create observer
                GameEvents = new GameObject("GameEvents").AddComponent<GameEvents>();

                //subscribe
                GameEvents.AddListener(this);
            }
        }

        [Test]
        public void Dispatch1() => GameEvents.Notify<ISampleEvent1>(j => j.OnISampleEvent1(sampleArgument));

        [Test]
        public void Dispatch2() =>
            GameEvents.Notify<ISampleEvent2>(j => j.OnISampleEvent2(sampleArgument2, sampleArgument3));
    }

    /// <summary>
    ///     Broadcast of the event to the Listeners.
    /// </summary>
    public interface ISampleEvent1 : ISubject
    {
        void OnISampleEvent1(int a);
    }

    /// <summary>
    ///     Broadcast of the event to the Listeners.
    /// </summary>
    public interface ISampleEvent2 : ISubject
    {
        void OnISampleEvent2(int a, int b);
    }
}