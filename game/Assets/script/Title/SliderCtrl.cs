using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    private Slider activeSlider; // 現在アクティブなスライダー

    void Start()
    {
        // 初期状態ではbgmSliderをアクティブにする
        activeSlider = bgmSlider;
        bgmSlider.Select();
    }

    void Update()
    {
        // 上下キーでアクティブなスライダーを切り替える
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleActiveSlider();
        }

        // 左右キーでアクティブなスライダーの値を変更
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            float newValue = activeSlider.value + horizontalInput * Time.deltaTime;
            activeSlider.value = Mathf.Clamp01(newValue); // 値を0から1の範囲にクランプ
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
