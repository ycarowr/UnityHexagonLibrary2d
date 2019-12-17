namespace HexCardGame.Runtime
{
    public static class ArrayExtensions
    {
        public static T[] Merge<T>(this T[] array, T[] other)
        {
            var size = array.Length + other.Length;
            var merge = new T[size];
            var count = 0;
            for (var i = 0; i < array.Length; i++)
            {
                merge[count] = array[i];
                count++;
            }

            for (var i = 0; i < other.Length; i++)
            {
                merge[count] = other[i];
                count++;
            }

            return merge;
        }
    }
}