using UnityEngine;
using TMPro;

public class EnemyUIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI nameText;

    public void SetupUI(EnemyManager enemy)
    {
        //敵のHPテキスト、名前のテキストを設定
        hpText.text = string.Format("HP：{0}", enemy.hp);
        nameText.text = string.Format("{0}", enemy.name);
    }

    public void UpdateUI(EnemyManager enemy)
    {
        //HP表示の更新
        hpText.text = string.Format("HP：{0}", enemy.hp);
    }
}