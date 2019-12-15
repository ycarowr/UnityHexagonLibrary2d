using System;
using System.Collections.Generic;

namespace Tools.LocalData
{
    public static partial class LocalData
    {
        [Serializable]
        public class Data
        {
            public Dictionary<string, string> DataRegister = new Dictionary<string, string>();

            public void Add(string id, string file)
            {
                if (!DataRegister.ContainsKey(id))
                    DataRegister.Add(id, file);
            }

            public string TryGet(string id) => !Has(id) ? null : DataRegister[id];

            public void Remove(string id) => DataRegister.Remove(id);

            public bool Has(string id) => DataRegister.ContainsKey(id);
        }
    }
}