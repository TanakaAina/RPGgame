using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// 敵を管理するもの（ステータス/クリック検出）
public class EnemyManager : MonoBehaviour
{
    //関数登録
    Action tapAction; // クリックされたときに実行したい関数（外部から設定したい）

    public new string name;
    public int hp;
    public int at;
    //最大HPと現在のHP。
    public int maxHp;
    int currentHp;

    public void Start()
    {
        maxHp = hp;
        currentHp = maxHp;
        EnemyManager enemyPre = this;
        SpriteRenderer questBGSpriteRenderer = enemyPre.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 0)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 1));
    }
    // 攻撃する
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
    }

    // ダメージを受ける

    public int Damage(int damage)
    {
        if(hp > 0)
        {
            //プレイヤーの攻撃時に敵の画像を振動させる
            transform.DOShakePosition(0.15f, 0.6f, 25, 0, false, true);
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
            }
        }
        else{;}
        return damage;
    }

    // tapActionに関数を登録する関数を作る
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        tapAction();
        OnTriggerEnter();
    }

    private void OnTriggerEnter()
    {
        int damage = 50;

        //現在のHPからダメージを引く
        currentHp = currentHp - damage;

    }
}