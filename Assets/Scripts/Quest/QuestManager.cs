using System.Collections;
using UnityEngine;

using DG.Tweening;
// クエスト全体を管理

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject[] Enemy = new GameObject[12];
    public GameObject TextButton;
    public GameObject DialogUI;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;
    //点滅させる対象
    [SerializeField] private Behaviour textbutton;
    //点滅周期[s]
    [SerializeField] private float _cycle = 1;
    private float _time;

    // 敵に遭遇するテーブル：-1なら遭遇しない, 0なら遭遇
    //int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    //ステージの数分の配列の定義
    int[] encountTable = new int[100];
    int stage = 5;

    int currentStage = 0; // 現在のステージ進行度
    private void Start()
    {
        EncountSetting(encountTable,stage);
        //ステージ数表示の更新
        stageUI.UpdateUI(currentStage);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"森についた。"});
        Invoke(nameof(ShowTextButton), 0.7f);  
    }
    //ステージの数だけ敵をランダム配置
    private void EncountSetting(int[] arr,int stage)
    {
        for(int i = 0;i < stage;i++)
        {
            //出現するかしないかのランダムなので 0 or 1
            arr[i] = Random.Range(0,2);
            //arr[i] = 0;
            Debug.Log("エンカウント"+arr[i]);
        }
    }

IEnumerator Seaching()
    {
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {"探索中..."});
        // 背景を大きく
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f));
        // 背景のフェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));
        // 2秒間処理を待機する
        yield return new WaitForSeconds(2f);

        currentStage++;
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);

        if (stage <= currentStage)
        {
            QuestClear();
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }

    // Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        //進むボタン、街へ戻るボタンの非表示
        stageUI.HideButtons();
        //探索処理
        StartCoroutine(Seaching());
    }
    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        //進むボタン、街へ戻るボタンの非表示
        stageUI.HideButtons();
        //敵12体のうち1体をランダムで選出
        int rnd = Random.Range(0,12);
        //int rnd = 0;
        Debug.Log("rnd="+rnd);

        for(int i=0; i<12; i++)
        {
            if(rnd==i)
        {
            //敵のオブジェクトを生成
            GameObject enemyObj = Instantiate(Enemy[i]);
            //コンポーネントを取得
            EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
            //テキストの表示
            DialogTextManager.instance.SetScenarios(new string[] {enemy.name+"が現れた！"});
            Invoke(nameof(ShowTextButton), 0.7f); 
            //敵画像の表示
            battleManager.Setup(enemy);
        }
        }
    }

    public void EndBattle()
    {
        //進むボタン、街へ戻るボタンの表示
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        //GameClearシーンをロード
        sceneTransitionManager.LoadTo("GameClear");
        DialogUI.SetActive(false);
        SoundManager.instance.StopBGM();
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

    public void OnClick()
    {
        //テキストを非表示にする
        DialogTextManager.instance.SetScenarios(new string[] {"　"});
        // ▼ アイコンを非表示にする
        TextButton.SetActive(false);
        SoundManager.instance.PlaySE(4);
    }
}