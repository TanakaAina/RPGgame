using UnityEngine;

public class ItemDetailManager : MonoBehaviour
{
    public ItemDetailList idl;
    public GameObject BackButton2;

    //アイテムアイコンがクリックされたら、アイテム詳細画面を表示する
    public void OnItem1Icon()
    {
        Instantiate(idl.ObjectList[0].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);       
    }

    public void OnItem2Icon()
    {
        Instantiate(idl.ObjectList[1].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem3Icon()
    {
        Instantiate(idl.ObjectList[2].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem4Icon()
    {
        Instantiate(idl.ObjectList[3].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem5Icon()
    {
        Instantiate(idl.ObjectList[4].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem6Icon()
    {
        Instantiate(idl.ObjectList[5].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem7Icon()
    {
        Instantiate(idl.ObjectList[6].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem8Icon()
    {
        Instantiate(idl.ObjectList[7].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem9Icon()
    {
        Instantiate(idl.ObjectList[8].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }

    public void OnItem10Icon()
    {
        Instantiate(idl.ObjectList[9].gameObject);
        ItemDetailList IDL = GetComponent<ItemDetailList>();
        BackButton2.SetActive(true);
    }
}
