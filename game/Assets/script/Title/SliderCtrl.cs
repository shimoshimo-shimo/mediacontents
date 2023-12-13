using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    private Slider activeSlider; // ���݃A�N�e�B�u�ȃX���C�_�[

    void Start()
    {
        // ������Ԃł�bgmSlider���A�N�e�B�u�ɂ���
        activeSlider = bgmSlider;
        bgmSlider.Select();
    }

    void Update()
    {
        // �㉺�L�[�ŃA�N�e�B�u�ȃX���C�_�[��؂�ւ���
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleActiveSlider();
        }

        // ���E�L�[�ŃA�N�e�B�u�ȃX���C�_�[�̒l��ύX
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            float newValue = activeSlider.value + horizontalInput * Time.deltaTime;
            activeSlider.value = Mathf.Clamp01(newValue); // �l��0����1�͈̔͂ɃN�����v
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
