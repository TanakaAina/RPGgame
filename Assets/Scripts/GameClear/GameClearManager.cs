using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    public GameObject QuestClearText;
    public GameObject BackButton1;
    public GameObject ToTownButton;
    public ItemList IL;
    
    void Start()
    {
        QuestClearText.SetActive(true);
        SoundManager.instance.PlaySE(2);       
        SoundManager.instance.StopBGM();
    }

        bool isCalledOnce = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //処理を一度だけ実行する
            if(!isCalledOnce)
            {
                isCalledOnce = true;
                BackButton1.SetActive(true);
                ShowIcon();
                QuestClearText.SetActive(false);
                SoundManager.instance.PlayGameClearBGM(4);
            }
         }
    }

    public void OnBackButton1()
    {
        ItemIconManager iim = GetComponent<ItemIconManager>();
        DeleteIcon();
        ToTownButton.SetActive(true);
        BackButton1.SetActive(false);
    }

    public void ShowIcon()
    {
        for(int i=0;i<11;i++)
        {
            //アイテムリストからアイテム報酬画像、アイテムアイコンを表示する
            Instantiate(IL.ObjectList[i].gameObject);
            IL.ObjectList[i].SetActive(true);
        }
    }

    public void DeleteIcon()
    {
        for(int i=0;i<11;i++)
        {
            //アイテムリストからアイテム報酬画像、アイテムアイコンを削除する
            Destroy(IL.ObjectList[i].gameObject);
        }
    }

    public void OnToTwonButton()
    {
        SoundManager.instance.PlaySE(0);
        SoundManager.instance.StopBGM();
    }
    
}
