using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class typing2 : MonoBehaviour
{
    [SerializeField] Text m1Text;//��
    [SerializeField] Text m2Text;//�X
    [SerializeField] Text m3Text;//��
    [SerializeField] Text m4Text;
    [SerializeField] Text m5Text;
    [SerializeField] Text m6Text;
    [SerializeField] Text m7Text;//���
    [SerializeField] Text m8Text;//�񓚗�
    [SerializeField] Text m9Text;//�G�̗͕\��
    [SerializeField] Text m10Text;//�����̗�
    [SerializeField] Slider mslider;//�G�̗�
    [SerializeField] Slider m2slider;//�����̗�
    [SerializeField] AudioClip m1BGM;//����
    [SerializeField] AudioClip m2BGM;//�X��
    [SerializeField] AudioClip m3BGM;//����
    [SerializeField] AudioClip m4BGM;//�����ł�����
    [SerializeField] AudioClip m5BGM;//���ꂽ��
    [SerializeField] ParticleSystem m1effectParticleSystem;// �V�[�����̃p�[�e�B�N���V�X�e���ւ̎Q��
    [SerializeField] ParticleSystem m2effectParticleSystem;
    [SerializeField] ParticleSystem m3effectParticleSystem;
    [SerializeField] ParticleSystem m4effectParticleSystem;


    private string[] _hatudou1 = { "1act", "1ice", "1mad", "1dist", "1live", "1have", "1pat", "1give", "1short", "1wind" };
    private string[] _hatudou2 = { "2gently", "2impact", "2castle", "2should", "2mellow", "2classic", "2breeze", "2exceed", "2complete" };
    private string[] _hatudou3 = { "3ambiance", "3delicate", "3quandary", "3transmit", "3plethora", "3symphony", "3prodigious", "3eccentric", "3resilient", "3magnificent" };
    private bool isTyping = false;
    public int flag;

    // AudioSource�̒ǉ�
    private AudioSource audioSource;


    void Start()
    {
        // �����l��ݒ�
        m1Text.text = "�@��U��";
        m2Text.text = "�A���U��";
        m3Text.text = "�B���U��";

        mslider.maxValue = 1000;
        mslider.value = mslider.maxValue;

        m2slider.maxValue = 1000;
        m2slider.value = m2slider.maxValue;

        // m9Text��mslider�̏����l��\��
        m9Text.text = $"{mslider.value}/{mslider.maxValue}";

        // m10Text��m2slider�̏����l��\��
        m10Text.text = $"{m2slider.value}/{m2slider.maxValue}";

        // Unity�̃����_���֐���������
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

        // AudioSource�̏�����
        audioSource = gameObject.AddComponent<AudioSource>();

    }



    void Update()
    {

        // m1slider�܂���m2slider��0�ȉ��ɂȂ�����I��
        if (mslider.value <= 0 )
        {
            EndGame();
        }else  if (m2slider.value <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Title scene");
        }


        // m9Text��mslider�̒l��\��
        m9Text.text = $"{mslider.value}/{mslider.maxValue}";

        // m10Text��m2slider�̒l��\��
        m10Text.text = $"{m2slider.value}/{m2slider.maxValue}";

        // �L�[�{�[�h��1, 2, 3�������ꂽ��Ή�����_hatudou�̃����_���ȗv�f��\��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisplayRandomElement(_hatudou1);
            flag = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisplayRandomElement(_hatudou2);
            flag = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisplayRandomElement(_hatudou3);
            flag = 3;
        }

        // �L�[��������Ă���ꍇ�Am8Text�ɓ��͂��ꂽ�������\��
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if ((keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9) || keyCode == KeyCode.Return)
            {
                continue;
            }

            if (Input.GetKeyDown(keyCode))
            {
                if (isTyping)
                {
                    CheckInputAndUpdateSlider(keyCode.ToString().ToLower());
                }
            }
        }
    }

    void DisplayRandomElement(string[] array)
    {
        if (array.Length > 0)
        {
            m8Text.text = "";
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            m7Text.text = array[randomIndex].Substring(1);
            isTyping = true;
            m8Text.text = "";
        }
        else
        {
            m7Text.text = "Empty Array";
        }
    }

    void CheckInputAndUpdateSlider(string inputText)
    {
        if (isTyping)
        {
            if (m7Text.text.Length < m8Text.text.Length + 1)
            {
                // m7Text �̕�����������Ȃ��ꍇ
                Miss();
                return;
            }

            if (m7Text.text[m8Text.text.Length] == inputText[0])
            {
                // m8Text �̎��̕����Ɠ��͕�������v����ꍇ
                m8Text.text += inputText;

                if (m8Text.text == m7Text.text)
                {
                    Correct();
                    DecreaseM1Slider(); // �Ō�̕����܂Ő��������͂��ꂽ�ꍇ�Am1slider ������
                }
                else
                {
                    // �������̉����Đ�
                    // audioSource.PlayOneShot(m4BGM);
                    AudioConfig.Instance.seAudioSources[3].Play();
                }
            }
            else
            {
                // m8Text �̎��̕������Ԉ���Ă���ꍇ
                Miss();
            }

            if (mslider.value <= 0)
            {
                m8Text.text = "";
                m7Text.text = "";
            }
        }
    }

    void Correct()
    {
        Debug.Log("����");
        m7Text.text = "";

        if (flag == 1)
        {
            DisplayRandomElement(_hatudou1);
            m8Text.text = "";
            // ���@1��BGM���Đ�
            // audioSource.PlayOneShot(m1BGM);
            AudioConfig.Instance.seAudioSources[0].Play();
            // m1BGM���Đ����ꂽ�Ƃ��Ƀp�[�e�B�N���V�X�e����\��
            InstantiateEffect(m1effectParticleSystem);
        }
        else if (flag == 2)
        {
            DisplayRandomElement(_hatudou2);
            m8Text.text = "";
            // ���@2��BGM���Đ�
            // audioSource.PlayOneShot(m2BGM);
            AudioConfig.Instance.seAudioSources[1].Play();
            // m2BGM���Đ����ꂽ�Ƃ��Ƀp�[�e�B�N���V�X�e����\��
            InstantiateEffect(m2effectParticleSystem);
        }
        else if (flag == 3)
        {
            DisplayRandomElement(_hatudou3);
            m8Text.text = "";
            // ���@3��BGM���Đ�
            // audioSource.PlayOneShot(m3BGM);
            AudioConfig.Instance.seAudioSources[2].Play();
            // m3BGM���Đ����ꂽ�Ƃ��Ƀp�[�e�B�N���V�X�e����\��
            InstantiateEffect(m3effectParticleSystem);
        }
    }


    [SerializeField] public GameObject TitlePanel;    // �y �ǉ� �z���j���[�p�l���̃A�N�e�B�u��Ԃ��擾���܂��B


