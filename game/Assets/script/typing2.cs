using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typing2 : MonoBehaviour
{
    [SerializeField] Text m1Text;//炎
    [SerializeField] Text m2Text;//氷
    [SerializeField] Text m3Text;//雷
    [SerializeField] Text m4Text;
    [SerializeField] Text m5Text;
    [SerializeField] Text m6Text;
    [SerializeField] Text m7Text;//問題
    [SerializeField] Text m8Text;//回答欄
    [SerializeField] Text m9Text;//敵体力表示
    [SerializeField] Text m10Text;//味方体力
    [SerializeField] Slider mslider;//敵体力
    [SerializeField] Slider m2slider;//味方体力
    [SerializeField] AudioClip m1BGM;//炎音
    [SerializeField] AudioClip m2BGM;//氷音
    [SerializeField] AudioClip m3BGM;//雷音
    [SerializeField] AudioClip m4BGM;//文字打った音
    [SerializeField] AudioClip m5BGM;//やられた音
    [SerializeField] ParticleSystem m1effectParticleSystem;// シーン内のパーティクルシステムへの参照
    [SerializeField] ParticleSystem m2effectParticleSystem;
    [SerializeField] ParticleSystem m3effectParticleSystem;
    [SerializeField] ParticleSystem m4effectParticleSystem;


    private string[] _hatudou1 = { "1act", "1ice", "1mad", "1dist", "1live", "1have", "1pat", "1give", "1short", "1wind" };
    private string[] _hatudou2 = { "2gently", "2impact", "2castle", "2should", "2mellow", "2classic", "2breeze", "2exceed", "2complete" };
    private string[] _hatudou3 = { "3ambiance", "3delicate", "3quandary", "3transmit", "3plethora", "3symphony", "3prodigious", "3eccentric", "3resilient", "3magnificent" };
    private bool isTyping = false;
    public int flag;

    // AudioSourceの追加
    private AudioSource audioSource;


    void Start()
    {
        // 初期値を設定
        m1Text.text = "①弱攻撃";
        m2Text.text = "②中攻撃";
        m3Text.text = "③強攻撃";

        mslider.maxValue = 1000;
        mslider.value = mslider.maxValue;

        m2slider.maxValue = 1000;
        m2slider.value = m2slider.maxValue;

        // m9Textにmsliderの初期値を表示
        m9Text.text = $"{mslider.value}/{mslider.maxValue}";

        // m10Textにm2sliderの初期値を表示
        m10Text.text = $"{m2slider.value}/{m2slider.maxValue}";

        // Unityのランダム関数を初期化
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

        // AudioSourceの初期化
        audioSource = gameObject.AddComponent<AudioSource>();

    }



    void Update()
    {

        // m1sliderまたはm2sliderが0以下になったら終了
        if (mslider.value <= 0 )
        {
            EndGame();
        }else  if (m2slider.value <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Title scene");
        }


        // m9Textにmsliderの値を表示
        m9Text.text = $"{mslider.value}/{mslider.maxValue}";

        // m10Textにm2sliderの値を表示
        m10Text.text = $"{m2slider.value}/{m2slider.maxValue}";

        // キーボードの1, 2, 3が押されたら対応する_hatudouのランダムな要素を表示
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisplayRandomElement(_hatudou1);
            flag = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisplayRandomElement(_hatudou2);
            flag = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisplayRandomElement(_hatudou3);
            flag = 3;
        }

        // キーが押されている場合、m8Textに入力された文字列を表示
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if ((keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9) || keyCode == KeyCode.Return)
            {
                continue;
            }

            if (Input.GetKeyDown(keyCode))
            {
                if (isTyping)
                {
                    CheckInputAndUpdateSlider(keyCode.ToString().ToLower());
                }
            }
        }
    }

    void DisplayRandomElement(string[] array)
    {
        if (array.Length > 0)
        {
            m8Text.text = "";
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            m7Text.text = array[randomIndex].Substring(1);
            isTyping = true;
            m8Text.text = "";
        }
        else
        {
            m7Text.text = "Empty Array";
        }
    }

    void CheckInputAndUpdateSlider(string inputText)
    {
        if (isTyping)
        {
            if (m7Text.text.Length < m8Text.text.Length + 1)
            {
                // m7Text の文字数が足りない場合
                Miss();
                return;
            }

            if (m7Text.text[m8Text.text.Length] == inputText[0])
            {
                // m8Text の次の文字と入力文字が一致する場合
                m8Text.text += inputText;

                if (m8Text.text == m7Text.text)
                {
                    Correct();
                    DecreaseM1Slider(); // 最後の文字まで正しく入力された場合、m1slider を減少
                }
                else
                {
                    // 正解時の音を再生
                    // audioSource.PlayOneShot(m4BGM);
                    AudioConfig.Instance.seAudioSources[3].Play();
                }
            }
            else
            {
                // m8Text の次の文字が間違っている場合
                Miss();
            }

            if (mslider.value <= 0)
            {
                m8Text.text = "";
                m7Text.text = "";
            }
        }
    }

    void Correct()
    {
        Debug.Log("正解");
        m7Text.text = "";

        if (flag == 1)
        {
            DisplayRandomElement(_hatudou1);
            m8Text.text = "";
            // 魔法1のBGMを再生
            // audioSource.PlayOneShot(m1BGM);
            AudioConfig.Instance.seAudioSources[0].Play();
            // m1BGMが再生されたときにパーティクルシステムを表示
            InstantiateEffect(m1effectParticleSystem);
        }
        else if (flag == 2)
        {
            DisplayRandomElement(_hatudou2);
            m8Text.text = "";
            // 魔法2のBGMを再生
            // audioSource.PlayOneShot(m2BGM);
            AudioConfig.Instance.seAudioSources[1].Play();
            // m2BGMが再生されたときにパーティクルシステムを表示
            InstantiateEffect(m2effectParticleSystem);
        }
        else if (flag == 3)
        {
            DisplayRandomElement(_hatudou3);
            m8Text.text = "";
            // 魔法3のBGMを再生
            // audioSource.PlayOneShot(m3BGM);
            AudioConfig.Instance.seAudioSources[2].Play();
            // m3BGMが再生されたときにパーティクルシステムを表示
            InstantiateEffect(m3effectParticleSystem);
        }
    }


    [SerializeField] public GameObject TitlePanel;    // 【 追加 】メニューパネルのアクティブ状態を取得します。


