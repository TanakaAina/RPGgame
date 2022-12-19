using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Title2 : MonoBehaviour
{
    public GameObject InputField;
    public GameObject PlayerNameFlame;
    public GameObject Warning;
    public Button GameStartButton;
    public Button ContinueButton;
    public Button OKButton;
    public TMP_InputField Field;
    void Start()
    {
        InputField.SetActive(false);
        PlayerNameFlame.SetActive(false);
        Warning.SetActive(false);
    }

    public void OnGameStartButton()
    {
        //はじめからボタン、つづきからボタンをクリックできないようにする
        GameStartButton.interactable = false;
        ContinueButton.interactable = false;
        Warning.SetActive(true);
        SoundManager.instance.PlaySE(0);
    }

    public void OnYesButton()
    {
        Warning.SetActive(false);
        InputField.SetActive(true);
        PlayerNameFlame.SetActive(true);
        //OKボタンをクリックできないようにする
        OKButton.interactable = false;
        SoundManager.instance.PlaySE(0); 
    }

    public void OnNoButton()
    {
        Warning.SetActive(false);
        //はじめからボタン、つづきからボタンをクリック可能にする
        GameStartButton.interactable = true;
        ContinueButton.interactable = true;
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
        PlayerNameFlame.SetActive(false);
        //はじめからボタン、つづきからボタンをクリック可能にする
        GameStartButton.interactable = true;
        ContinueButton.interactable = true;
        SoundManager.instance.PlaySE(0); 
    }
        
}
