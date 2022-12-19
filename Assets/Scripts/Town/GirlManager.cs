using UnityEngine;

public class GirlManager : MonoBehaviour
{
    public GameObject Girl;
    public GameObject GirlShade;
    public GameObject TextButton;
    public TownManager townmanager;

    void Start()
    {
        Girl.SetActive(false);
        GirlShade.SetActive(true);
    }
    public void GirlMove()
    {
        //少女との会話中は、少年、おばあさん、おじいさんをクリックできないようにする
        townmanager.BoyButton.interactable = false;
        townmanager.WomanButton.interactable = false;
        townmanager.ManButton.interactable = false;
        SoundManager.instance.PlaySE(4);
        Girl.SetActive(true);
        //2秒間処理を待つ
        new WaitForSeconds(2);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"　　　森の奥には凶悪なモンスター\n　　　が潜んでいるの。"});
        //会話ログ画面に反映
        TextLogManager.dungeon_log += "\n少女：森の奥には凶悪なモンスターが潜んでいるの。\n";
        TextLogManager.update_dungeon_log();
        Invoke(nameof(ShowTextButton),0.7f);

    }

    void ShowTextButton()
    {
        TextButton.SetActive(true);
    }

}
