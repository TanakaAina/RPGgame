using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonClickManager : MonoBehaviour
{
    public MenuManager menumanager;
    public void OnBackButton()
    {
        for(int i=0; i<2; i++)
        {
            //アイテム詳細の非表示
            if(menumanager.AttackItemDetail[i].activeSelf == true)
            {
                menumanager.AttackItemDetail[i].SetActive(false);
            }
            else if(menumanager.DefenceItemDetail[i].activeSelf == true)
            {
                menumanager.DefenceItemDetail[i].SetActive(false);
            }
        }
    }
}
