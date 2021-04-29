using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BreadAndButter.Loot
{
    public class LootContainer : MonoBehaviour
    {

        [SerializeField]
        protected LootTable lootTable;
        [SerializeField, Range(1, 17)]
        protected int lootCount = 5;

        protected List<Lootable> contents = new List<Lootable>();


        // Start is called before the first frame update
        protected virtual void Start()
        {
            lootTable.FillContents(ref contents, lootCount);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}