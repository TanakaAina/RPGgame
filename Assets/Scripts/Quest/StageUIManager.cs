using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    public Text stegeText;
    public GameObject nextButton;
    public GameObject toTownButton;


    public void UpdateUI(int currentStage)
    {
        stegeText.text = string.Format("ステージ：{0}", currentStage+1);
    }

    public void HideButtons()
    {
        //進むボタン、街へ戻るボタンの非表示
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }
    public void ShowButtons()
    {
        //進むボタン、街へ戻るボタンの表示
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

}