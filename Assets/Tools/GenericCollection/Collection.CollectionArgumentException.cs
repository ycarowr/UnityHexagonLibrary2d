using System;

namespace Tools.GenericCollection
{
    public partial class Collection<T>
    {
        public class CollectionArgumentException : ArgumentException
        {
            public CollectionArgumentException(string message) : base(message)
            {
            }
        }
    }
}