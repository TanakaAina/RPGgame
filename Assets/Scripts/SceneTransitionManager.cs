using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        //シーンを読み込み、フェードイン・フェードアウトを実行
        FadeIOManager.instance.FadeOutToIn(() => Lioad(sceneName));
    }
    void Lioad(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}