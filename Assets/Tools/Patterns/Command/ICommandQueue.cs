using System;

namespace Tools.Patterns.Command
{
    /// <summary> Interface for a command queue. </summary>
    public interface ICommandQueue<T> where T : Command
    {
        /// <summary> Dispatched when the queue is empty. </summary>
        Action OnEmpty { get; set; }

        /// <summary> Whether the queue has zero elements or more. </summary>
        bool IsEmpty { get; }

        /// <summary> Current size of the queue. </summary>
        int Size { get; }

        /// <summary> Removes the first element to arrive in the queue. </summary>
        T Dequeue();

        /// <summary> Puts another element in the queue to be processed. </summary>
        void Enqueue(T command);
    }
}