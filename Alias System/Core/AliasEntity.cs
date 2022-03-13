using UnityEngine;
using EmbersOfSteel.AliasSystem.Data;
using Sirenix.OdinInspector;

namespace EmbersOfSteel.AliasSystem.Core
{
    public class AliasEntity : MonoBehaviour
    {
        [SerializeField, HideLabel]
        private AliasID _id = new AliasID();
        public AliasID id => _id;

        [SerializeField, InfoBox("Must be checked in order to be added to the alias system.")]
        private bool _isActiveAlias = false;
        public bool isActiveAlias => _isActiveAlias;
    }
}
