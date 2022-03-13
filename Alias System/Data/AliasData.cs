using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace EmbersOfSteel.AliasSystem.Data
{
    [System.Serializable]
    public class AliasData
    {
        [SerializeField, HideLabel]
        private AliasID _id = new AliasID();
        public AliasID id => _id;

        [SerializeField]
        private List<GameObject> _references = new List<GameObject>();

        public List<GameObject> references => _references;
    }
}
