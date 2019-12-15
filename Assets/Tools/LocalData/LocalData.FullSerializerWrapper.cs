using System;
using FullSerializer;

namespace Tools.LocalData
{
    public static partial class LocalData
    {
        /// <summary>
        ///     Wrapper for FullSerializer. Ref: https://github.com/jacobdufault/fullserializer.
        /// </summary>
        static class FullSerializer
        {
            static readonly fsSerializer _serializer = new fsSerializer();

            public static string Serialize(Type type, object value, bool isPretty)
            {
                // serialize the data
                fsData data;
                _serializer.TrySerialize(type, value, out data).AssertSuccessWithoutWarnings();

                var json = fsJsonPrinter.CompressedJson(data);

                if (isPretty)
                    json = fsJsonPrinter.PrettyJson(data);

                // emit the data via JSON
                return json;
            }

            public static object Deserialize(Type type, string serializedState)
            {
                // step 1: parse the JSON data
                var data = fsJsonParser.Parse(serializedState);

                // step 2: deserialize the data
                object deserialized = null;
                _serializer.TryDeserialize(data, type, ref deserialized).AssertSuccessWithoutWarnings();

                return deserialized;
            }
        }
    }
}