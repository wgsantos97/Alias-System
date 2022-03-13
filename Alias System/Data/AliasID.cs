using System;
using UnityEngine;

namespace EmbersOfSteel.AliasSystem.Data
{
    [Serializable]
    public class AliasID : IEquatable<AliasID>
    {
        [SerializeField]
        private string _id = "";

        public bool Equals(AliasID other)
        {
            return _id == other._id;
        }

        public static implicit operator string(AliasID aliasID) => aliasID._id;
    }
}
