using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BreadAndButter.Loot
{

    public class LootManager : MonoSingleton<LootManager>
    {

        [SerializeField]
        private List<LootTable> tables = new List<LootTable>();

        private void Awake()
        {
            CreateInstance();
            FlagAsPersistant();

            tables.ForEach((table) => table.GenerateTable());
        }
    }
}