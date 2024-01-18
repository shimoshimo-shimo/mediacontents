using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle4
    : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    public int g;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        g = PlayerPrefs.GetInt("G", 0);
        if(g == 1)
        {
            objectToDeactivate.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // audioSource.PlayOneShot(sound1);
        AudioConfig.Instance.seAudioSources[0].Play();
        StartCoroutine(WaitAndLoadScene());
    }

    public GameObject objectToDeactivate;

    IEnumerator WaitAndLoadScene()
    {
        // 座標保存
        

        // 非アクティブにしたいオブジェクトを DontDestroyOnLoad で指定
        DontDestroyOnLoad(objectToDeactivate);

        // 待機
        yield return new WaitForSeconds(0.6f);
        g = 1;
        PlayerPrefs.SetInt("G", g);
        // オブジェクトを非アクティブにする
        objectToDeactivate.SetActive(false);
        pos.playerpos.Savepos();
        // シーンをロード
        SceneManager.LoadScene("typing scene 3");
    }
}



