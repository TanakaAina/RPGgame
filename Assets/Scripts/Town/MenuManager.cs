using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Log;
    public GameObject Button;
    public GameObject ItemList;
    public GameObject Map;
    public GameObject Text;
    public BoyManager boymanager;
    public GirlManager girlmanager;
    public WomanManager womanmanager;
    public ManManager manmanager;
    public GameObject ItemButton;
    public GameObject[] ItemImage = new GameObject[2];
    public GameObject[] AttackItemDetail = new GameObject[2];
    public GameObject[] DefenceItemDetail = new GameObject[2];

    [SerializeField] Text colorText;


    void Start()
    {
        Log.SetActive(true);
        ItemList.SetActive(false);
        Map.SetActive(false);
        Text.SetActive(false);
        ItemButton.SetActive(false);
        for(int i=0; i<2; i++)
        {
            ItemImage[i].SetActive(false);
            AttackItemDetail[i].SetActive(false);
            DefenceItemDetail[i].SetActive(false);
        }
    }
    public void OnLogButton()
    {
        //アイテム一覧の非表示
        DeleteItem();
        //マップの非表示
        DeleteMap();
        Log.SetActive(true);
        //会話ログの表示位置を変更
        Transform transform1 = Log.transform;
        Vector2 pos1 = transform1.position;
        pos1.x += 1200;
        Log.transform.position = pos1;
        SoundManager.instance.PlaySE(0); 
    }
    public void OnMapButton()
    {
        //アイテム一覧の非表示
        DeleteItem();
        //会話ログの非表示
        DeleteLog();
        Map.SetActive(true);
        SoundManager.instance.PlaySE(0); 
    }
    public void OnItemButton()
    {
        //会話ログの非表示
        DeleteLog();
        //マップの非表示
        DeleteMap();
        ItemList.SetActive(true);
        ItemButton.SetActive(true);
        SoundManager.instance.PlaySE(0); 
    }
    public void OnToTitleButton()
    {
        SoundManager.instance.PlaySE(0); 
    }
    public void OnBackButton()
    {
        //アイテム一覧の非表示
        DeleteItem();
        //マップの非表示
        DeleteMap();
        //会話ログの非表示
        DeleteLog();
    }
    public void OnAttackItemButton()
    {
        //防御アイテムが表示されている場合、防御アイテムを非表示にする
        if(ItemImage[1].activeSelf == true)
        {
            ItemImage[1].SetActive(false);
        }
        //その他アイテム画面が表示されている場合、その他アイテム画面を非表示にする
        else if(Text.activeSelf == true)
        {
            Text.SetActive(false);
        }
        //アイテム詳細画面が表示されている場合、アイテム詳細画面を非表示にする
        DeleteItemDetail();
        ItemImage[0].SetActive(true);
        SoundManager.instance.PlaySE(5); 
    }

    public void OnDefenceItemButton()
    {
        //攻撃アイテムが表示されている場合、攻撃アイテムを非表示にする
        if(ItemImage[0].activeSelf == true)
        {
            ItemImage[0].SetActive(false);
        }
        //その他アイテム画面が表示されている場合、その他アイテム画面を非表示にする
        else if(Text.activeSelf == true)
        {
            Text.SetActive(false);
        }
        //アイテム詳細画面が表示されている場合、アイテム詳細画面を非表示にする
        DeleteItemDetail();
        ItemImage[1].SetActive(true);
        SoundManager.instance.PlaySE(5); 
    }

    public void OnOthersItemButton()
    {
        //攻撃アイテムが表示されている場合、攻撃アイテムを非表示にする
        if(ItemImage[0].activeSelf == true)
        {
            ItemImage[0].SetActive(false);
        }
        //防御アイテムが表示されている場合、防御アイテムを非表示にする
        else if(ItemImage[1].activeSelf == true)
        {
            ItemImage[1].SetActive(false);
        }
        //アイテム詳細画面が表示されている場合、アイテム詳細画面を非表示にする
        DeleteItemDetail();
        Text.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }

    void DeleteLog()
    {
        //会話ログの表示位置を変更
        if(Log.activeSelf == true)
        {
            Transform transform1 = Log.transform;
            Vector2 pos1 = transform1.position;
            pos1.x -= 1200;
            Log.transform.position = pos1;
        }
    }

    void DeleteMap()
    {
        //マップの非表示
        if(Map.activeSelf == true)
        {
            Map.SetActive(false);
            ItemList.SetActive(false);
        }
    }

    void DeleteItem()
    {
        //アイテム一覧の非表示
        if(ItemList.activeSelf == true)
        {
            ItemList.SetActive(false);

            for(int i=0; i<2; i++)
            {
                ItemImage[i].SetActive(false);
                ItemButton.SetActive(false);
            }
        }
    }

    void DeleteItemDetail()
    {
        //アイテム詳細の非表示
        for(int i=0; i<2; i++)
        {
            if(AttackItemDetail[i].activeSelf == true)
            {
                AttackItemDetail[i].SetActive(false);
            }
            else if(DefenceItemDetail[i].activeSelf == true)
            {
                DefenceItemDetail[i].SetActive(false);
            }
        }
    }
}