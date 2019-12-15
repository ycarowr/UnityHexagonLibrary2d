using System;

namespace Tools.Patterns.GenericPooler
{
    public partial class GenericPooler<T>
    {
        public class GenericPoolerArgumentException : ArgumentException
        {
            public GenericPoolerArgumentException(string message) : base(message)
            {
            }
        }
    }
}