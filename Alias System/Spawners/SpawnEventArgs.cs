using System;
using System.Collections.Generic;
using UnityEngine;
using EmbersOfSteel.AliasSystem.Core;

namespace EmbersOfSteel.AliasSystem.Spawners
{
    public class SpawnEventArgs : EventArgs
    {
        public readonly List<AliasEntity> aliasEntities;
        public readonly GameObject reference;

        public SpawnEventArgs(List<AliasEntity> aliasEntities, GameObject reference)
        {
            this.aliasEntities = aliasEntities;
            this.reference = reference;
        }
    }
}
