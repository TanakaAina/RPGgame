using UnityEngine;

public class ItemIconManager : MonoBehaviour
{ 
    public GameObject BackButton2;
    public ItemDetailList idl;

    //アイテムアイコンがクリックされたら、アイテム詳細画面を表示する
    public void Item1Click()
    {
        Instantiate(idl.ObjectList[0].gameObject);
        idl.ObjectList[0].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item2Click()
    {
        Instantiate(idl.ObjectList[1].gameObject);
        idl.ObjectList[1].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item3Click()
    {
        Instantiate(idl.ObjectList[2].gameObject);
        idl.ObjectList[2].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item4Click()
    {
        Instantiate(idl.ObjectList[3].gameObject);
        idl.ObjectList[3].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item5Click()
    {
        Instantiate(idl.ObjectList[4].gameObject);
        idl.ObjectList[4].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item6Click()
    {
        Instantiate(idl.ObjectList[5].gameObject);
        idl.ObjectList[5].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item7Click()
    {
        Instantiate(idl.ObjectList[6].gameObject);
        idl.ObjectList[6].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item8Click()
    {
        Instantiate(idl.ObjectList[7].gameObject);
        idl.ObjectList[7].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item9Click()
    {
        Instantiate(idl.ObjectList[8].gameObject);
        idl.ObjectList[8].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }
    public void Item10Click()
    {
        Instantiate(idl.ObjectList[9].gameObject);
        idl.ObjectList[9].SetActive(true);
        BackButton2.SetActive(true);
        SoundManager.instance.PlaySE(5);
    }

}

