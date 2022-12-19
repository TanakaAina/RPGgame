using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameTextManager : MonoBehaviour
{
    // InputFieldのText参照用
    public TMP_InputField Field;
    public Button button;
    public GameObject text1;
    public GameObject text2;
    public static int Len;
    public static string nametext;

    // Start と Update は省略

    // InputFieldの文字が変更されたらコールバックされる

    void Start()
    {
        text2.SetActive(false);
    }
    public void OnValueChanged()
    {
        //コンポーネントを取得
        string input = Field.GetComponent<TMP_InputField>().text;
        GetComponent<TMP_Text>().text = input;
    }
    public void InputText()
    { 
        //OKボタンをクリック可能にする
        button.interactable = true;
        //コンポーネントを取得
        nametext = GetComponent<TMP_Text>().text;
        //入力された文字数をカウント
        int len = nametext.Length;
        Len = len;
        if(nametext != null)
        {
            //入力された文字数が11文字以上の場合
            if(len > 11)
            {
                //OKボタンをクリックできないようにする
                button.interactable = false;
                text1.SetActive(false);
                text2.SetActive(true);
            }
            
            //入力された文字数が2文字以上の場合
            else if(len > 2)
            {
                //OKボタンをクリック可能にする
                button.interactable = true;
                text2.SetActive(false);
                text1.SetActive(true);
            }
            else
            {
                //OKボタンをクリックできないようにする
                button.interactable = false;
            }
        }

    }
}
