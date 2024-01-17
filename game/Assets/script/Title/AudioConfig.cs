using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] List<AudioSource> seAudioSources;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    // ���̃V�[���ŎQ�Ƃ��邽�߂̐ÓI�ϐ�
    public static float bgmVolume = 1.0f;
    public static float seVolume = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // �X���C�_�[��G�����特�ʂ��ω�����
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            // �ω�����̂� �|�W�O�`�O�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);

            // ���ʂ̒l��ۑ�
            bgmVolume = value;
        });




        // �X���C�_�[��G�����特�ʂ��ω�����
        seSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            // �ω�����̂� �|�W�O�`�O�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);

            // �S�Ă�SE�̉��ʂ��ꊇ�Œ���
            foreach (var seSource in seAudioSources)
            {
                audioMixer.SetFloat("SE", decibel);
            }

            // ���ʂ̒l��ۑ�
            seVolume = value;
        });




        // ���̃V�[������̕ύX�𔽉f
        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            seAudioSource.Play();
        }
        */
    }
}

