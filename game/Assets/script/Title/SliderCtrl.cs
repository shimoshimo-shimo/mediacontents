using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    public Text bgmValueText;
    public Text seValueText;

    private Slider activeSlider; // ���݃A�N�e�B�u�ȃX���C�_�[

    private float keyHoldTime = 0.0f; // �L�[������������Ă��鎞��
    private float keyHoldInterval = 0.5f; // �L�[�����������ꂽ�Ƃ��Ɍo�߂���܂ł̎���
    private float valueChangeInterval = 0.1f; // �X���C�_�[�̒l��ύX����Ԋu

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

        // ���E�L�[�̏���
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            keyHoldTime += Time.deltaTime;

            // ��莞�Ԃ��Ƃɒl��ύX
            if (keyHoldTime >= keyHoldInterval)
            {
                float newValue = activeSlider.value + Mathf.Sign(horizontalInput) * valueChangeInterval;
                activeSlider.value = Mathf.Clamp01(newValue); // �l��0����1�͈̔͂ɃN�����v
                keyHoldTime = 0.0f;
            }
        }
        else
        {
            keyHoldTime = 0.0f; // �L�[�������ꂽ�玞�Ԃ����Z�b�g
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
