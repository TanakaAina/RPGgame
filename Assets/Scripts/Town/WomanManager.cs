using UnityEngine;

public class WomanManager : MonoBehaviour
{
    public GameObject Woman;
    public GameObject WomanShade;
    public GameObject TextButton;
    public TownManager townmanager;

    void Start()
    {
        Woman.SetActive(false);
        WomanShade.SetActive(true);
        TextButton.SetActive(false);
    }
    public void WomanMove()
    {
        //おばあさんとの会話中は、少年、少女、おじいさんをクリックできないようにする
        townmanager.BoyButton.interactable = false;
        townmanager.GirlButton.interactable = false;
        townmanager.ManButton.interactable = false;
        SoundManager.instance.PlaySE(4);
        Woman.SetActive(true);
        //2秒間処理を待つ
        new WaitForSeconds(2);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"　　　君が勇者かい？\n　　　噂には聞いていたよ。"});
        //会話ログ画面に反映
        TextLogManager.dungeon_log += "\nおばあさん：君が勇者かい？\n　　　　　　噂には聞いていたよ。\n";
        TextLogManager.update_dungeon_log();
        Invoke(nameof(ShowTextButton),0.7f);
    }

    void ShowTextButton()
    {
        TextButton.SetActive(true);
    }

}
