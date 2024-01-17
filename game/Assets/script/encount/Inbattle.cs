using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    public int h;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        h = PlayerPrefs.GetInt("H", 0);
        if(h == 1)
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
        audioSource.PlayOneShot(sound1);
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
        h = 1;
        PlayerPrefs.SetInt("H", h);
        // オブジェクトを非アクティブにする
        objectToDeactivate.SetActive(false);
        pos.playerpos.Savepos();
        // シーンをロード
        SceneManager.LoadScene("Typing Scene");
    }
}



