using UnityEngine;

namespace BreadAndButter.Loot
{
    [CreateAssetMenu(menuName = "Bread and Butter/Loot/Lootable", fileName = "NewLootable")]
    public class Lootable : ScriptableObject
    {
        [SerializeField]
        protected string itemName = " ";
        [SerializeField, TextArea]
        protected string description = " ";
        [SerializeField]
        protected Sprite sprite;        
    }

}