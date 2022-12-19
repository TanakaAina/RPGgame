using UnityEngine;

public class BoyManager : MonoBehaviour
{
    public GameObject Boy;
    public GameObject BoyShade;
    public GameObject TextButton;
    public TownManager townmanager;


    void Start()
    {
        Boy.SetActive(false);
        BoyShade.SetActive(true);
        TextButton.SetActive(false);
    }
    public void BoyMove()
    {   
        //少年との会話中は、おばあさん、少女、おじいさんをクリックできないようにする
        townmanager.WomanButton.interactable = false;
        townmanager.GirlButton.interactable = false;
        townmanager.ManButton.interactable = false;
        SoundManager.instance.PlaySE(4);
        Boy.SetActive(true);
        //2秒間処理を待つ
        new WaitForSeconds(2);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"　　　森を抜けた先にお宝が眠って\n　　　いるんだ。"});
        //会話ログ画面に反映
        TextLogManager.dungeon_log += "\n少年：森を抜けた先にお宝が眠っているんだ。\n";
        TextLogManager.update_dungeon_log();
        Invoke(nameof(ShowTextButton), 0.7f);
    }

    void ShowTextButton()
    {
        TextButton.SetActive(true);
    }

}
