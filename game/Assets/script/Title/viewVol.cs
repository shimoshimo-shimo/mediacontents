using UnityEngine;
using UnityEngine.UI;

public class viewVol : MonoBehaviour
{
    public Slider BGMSlider; // BGM用Sliderをインスペクターで関連付ける
    public Text BGMValueText; // BGM用Textをインスペクターで関連付ける

    public Slider SESlider; // SE用Sliderをインスペクターで関連付ける
    public Text SEValueText; // SE用Textをインスペクターで関連付ける

    void Update()
    {
        // 毎フレームで値を更新
        UpdateBGMTextValue();
        UpdateSETextValue();
    }

    void UpdateBGMTextValue()
    {
        // BGM用Sliderの値を10倍して整数に変換し、Textに表示
        int roundedValue = Mathf.RoundToInt(BGMSlider.value * 10f);
        BGMValueText.text = "vol: " + roundedValue.ToString();
    }

    void UpdateSETextValue()
    {
        // SE用Sliderの値を10倍して整数に変換し、Textに表示
        int roundedValue = Mathf.RoundToInt(SESlider.value * 10f);

        SEValueText.text = "vol: " + roundedValue.ToString();
    }
}

