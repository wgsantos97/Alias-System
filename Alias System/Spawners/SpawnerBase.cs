using System;
using System.Linq;
using UnityEngine;
using EmbersOfSteel.AliasSystem.Core;

namespace EmbersOfSteel.AliasSystem.Spawners
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        public event EventHandler<SpawnEventArgs> SpawnEvent;

        /// <summary>
        /// Called to register a gameObject as an alias.
        /// </summary>
        /// <param name="aliasEntity">The alias containing the ID to assign to the reference.</param>
        /// <param name="reference">The target gameObject to store in the alias system.</param>
        protected void InvokeSpawnEvent(GameObject aliasEntity, GameObject reference)
        {
            SpawnEventArgs spawnEventArgs = new SpawnEventArgs(aliasEntity.GetComponents<AliasEntity>().ToList(), reference);
            SpawnEvent?.Invoke(this, spawnEventArgs);
        }
    }
}
