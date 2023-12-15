using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �V�[���}�l�W�����g���g�p���邽�߂̒ǉ�

public class typing2 : MonoBehaviour
{
    [SerializeField] Text m1Text; // �����O���P
    [SerializeField] Text m2Text; // �����O���Q
    [SerializeField] Text m3Text; // �����O���R
    [SerializeField] Text m4Text; // ���������P
    [SerializeField] Text m5Text; // ���������Q
    [SerializeField] Text m6Text; // ���������R
    [SerializeField] Text m7Text; // ���͂��閂�@
    [SerializeField] Text m8Text; // ���͂��Ă閂�@
    [SerializeField] Slider mslider;

    private string[] _hatudou1 = { "1act", "1ice", "1mad", "1sue" }; // 3
    private string[] _hatudou2 = { "2abortion", "2covenant", "2suppress", "2betrayal" }; // 8
    private string[] _hatudou3 = { "3diversification", "3gastroenteritis", "3transfiguration" }; // 15

    private bool isTyping = false; // �L�[��������Ă��邩�ǂ����������t���O

    // Start is called before the first frame update
    void Start()
    {
        // �����l��ݒ�
        m1Text.text = "��U��";
        m2Text.text = "���U��";
        m3Text.text = "���U��";

        mslider.maxValue = 1000; // �X���C�_�[�̍ő�l��1000�ɐݒ�
        mslider.value = mslider.maxValue; // �Q�[���J�n���ɃX���C�_�[�̒l���ő�ɐݒ�

        // Unity�̃����_���֐���������
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[�{�[�h��1, 2, 3�������ꂽ��Ή�����_hatudou�̃����_���ȗv�f��\��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisplayRandomElement(_hatudou1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisplayRandomElement(_hatudou2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisplayRandomElement(_hatudou3);
        }

        // m7Text�ɕ\�����ꂽ�����񂪐��m�ɓ��͂��ꂽ�ꍇ�A�X���C�_�[�̒l��10����������
        if (Input.GetKeyDown(KeyCode.Return)) // Enter�L�[�������ꂽ�ꍇ
        {
            CheckInputAndUpdateSlider();
        }

        // �L�[��������Ă���ꍇ�Am8Text�ɓ��͂��ꂽ�������\��
        if (isTyping)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                // �����L�[�͕\�����Ȃ�
                if (keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9)
                {
                    continue;
                }

                if (Input.GetKeyDown(keyCode))
                {
                    m8Text.text += keyCode.ToString().ToLower(); // �������ɕϊ����Ēǉ�
                }
            }
        }
    }

    // �z�񂩂烉���_���ȗv�f�̍ŏ��̕������擾���ĕ\��
    void DisplayRandomElement(string[] array)
    {
        if (array.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            // �ŏ���1�����ȊO��\��
            m7Text.text = array[randomIndex].Substring(1);
            // �^�C�s���O�J�n
            isTyping = true;
        }
        else
        {
            m7Text.text = "Empty Array";
        }
    }

    void CheckInputAndUpdateSlider()
    {
        // m8Text �� m7Text �����������m�F
        if (m8Text.text == m7Text.text)
        {
            // ���͂����m�ȏꍇ�A�X���C�_�[�̒l��10����������
            mslider.value = Mathf.Max(0, mslider.value - 10);

            // �������̏������Ăяo��
            Correct();
        }
        else
        {
            // �s�������̏������Ăяo��
            Miss();
        }

        // �^�C�s���O�I��
        isTyping = false;

        // �X���C�_�[������������ m8Text �� m7Text �����Z�b�g
        if (mslider.value <= 0)
        {
            m8Text.text = "";
            m7Text.text = "";

            // �V�����V�[����ǂݍ��ށi�����ł�"GameOverScene"������j
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // ���͂��ꂽ�����񂪐������ǂ����𔻒�
    bool IsCorrectInput(string inputText)
    {
        return Array.Exists(_hatudou1, element => element.Substring(1) == inputText) ||
               Array.Exists(_hatudou2, element => element.Substring(1) == inputText) ||
               Array.Exists(_hatudou3, element => element.Substring(1) == inputText);
    }

    // �������̏���
    void Correct()
    {
        Debug.Log("����");
        // �����ɐ������̏�����ǉ�
    }

    // �s�������̏���
    void Miss()
    {
        Debug.Log("�s����");
        // �����ɕs�������̏�����ǉ�
    }
}
