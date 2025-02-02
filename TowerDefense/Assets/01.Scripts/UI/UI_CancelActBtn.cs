using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CancelActBtn : MonoBehaviour
{
    public ActData actData = null;
    public Button cancleActBtn;
    public int actStackCount = 0;
    public int idx = 0;

    public Image monsterImg;
    public Text countText;

    public void Stack() // 쌓기
    {
        actStackCount++;
        countText.text = actStackCount.ToString();
    }

    public void Cancel()
    {
        InvadeManager.Instance.curSpawnMonsterCount--;
        actStackCount--;
        countText.text = actStackCount.ToString();
        DestroyCheck();
    }

    public void Init(ActData actData)
    {
        this.actData = actData;
        this.monsterImg.sprite = GameManager.Instance.GetActBtnSprite(actData.monsterType);
        this.name = actData.monsterType.ToString();
    }
        
    public void DestroyCheck() // todo 풀매니저
    {
        if (actStackCount == 0)
        {
            InvadeManager im = InvadeManager.Instance;
            im.waitingActs.Remove(this);

            if (im.waitingActs.Count > 0)
            {
                im.addedAct = im.waitingActs[im.waitingActs.Count - 1].actData;
                im.addedBtn = im.waitingActs[im.waitingActs.Count - 1];
                InvadeManager.Instance.OnBtnRemoved(idx);
            }
            else
            {
                im.addedBtn = null;
                im.addedAct = null;
            }

            Destroy(this.gameObject);
        }
    }
}
