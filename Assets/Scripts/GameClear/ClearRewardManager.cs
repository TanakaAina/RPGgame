using UnityEngine;
using DG.Tweening;

public class ClearRewardManager : MonoBehaviour
{
    void Start()
    {
        //クリア報酬画面のフェードイン
        ClearRewardManager ClearReward = this;
        SpriteRenderer questBGSpriteRenderer = ClearReward.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 0)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 1));
    }
}
