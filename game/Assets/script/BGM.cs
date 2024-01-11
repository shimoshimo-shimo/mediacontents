using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // BGM用のAudioSource
    private AudioSource bgmAudioSource;

    // BGMファイル（AudioClip）をInspectorから設定する
    [SerializeField] AudioClip bgmClip;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceコンポーネントを取得または追加
        bgmAudioSource = gameObject.GetComponent<AudioSource>();
        if (bgmAudioSource == null)
        {
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // BGMを設定
        bgmAudioSource.clip = bgmClip;

        // ループ再生
        bgmAudioSource.loop = true;

        // BGM再生開始
        bgmAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム中のBGMの調整や制御が必要な場合はここに追加
    }
}
