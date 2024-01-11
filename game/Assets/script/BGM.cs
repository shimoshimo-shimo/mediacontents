using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // BGM�p��AudioSource
    private AudioSource bgmAudioSource;

    // BGM�t�@�C���iAudioClip�j��Inspector����ݒ肷��
    [SerializeField] AudioClip bgmClip;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource�R���|�[�l���g���擾�܂��͒ǉ�
        bgmAudioSource = gameObject.GetComponent<AudioSource>();
        if (bgmAudioSource == null)
        {
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // BGM��ݒ�
        bgmAudioSource.clip = bgmClip;

        // ���[�v�Đ�
        bgmAudioSource.loop = true;

        // BGM�Đ��J�n
        bgmAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[������BGM�̒����␧�䂪�K�v�ȏꍇ�͂����ɒǉ�
    }
}
