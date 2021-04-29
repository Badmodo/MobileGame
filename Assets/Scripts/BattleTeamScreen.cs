using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTeamScreen : MonoBehaviour
{
    [SerializeField] Text messageText;

    BattleTeamUnit[] memberSlots;
    List<Creature> creatures;

    public void Initilised()
    {
        //messed up and didnt add in children, I looked for this for an hour. Sam
        memberSlots = GetComponentsInChildren<BattleTeamUnit>();
    }

    //this in a array gathers all components from the battle team units, can have any number up to 6 creatures
    public void SetPartyData(List<Creature> creatures)
    {
        this.creatures = creatures;
        for (int i = 0; i < memberSlots.Length; i++)
        {
            if (i < creatures.Count)
            {
                memberSlots[i].SetData(creatures[i]);
            }
            else
            {
                //any slots not used will be set inactive
                memberSlots[i].gameObject.SetActive(false);
            }
            messageText.text = "Choose a Creature";
        }
    }

    //runs through list if selected tells to change colour
    public void UpdateMemeberSelection(int selectMember)
    {
        for(int i = 0; i < creatures.Count; i++)
        {
            if(i == selectMember)
            {
                memberSlots[i].SetSelected(true);
            }
            else
            {
                memberSlots[i].SetSelected(false);
            }
        }
    }

    //enables to easily call for a message in team select screen
    public void SetMessageText(string message)
    {
        messageText.text = message;
    }
}
