using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RockPaperScissors
{
    //used to create directly from the Project menu
    [CreateAssetMenu(fileName = "Character", menuName = "Character/Create new Character")]
    public class Stats : ScriptableObject
    {
        [SerializeField] string name;

        [TextArea]
        [SerializeField] string description;

        [SerializeField] CharacterType type1;
        [SerializeField] CharacterType type2;

        // Base Stats
        [SerializeField] int maxHp;
        [SerializeField] int attack;
        [SerializeField] int defense;
        [SerializeField] int specialAttack;
        [SerializeField] int specialDefense;
        [SerializeField] int speed;

        [SerializeField] int expYield;
        [SerializeField] GrowthRate growthRate;

        [SerializeField] List<LearnableMove> learnableMoves;

        public int GetExpForLevel(int level)
        {
            if (growthRate == GrowthRate.Fast)
            {
                return 4 * (level * level * level) / 5;
            }
            else if (growthRate == GrowthRate.MediumFast)
            {
                return level * level * level;
            }

            return -1;
        }

        //using property instead, these allow me to pick up these variables in other scripts
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
        }
        public CharacterType Type1
        {
            get { return type1; }
        }
        public CharacterType Type2
        {
            get { return type2; }
        }
        public int MaxHp
        {
            get { return maxHp; }
        }
        public int Attack
        {
            get { return attack; }
        }
        public int Defense
        {
            get { return defense; }
        }
        public int SpecialAttack
        {
            get { return specialAttack; }
        }
        public int SpecialDefense
        {
            get { return specialDefense; }
        }
        public int Speed
        {
            get { return speed; }
        }

        public int ExpYield
        {
            get { return expYield; }
        }

        public List<LearnableMove> LearnableMoves
        {
            get
            {
                return learnableMoves;
            }
        }

        //serilizable so it can be seen in inspector
        [System.Serializable]
        public class LearnableMove
        {
            [SerializeField] MoveBase moveBase;
            [SerializeField] int level;

            public MoveBase Base
            {
                get
                {
                    return moveBase;
                }
            }
            public int Level
            {
                get
                {
                    return level;
                }
            }
        }

        //Types to show up in drop down for type select
        public enum CharacterType
        {
            None,
            Normal,
            Fire,
            Water,
            Electric,
            Grass,
            Ice,
            Fighting,
            Poison,
            Ground,
            Flying,
            Psychic,
            Bug,
            Rock,
            Ghost,
            Dragon,
            Dark,
            Steel,
            Fairy
        }

        public enum GrowthRate
        {
            Fast, MediumFast
        }
        public enum Stat
        {
            Attack,
            Defense,
            SpecialAttack,
            SpecialDefence,
            Speed,
            //below are accuracy stats
            Accuracy,
            Evasion
        }

        //this is the totallity of the effectivness in a pokemon game, the order needs to be the same as the CreatureType
        public class CharacterTypeChart
        {
            //2d array [][]
            static float[][] chart =
            {
         //                       Nor   Fir   Wat   Ele   Gra   Ice   Fig   Poi   Gro   Fly   Psy   Bug   Roc   Gho   Dra   Dar  Ste    Fai
        /*Normal*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 0,    1f,   1f,   0.5f, 1f},
        /*Fire*/    new float[] {1f,   0.5f, 0.5f, 1f,   2f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f, 1f,   2f,   1f},
        /*Water*/   new float[] {1f,   2f,   0.5f, 1f,   0.5f, 1f,   1f,   1f,   2f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f,   1f,   1f},
        /*Electric*/new float[] {1f,   1f,   2f,   0.5f, 0.5f, 1f,   1f,   1f,   0f,   2f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   1f},
        /*Grass*/   new float[] {1f,   0.5f, 2f,   1f,   0.5f, 1f,   1f,   0.5f, 2f,   0.5f, 1f,   0.5f, 2f,   1f,   0.5f, 1f,   0.5f, 1f},
        /*Ice*/     new float[] {1f,   0.5f, 0.5f, 1f,   2f,   0.5f, 1f,   1f,   2f,   2f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f},
        /*Fighting*/new float[] {2f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f,   0.5f, 0.5f, 0.5f, 2f,   0f,   1f,   2f,   2f,   0.5f},
        /*Poison*/  new float[] {1f,   1f,   1f,   1f,   2f,   1f,   1f,   0.5f, 0.5f, 1f,   1f,   1f,   0.5f, 0.5f, 1f,   1f,   0f,   2f},
        /*Ground*/  new float[] {1f,   2f,   1f,   2f,   0.5f, 1f,   1f,   2f,   1f,   0f,   1f,   0.5f, 2f,   1f,   1f,   1f,   2f,   1f},
        /*Flying*/  new float[] {1f,   1f,   1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   0.5f, 1f},
        /*Psychic*/ new float[] {1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   1f,   1f,   0.5f, 1f,   1f,   1f,   1f,   0f,   0.5f, 1f},
        /*Bug*/     new float[] {1f,   0.5f, 1f,   1f,   2f,   1f,   0.5f, 0.5f, 1f,   0.5f, 2f,   1f,   1f,   0.5f, 1f,   2f,   0.5f, 0.5f},
        /*Rock*/    new float[] {1f,   2f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,   1f,   0.5f, 1f},
        /*Ghost*/   new float[] {0f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   2f,   1f,   0.5f, 1f,   1f},
        /*Dragon*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 0f},
        /*Dark*/    new float[] {1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   1f,   2f,   1f,   1f,   2f,   1f,   0.5f, 1f,   0.5f},
        /*Steel*/   new float[] {1f,   0.5f, 0.5f, 0.5f, 1f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   0.5f, 2f},
        /*Fairy*/   new float[] {1f,   0.5f, 1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   0.5f, 1f}
    };

            //draw data from the chart to determin the Effectiveness an Non-Effectiveness of creatures
            public static float GetEffectiveness(CreatureType attackType, CreatureType defenceType)
            {
                if (attackType == CreatureType.None || defenceType == CreatureType.None)
                {
                    return 1;
                }

                int row = (int)attackType - 1;
                int col = (int)defenceType - 1;

                return chart[row][col];
            }
        }
    }
}