void Miss()
    {


        // �y �ǉ� �z���j���[�p�l�����A�N�e�B�u�ȏꍇ�̓_���[�W���󂯂Ȃ��悤�ɁB
        if (TitlePanel.activeSelf)
        {
            return;
        }



        Debug.Log("�s����");
        DecreaseM2Slider(); // �s��������m2slider������

        if (flag == 1)
        {
            DisplayRandomElement(_hatudou1);
        }
        else if (flag == 2)
        {
            DisplayRandomElement(_hatudou2);
        }
        else if (flag == 3)
        {
            DisplayRandomElement(_hatudou3);
        }

        if (m8Text.text.Length > 0 && m7Text.text.Length > 0)
        {
            if (m8Text.text[m8Text.text.Length - 1] == m7Text.text[m7Text.text.Length - 1])
            {
                // �Ō�̕�������v����ꍇ�Am1slider ������
                DecreaseM1Slider();
            }
        }

        if (mslider.value <= 0)
        {
            m8Text.text = "";
            m7Text.text = "";
        }
    }

    void DecreaseM1Slider()
    {
        if (flag == 1)
        {
            mslider.value = Mathf.Max(0, mslider.value - 50);
        }else if(flag == 2)
        {
            mslider.value = Mathf.Max(0, mslider.value - 100);
        }else if (flag == 3)
        {
            mslider.value = Mathf.Max(0, mslider.value - 200);
        }
    }

    void DecreaseM2Slider()
    {
        float previousValue = m2slider.value;

        // m2slider�̒l��10����������i�܂���0�����ɂȂ�Ȃ��悤�ɂ���j
        m2slider.value = Mathf.Max(0, m2slider.value - 100);

        // ���O�̒l�����������ꍇ�Am5BGM���Đ�
        if (m2slider.value < previousValue)
        {
            // audioSource.PlayOneShot(m5BGM);
            AudioConfig.Instance.seAudioSources[4].Play();
            // m5BGM���Đ����ꂽ�Ƃ��Ƀp�[�e�B�N���V�X�e����\��
            InstantiateEffect(m4effectParticleSystem);
        }
        // ���̌�ɃR�[�h�������\��������܂��i����΁j
    }

    void EndGame()
    {
        // �Q�[���I�������������ɋL�q
        // �Ⴆ�΁ARPG scene �ɑJ�ڂ���Ȃ�

        // RPG scene �ɑJ�ڂ���ꍇ
        SceneManager.LoadScene("RPG scene");
    }

    void InstantiateEffect(ParticleSystem particleSystem)
    {
        // �p�[�e�B�N���V�X�e���ւ̎Q�Ƃ�null�łȂ����Ƃ��m�F
        if (particleSystem != null)
        {
            // �p�[�e�B�N���V�X�e�����w��ʒu�ɃC���X�^���X���i�K�v�ɉ����Ĉʒu�Ȃǂ𒲐��j
            Instantiate(particleSystem, transform.position, Quaternion.identity);
        }
    }
}