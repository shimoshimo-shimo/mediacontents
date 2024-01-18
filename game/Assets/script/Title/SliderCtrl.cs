using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    public Text bgmValueText;
    public Text seValueText;

    private Slider activeSlider; // 現在アクティブなスライダー

    private float keyHoldTime = 0.0f; // キーが長押しされている時間
    private float keyHoldInterval = 0.5f; // キーが長押しされたときに経過するまでの時間
    private float valueChangeInterval = 0.1f; // スライダーの値を変更する間隔

    // 他のシーンから引き継ぐための初期値
    private float initialBgmValue = 0.5f;
    private float initialSeValue = 0.5f;

    void Start()
    {
        // 他のシーンからの変更があれば反映
            initialBgmValue = AudioConfig.bgmVolume;
            initialSeValue = AudioConfig.seVolume;


        // 初期状態ではbgmSliderをアクティブにする
        activeSlider = bgmSlider;
        bgmSlider.Select();

        // 初期値をセット
        bgmSlider.value = initialBgmValue;
        seSlider.value = initialSeValue;
    }

    void Update()
    {
        // 上下キーでアクティブなスライダーを切り替える
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleActiveSlider();
        }

        // 左右キーの処理
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            keyHoldTime += Time.deltaTime;

            // 一定時間ごとに値を変更
            if (keyHoldTime >= keyHoldInterval)
            {
                float newValue = activeSlider.value + Mathf.Sign(horizontalInput) * valueChangeInterval;
                activeSlider.value = Mathf.Clamp01(newValue); // 値を0から1の範囲にクランプ
                keyHoldTime = 0.0f;

                // 値を保存
                if (activeSlider == bgmSlider)
                {
                    initialBgmValue = activeSlider.value;
                    AudioConfig.bgmVolume = initialBgmValue;
                }
                else
                {
                    initialSeValue = activeSlider.value;
                    AudioConfig.seVolume = initialSeValue;
                }
            }
        }
        else
        {
            keyHoldTime = 0.0f; // キーが離されたら時間をリセット
        }
    }

    void ToggleActiveSlider()
    {
        if (activeSlider == bgmSlider)
        {
            activeSlider = seSlider;
            seSlider.Select();
        }
        else
        {
            activeSlider = bgmSlider;
            bgmSlider.Select();
        }
    }
}

