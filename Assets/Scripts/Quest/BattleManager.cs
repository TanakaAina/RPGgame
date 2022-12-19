using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public GameObject TextButton;
    EnemyManager enemy;
    TitleManager title;
    [SerializeField] TextMeshProUGUI nametext;
    //点滅させる対象
    [SerializeField] private Behaviour textbutton;
    //点滅周期[s]
    [SerializeField] private float _cycle = 1;
    private float _time;


    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
        //タイトル画面で設定したプレイヤー名
        nametext.text = TitleManager.str;
    }

    // 初期設定
    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        if(enemy.hp > 0)
        {
            StopAllCoroutines();
            SoundManager.instance.PlaySE(1);
            int damage = player.Attack(enemy);
            //HP表示の更新
            enemyUI.UpdateUI(enemy);
            //タイトル画面で設定したプレイヤー名を読み込む
            string Nametext = PlayerNameTextManager.nametext;
            //テキストの表示
            DialogTextManager.instance.SetScenarios(new string[] {Nametext+"の攻撃\n"+enemy.name+"に"+damage+"ダメージを\n与えた。"});
            Invoke(nameof(ShowTextButton), 0.7f); 
            if (enemy.hp <= 0)
            {
                StartCoroutine(EndBattle());
            }
            else
            {
                StartCoroutine(EnemyTurn());
            }
        }
        else{;}
    }

    IEnumerator EnemyTurn()
    {
        if(enemy.hp > 0)
        {
            //2.5秒間処理を待機する
            yield return new WaitForSeconds(2.5f);
            SoundManager.instance.PlaySE(1);
            //敵の攻撃時に背景画像を振動させる
            playerDamagePanel.DOShakePosition(0.3f, 0.3f, 20, 0, false, true);
            int damage = enemy.Attack(player);
            //HP表示の更新
            playerUI.UpdateUI(player);
            //タイトル画面で設定したプレイヤー名を読み込む
            string Nametext = PlayerNameTextManager.nametext;
            //テキストの表示
            DialogTextManager.instance.SetScenarios(new string[] {enemy.name+"の攻撃\n"+Nametext+"は"+damage+"ダメージを\n受けた。"});
            Invoke(nameof(ShowTextButton), 0.7f); 
        }
        else{;}

    }

    IEnumerator EndBattle()
    {
        //2.5秒間処理を待機する
        yield return new WaitForSeconds(2.5f);
        //テキストの表示
        DialogTextManager.instance.SetScenarios(new string[] {enemy.name+"を倒した！"});
        Invoke(nameof(ShowTextButton), 0.7f); 
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(3);
        enemyUI.gameObject.SetActive(false);
        //敵画像のフェードアウト
        SpriteRenderer questBGSpriteRenderer = enemy.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(1, 0)
            .OnComplete(() => questBGSpriteRenderer.DOFade(0, 1));
        // 2秒間処理を待機する
        yield return new WaitForSeconds(2f);
        //敵画像の削除
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
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
}