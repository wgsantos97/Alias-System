using System.Collections.Generic;
using UnityEngine;
using EmbersOfSteel.AliasSystem.Data;
using EmbersOfSteel.AliasSystem.Spawners;
using Sirenix.OdinInspector;

namespace EmbersOfSteel.AliasSystem.Core
{
    [System.Serializable]
    public class AliasDatabase : MonoBehaviour
    {
        [SerializeField, TabGroup("Alias Spawners"), InfoBox("Add these for any aliases that are dynamically spawned in.")]
        private SpawnerBase[] _spawnerBases;

        [SerializeField, TabGroup("Aliases")]
        private List<AliasData> _aliases = new List<AliasData>();

        private Dictionary<string, List<GameObject>> _aliasDatabase = null;

        private void Awake()
        {
            InitializeDatabase();
            foreach (var spawner in _spawnerBases)
            {
                spawner.SpawnEvent += OnSpawnEvent;
            }
        }

        /// <summary>
        /// Returns the first element of the Alias group.
        /// </summary>
        public GameObject GetFirstAlias(string id)
        {
            return GetAllAliases(id)[0];
        }

        public List<GameObject> GetAllAliases(string id)
        {
            if (_aliasDatabase.ContainsKey(id)) return _aliasDatabase[id];

            Debug.LogWarning("Key '" + id + "' does not exist.");
            return null;
        }

        private void InitializeDatabase()
        {
            _aliasDatabase = new Dictionary<string, List<GameObject>>();
            foreach (AliasData alias in _aliases)
            {
                if (_aliasDatabase.ContainsKey(alias.id))
                {
                    Debug.LogError("Duplicate id detected for key: " + alias.id + ". Alias entry rejected.");
                    return;
                }
                if(alias.references == null)
                {
                    Debug.LogError("GameObject is missing for alias: " + alias.id + ". Alias entry rejected.");
                    return;
                }
                _aliasDatabase[alias.id] = alias.references;
            }
        }

        private void OnSpawnEvent(object sender, SpawnEventArgs e)
        {
            foreach(AliasEntity aliasEntity in e.aliasEntities)
            {
                AddToDatabase(aliasEntity, e);
            }
        }

        private void AddToDatabase(AliasEntity aliasEntity, SpawnEventArgs e)
        {
            if (!aliasEntity.isActiveAlias) return;// Ignore any aliasEntity that is not in use.
            if (_aliasDatabase.ContainsKey(aliasEntity.id))
            {
                _aliasDatabase[aliasEntity.id].Add(e.reference);
            }
            else
            {
                List<GameObject> references = new List<GameObject>() { e.reference };
                _aliasDatabase[aliasEntity.id] = references;
            }
        }
    }
}
