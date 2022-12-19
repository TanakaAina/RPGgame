using UnityEngine;

public class ManManager : MonoBehaviour
{
    public GameObject Man;
    public GameObject ManShade;
    public GameObject TextButton;
    public TownManager townmanager;

    void Start()
    {
        Man.SetActive(false);
        ManShade.SetActive(true);
        TextButton.SetActive(false);
    }
    public void ManMove()
    {
        //おじいさんとの会話中は、少年、おばあさん、少女をクリックできないようにする
        townmanager.BoyButton.interactable = false;
        townmanager.WomanButton.interactable = false;
        townmanager.GirlButton.interactable = false;
        SoundManager.instance.PlaySE(4);
        Man.SetActive(true);
        //2秒間処理を待つ
        new WaitForSeconds(2);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"　　　気を付けて行くんじゃぞ。"});
        //会話ログ画面に反映
        TextLogManager.dungeon_log += "\nおじいさん：気を付けて行くんじゃぞ。\n";
        TextLogManager.update_dungeon_log();
        Invoke(nameof(ShowTextButton),0.7f);
    }

    void ShowTextButton()
    {
        TextButton.SetActive(true);
    }

}
