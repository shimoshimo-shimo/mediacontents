using UnityEngine;
using UnityEngine.UI;

public class viewVol : MonoBehaviour
{
    public Slider BGMSlider; // BGM�pSlider���C���X�y�N�^�[�Ŋ֘A�t����
    public Text BGMValueText; // BGM�pText���C���X�y�N�^�[�Ŋ֘A�t����

    public Slider SESlider; // SE�pSlider���C���X�y�N�^�[�Ŋ֘A�t����
    public Text SEValueText; // SE�pText���C���X�y�N�^�[�Ŋ֘A�t����

    void Update()
    {
        // ���t���[���Œl���X�V
        UpdateBGMTextValue();
        UpdateSETextValue();
    }

    void UpdateBGMTextValue()
    {
        // BGM�pSlider�̒l��10�{���Đ����ɕϊ����AText�ɕ\��
        int roundedValue = Mathf.RoundToInt(BGMSlider.value * 10f);
        BGMValueText.text = "vol: " + roundedValue.ToString();
    }

    void UpdateSETextValue()
    {
        // SE�pSlider�̒l��10�{���Đ����ɕϊ����AText�ɕ\��
        int roundedValue = Mathf.RoundToInt(SESlider.value * 10f);

        SEValueText.text = "vol: " + roundedValue.ToString();
    }
}