void Miss()
    {


        // 【 追加 】メニューパネルがアクティブな場合はダメージを受けないように。
        if (TitlePanel.activeSelf)
        {
            return;
        }



        Debug.Log("不正解");
        DecreaseM2Slider(); // 不正解時にm2sliderを減少

        if (flag == 1)
        {
            DisplayRandomElement(_hatudou1);
        }
        else if (flag == 2)
        {
            DisplayRandomElement(_hatudou2);
        }
        else if (flag == 3)
        {
            DisplayRandomElement(_hatudou3);
        }

        if (m8Text.text.Length > 0 && m7Text.text.Length > 0)
        {
            if (m8Text.text[m8Text.text.Length - 1] == m7Text.text[m7Text.text.Length - 1])
            {
                // 最後の文字が一致する場合、m1slider を減少
                DecreaseM1Slider();
            }
        }

        if (mslider.value <= 0)
        {
            m8Text.text = "";
            m7Text.text = "";
        }
    }

    void DecreaseM1Slider()
    {
        if (flag == 1)
        {
            mslider.value = Mathf.Max(0, mslider.value - 50);
        }else if(flag == 2)
        {
            mslider.value = Mathf.Max(0, mslider.value - 100);
        }else if (flag == 3)
        {
            mslider.value = Mathf.Max(0, mslider.value - 200);
        }
    }

    void DecreaseM2Slider()
    {
        float previousValue = m2slider.value;

        // m2sliderの値を10減少させる（または0未満にならないようにする）
        m2slider.value = Mathf.Max(0, m2slider.value - 100);

        // 直前の値よりも小さい場合、m5BGMを再生
        if (m2slider.value < previousValue)
        {
            // audioSource.PlayOneShot(m5BGM);
            AudioConfig.Instance.seAudioSources[4].Play();
            // m5BGMが再生されたときにパーティクルシステムを表示
            InstantiateEffect(m4effectParticleSystem);
        }
        // この後にコードが続く可能性があります（あれば）
    }

    void EndGame()
    {
        // ゲーム終了処理をここに記述
        // 例えば、RPG scene に遷移するなど

        // RPG scene に遷移する場合
        SceneManager.LoadScene("RPG scene");
    }

    void InstantiateEffect(ParticleSystem particleSystem)
    {
        // パーティクルシステムへの参照がnullでないことを確認
        if (particleSystem != null)
        {
            // パーティクルシステムを指定位置にインスタンス化（必要に応じて位置などを調整）
            Instantiate(particleSystem, transform.position, Quaternion.identity);
        }
    }
}