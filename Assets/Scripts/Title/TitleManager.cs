using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public GameObject InputField;
    public GameObject Image;
    public static string str;
    public Button OKButton;
    public Button GameStartButton;
    public Button ContinueButton;

    public TMP_InputField Field;
    public static string nametext;

     void Start()
    {
        ContinueButton.interactable = false;
        InputField.SetActive(false);
        Image.SetActive(false);
    }
    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
        InputField.SetActive(true);
        Image.SetActive(true);
        //OKボタン、はじめからボタンをクリックできないようにする
        OKButton.interactable = false;
        GameStartButton.interactable = false;
    }
    
    public void OnOKButton()
    {
        SoundManager.instance.PlaySE(0);
    }   

    public void OnReturnButton()
    {
        //戻るボタンクリック時に、入力されているプレイヤー名を空にする
        if(PlayerNameTextManager.Len > 0)
        {
            Field.text = "";
        }

        InputField.SetActive(false);
        Image.SetActive(false);
        //はじめからボタンをクリック可能にする
        GameStartButton.interactable = true;
        SoundManager.instance.PlaySE(0);            
    }

}