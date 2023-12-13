using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;



    // Start is called before the first frame update
    private void Start()
    {
        // �X���C�_�[��G�����特�ʂ��ω�����
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

    
            // �ω�����̂́@�|�W�O�`�O�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);
                    
        });

        // �X���C�_�[��G�����特�ʂ��ω�����
        seSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

    
            // �ω�����̂́@�|�W�O�`�O�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("SE", decibel);

        });
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            seAudioSource.Play();
        }
    }
}
