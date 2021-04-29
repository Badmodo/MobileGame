using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCreaturesInArea : MonoBehaviour
{
    //list of creatures in an area
    [SerializeField] List<Creature> wildCreatures;

    //this will return a radom wild creature from list
    //SAM - write script to work with rare pokemon and there chance of showing up - SAM
    public Creature GetRandomWildCreatures()
    {
        var wildCreature = wildCreatures[Random.Range(0, wildCreatures.Count)];
        wildCreature.Initialisation();
        return wildCreature;
    }

}
