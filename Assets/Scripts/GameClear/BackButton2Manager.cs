using UnityEngine;

public class BackButton2Manager : MonoBehaviour
{
    public GameObject BackButton2;
    public GameClearManager gcm;
    public ItemDetailList idl;
    public void OnClick()
    {
        BackButton2.SetActive(false);

        for(int i=0; i<10; i++)
        { 
             //バツボタンがクリックされたら、アイテム詳細画面を閉じる
            if(idl.ObjectList[i].gameObject.activeSelf == true)
            {
                idl.ObjectList[i].gameObject.SetActive(false);
            }

        }
    }
}
