using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GoldManager : Singleton<GoldManager>
{
    public Text moneyText;

    public int Gold
    {
        get
        {
            return GameManager.Instance.Gold;
        }
        set
        {
            GameManager.Instance.Gold = value;
        }
    }

    private void Start()
    {
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        moneyText.text = Gold.ToString();
    }

    public void GoldPlus(int plus)
    {
        Gold += plus;
        UpdateGoldText();
    }

    public bool GoldMinus(int cost)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            Debug.Log($"골드 {cost} 소모");
            UpdateGoldText();
            return true;
        }
        else
        {
            Debug.Log("골드가 부족합니다");
            moneyText.DOComplete();
            moneyText.DOColor(Color.red, 0.15f).SetLoops(2, LoopType.Yoyo);
            return false;
        }
    }
}
