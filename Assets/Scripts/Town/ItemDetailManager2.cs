using UnityEngine;

public class ItemDetailManager2 : MonoBehaviour
{
    public MenuManager menumanager;
    //アイテム詳細画面の表示
    public void OnAttackItem1()
    {
        if(menumanager.AttackItemDetail[1].activeSelf == true)
        {
            menumanager.AttackItemDetail[1].SetActive(false);
        }
        menumanager.AttackItemDetail[0].SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void OnAttackItem2()
    {
        if(menumanager.AttackItemDetail[0].activeSelf == true)
        {
            menumanager.AttackItemDetail[0].SetActive(false);
        }
        menumanager.AttackItemDetail[1].SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void OnDefenceItem1()
    {
        if(menumanager.DefenceItemDetail[1].activeSelf == true)
        {
            menumanager.DefenceItemDetail[1].SetActive(false);
        }
        menumanager.DefenceItemDetail[0].SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void OnDefenceItem2()
    {
        if(menumanager.DefenceItemDetail[0].activeSelf == true)
        {
            menumanager.DefenceItemDetail[0].SetActive(false);
        }
        menumanager.DefenceItemDetail[1].SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
}
