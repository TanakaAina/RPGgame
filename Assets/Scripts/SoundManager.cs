using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // シングルトン
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //シーン切り替え時にオブジェクトを引き継ぐ
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //--シングルトン終わり--

    // BGMのスピーカー
    public AudioSource audioSourceBGM;
    // BGMの素材
    public AudioClip[] audioClipsBGM;
    // SEのスピーカー
    public AudioSource audioSourceSE;
    // ならす素材
    public AudioClip[] audioClipsSE;

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }
    public void PlaySE(int index)
    {
        if (index == 2)
        {
            audioSourceSE.volume = 0.8f;
        }
        else
        {
            audioSourceSE.volume = 1f;
        }
        // SEを一度だけならす
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
    public void StopSE()
    {
        audioSourceSE.Stop();
    }

    public void PlayGameClearBGM(int index)
    {
        audioSourceBGM.PlayOneShot(audioClipsBGM[index]);
        audioSourceBGM.volume = 1.5f;
    }

}