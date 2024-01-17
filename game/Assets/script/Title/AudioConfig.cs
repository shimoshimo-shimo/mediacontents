using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] public List<AudioSource> seAudioSources;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    // 他のシーンで参照するための静的変数
    public static float bgmVolume = 1.0f;
    public static float seVolume = 1.0f;



    public static AudioConfig Instance;

    private void Awake()
    {
        Instance = this;
    }



    private void Start()
    {
        // スライダーを触ったら音量が変化する
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            // 変化するのは －８０～０までの間
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);

            // 音量の値を保存
            bgmVolume = value;
        });




        // スライダーを触ったら音量が変化する
        seSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            // 変化するのは －８０～０までの間
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);

            // 全てのSEの音量を一括で調整
            foreach (var seSource in seAudioSources)
            {
                audioMixer.SetFloat("SE", decibel);
            }

            // 音量の値を保存
            seVolume = value;
        });




        // 他のシーンからの変更を反映
        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;
    }

}

