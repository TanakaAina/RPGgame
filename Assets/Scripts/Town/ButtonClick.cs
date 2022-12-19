using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public BoyManager boymanager;
    public WomanManager womanmanager;
    public GirlManager girlmanager;
    public ManManager manmanager;
    public GameObject TextButton;
    public TownManager townmanager;
    //点滅させる対象
    [SerializeField] private Behaviour textbutton;
    //点滅周期[s]
    [SerializeField] private float _cycle = 1;
    private float _time;
   public void OnTextButton()
   {
    //少年との会話中の場合
    if(boymanager.Boy.activeSelf == true)
    {
        Set();
        //少年を非表示にする
        boymanager.Boy.SetActive(false);
        boymanager.BoyShade.SetActive(false);
        //おばあさん、少女、おじいさんをクリック可能にする
        townmanager.WomanButton.interactable = true;
        townmanager.GirlButton.interactable = true;
        townmanager.ManButton.interactable = true;
    }
    //おばあさんとの会話中の場合
    else if(womanmanager.Woman.activeSelf == true)
    {
        Set();
        //おばあさんを非表示にする
        womanmanager.Woman.SetActive(false);
        womanmanager.WomanShade.SetActive(false);
        //少年、少女、おじいさんをクリック可能にする
        townmanager.BoyButton.interactable = true;
        townmanager.GirlButton.interactable = true;
        townmanager.ManButton.interactable = true;
    }
    //少女との会話中の場合
    else if(girlmanager.Girl.activeSelf == true)
    {
        Set();
        //少女を非表示にする
        girlmanager.Girl.SetActive(false);
        girlmanager.GirlShade.SetActive(false);
        //少年、おばあさん、おじいさんをクリック可能にする
        townmanager.BoyButton.interactable = true;
        townmanager.WomanButton.interactable = true;
        townmanager.ManButton.interactable = true;
    }
    //おじいさんとの会話中の場合
    else if(manmanager.Man.activeSelf == true)
    {
        Set();
        //おじいさんを非表示にする
        manmanager.Man.SetActive(false);
        manmanager.ManShade.SetActive(false);
        //少年、おばあさん、少女をクリック可能にする
        townmanager.BoyButton.interactable = true;
        townmanager.WomanButton.interactable = true;
        townmanager.GirlButton.interactable = true;

    }
    else
    {
        //テキストを非表示にする
        DialogTextManager.instance.SetScenarios(new string[] {"　"});
        TextButton.SetActive(false);
        SoundManager.instance.PlaySE(4);
    }
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

    }

    void Set()
    {
        //テキストを非表示にする
        DialogTextManager.instance.SetScenarios(new string[] {"　"});
        SoundManager.instance.PlaySE(4);
        TextButton.SetActive(false);
    }

}
