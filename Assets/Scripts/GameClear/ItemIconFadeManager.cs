using UnityEngine;
using DG.Tweening;

public class ItemIconFadeManager : MonoBehaviour
{
    void Start()
    {
        //アイテムアイコン画像のフェードイン
        ItemIconFadeManager Item = this;
        SpriteRenderer questBGSpriteRenderer = Item.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 0)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 1));
    }

}

