using UnityEngine;
using DG.Tweening;

public class TitleUI : MonoBehaviour
{
    public TitleManager InputUI;
    public TitleManager Button;
    void Start()
    {
        //タイトルシーンのフェードイン
        SpriteRenderer TitleSpriteRenderer = InputUI.GetComponent<SpriteRenderer>();
        TitleSpriteRenderer.DOFade(0, 0)
            .OnComplete(() => TitleSpriteRenderer.DOFade(1, 1));
    }

}
