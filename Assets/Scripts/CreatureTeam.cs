using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureTeam : MonoBehaviour
{
    [SerializeField] List<Creature> creatures;

    public List<Creature> Creatures
    {
        get
        {
            return creatures;
        }
    }

    private void Start()
    {
        foreach(var creature in creatures)
        {
            creature.Initialisation();
        }
    }

    //when called return the first creature that is not Fainted
    public Creature GetHealthyCreature()
    {
        //origianlly used a for loop to find a creature that had not fainted. Linq used instead
        return creatures.Where(x => x.HP > 0).FirstOrDefault();
    }
}
