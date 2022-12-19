using UnityEngine;
using UnityEngine.UI;

public class TownManager : MonoBehaviour
{
    public GameObject Text;
    public GameObject ToQuestButton;
    public GameObject TextButton;
    public BoyManager boyManager;
    public WomanManager womanManager;
    public GirlManager girlManager;
    public ManManager manManager;
    public Button BoyButton;
    public Button WomanButton;
    public Button GirlButton;
    public Button ManButton;

    //点滅させる対象
    [SerializeField] private Behaviour textbutton;
    //点滅周期[s]
    [SerializeField] private float _cycle = 1;
    private float _time;
    bool isCalledOnce = false;
    void Start()
    {
        ToQuestButton.SetActive(false);
        TextButton.SetActive(false);
        Text.SetActive(true);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"街についた。\n街の人に話を聞こう。"});
        Invoke(nameof(ShowTextButton),0.7f);
        TextButton.SetActive(true);
    }

    public void OnToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
    
     void ShowTextButton()
    {
        TextButton.SetActive(true);
    }

    void Update()
    {
        //テキスト右下の ▼ アイコンの点滅
        _time += Time.deltaTime;
        
        // 周期cycleで繰り返す値の取得
        // 0～cycleの範囲の値が得られる
        var repeatValue = Mathf.Repeat(_time, _cycle);
        
        // 内部時刻timeにおける明滅状態を反映
        textbutton.enabled = repeatValue >= _cycle * 0.5f;

        //少年、おばあさん、少女、おじいさんの画像が非表示の場合
        if(boyManager.BoyShade.activeSelf == false &&
            womanManager.WomanShade.activeSelf == false &&
            girlManager.GirlShade.activeSelf == false &&
            manManager.ManShade.activeSelf == false)
                {
                    //処理を一度だけ実行する
                    if(!isCalledOnce)
                    {
                        isCalledOnce = true;
                        ToQuestButton.SetActive(true);
                        //テキストの表示
                        DialogTextManager.instance.SetScenarios(new string[] {"森へ向かおう。"});
                        //会話ログ画面に反映
                        TextLogManager.dungeon_log += "\n森へ向かおう。\n";
                        TextLogManager.update_dungeon_log();
                        Invoke(nameof(ShowTextButton), 0.7f); 
                    }
                }

    }
}