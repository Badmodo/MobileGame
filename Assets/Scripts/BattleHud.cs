//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BattleHud : MonoBehaviour
//{

//    [SerializeField] Text nameText;
//    [SerializeField] Text levelText;
//    [SerializeField] HPBar hpBar;

//    Creature _creature;

//    public void SetData(Creature creature)
//    {
//        _creature = creature;

//        nameText.text = creature.Base.Name;
//        levelText.text = "Lvl" + creature.Level;
//        hpBar.SetHp((float)creature.HP / creature.MaxHp);
//    }

//    //updates the Hp loss with a smooth transition
//    public IEnumerator UpdateHP()
//    {
//        yield return hpBar.SetHPSmooth((float)_creature.HP / _creature.MaxHp);
//    }
//}
