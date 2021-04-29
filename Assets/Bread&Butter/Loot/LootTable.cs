using System.Collections.Generic;
using UnityEngine;

using Serializable = System.SerializableAttribute;

namespace BreadAndButter.Loot
{
    [CreateAssetMenu(menuName = "Bread and Butter/Loot/LootTable", fileName = "NewLootTable")]
    public class LootTable : ScriptableObject
    {
        [Serializable]
        public class WeightedLoot
        {
            [SerializeField, Range(1, 100)]
            protected int weighting = 50;

            [SerializeField]
            protected Lootable loot;
            

            public void AddLootToTable(ref List<Lootable> _table)
            {
                for(int i = 0; i < weighting; i++)
                {
                    _table.Add(loot);
                }
            }
        }

        [SerializeField]
        private WeightedLoot[] possibleLoot;

        private List<Lootable> table = new List<Lootable>();

        public void GenerateTable()
        {
            table.Clear();

            foreach (WeightedLoot loot in possibleLoot)
            {
                loot.AddLootToTable(ref table);
            }
        }


        public void FillContents(ref List<Lootable> _contents, int _count)
        {
            for (int i = 0; i < _count; i++)
            {
                _contents.Add(GenerateLoot());
            }
        }

        public Lootable GenerateLoot()
        {
            // if the table is empty, fill it
            if(table.Count == 0)
            {
                // fill the table
                foreach(WeightedLoot loot in possibleLoot)
                {
                    loot.AddLootToTable(ref table);
                }
            }

            return table[Random.Range(0, table.Count - 1)];
        }
    }
}