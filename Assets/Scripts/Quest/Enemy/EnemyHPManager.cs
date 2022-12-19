using UnityEngine;
using UnityEngine.UI;

public class EnemyHPManager : MonoBehaviour
{
    //最大HPと現在のHP。
    public int maxHp = 100;
    int currentHp;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }
}
