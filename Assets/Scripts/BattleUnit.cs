using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{

    //[SerializeField] CreatureBase _base;
    //[SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Creature Creature { get; set; }

    Image image;
    Vector3 originalPosition;
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPosition = image.transform.localPosition;
        originalColor = image.color;
    }

    public void Setup(Creature creature)
    {
        Creature = creature;
        if(isPlayerUnit)
        {
            image.sprite = Creature.Base.BackSprite;
        }
        else
        {
            image.sprite = Creature.Base.FrontSprite;

        }

        image.color = originalColor;
        BattleEnterAnimation();
    }

    //on battle start animation where creatures enter from the sides
    public void BattleEnterAnimation()
    {
        if(isPlayerUnit)
        {
            image.transform.localPosition = new Vector3(-1213, originalPosition.y);
        }
        else
        {
            image.transform.localPosition = new Vector3(1213, originalPosition.y);
        }

        image.transform.DOLocalMoveX(originalPosition.x, 1f);
    }

    //very fast image movement showing attacks
    public void BattleAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if(isPlayerUnit)
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPosition.x + 100f, 0.25f));
        }
        else
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPosition.x - 100f, 0.25f));
        }
        //bring images back to original positions
        sequence.Append(image.transform.DOLocalMoveX(originalPosition.x, 0.25f));
    }

    //this uses the dotween color change to quickly change the color of the creature recieving the attack
    public void BattleHitAmination()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.grey, 0.1f));
        sequence.Append(image.DOColor(originalColor, 0.1f));

    }

    //shows a fainting animation of creature dropping through the screen
    public void BattleFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPosition.y - 200f, 0.5f));
        //we use join so they both happen at the same time
        sequence.Join(image.DOFade(0f, 0.5f));
    }
}
