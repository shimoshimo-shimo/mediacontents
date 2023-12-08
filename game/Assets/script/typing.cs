using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField] Text m1Text; // ���������P
    [SerializeField] Text m2Text; // ���������Q
    [SerializeField] Text m3Text; // ���������R
    [SerializeField] Text m7Text; // ���͌���
    [SerializeField] Slider progressSlider; // �ǉ��F�i���\���p�̃X���C�_�[

    private string[] _hatudou1 = { "1act", "1ice", "1mad", "1sue" }; // 3
    private string[] _hatudou2 = { "2abortion", "2covenant", "2suppress", "2betrayal" }; // 8
    private string[] _hatudou3 = { "diversification", "3gastroenteritis", "3transfiguration" }; // 15

    private string _h1string;
    private string _h2string;
    private string _h3string;

    private int _1qNum;
    private int _2qNum;
    private int _3qNum;

    private int _1aNum;
    private int _2aNum;
    private int _3aNum;

    private string enteredText = ""; // Store entered text

    void Start()
    {
        OutPut();
    }

    void Update()
    {
        if (Input.GetKeyDown(_h1string[0].ToString()))
        {
            UpdateEnteredText(m1Text.text);
            CheckAnswer(_h1string, ref _1aNum);
        }
        else if (Input.GetKeyDown(_h2string[0].ToString()))
        {
            UpdateEnteredText(m2Text.text);
            CheckAnswer(_h2string, ref _2aNum);
        }
        else if (Input.GetKeyDown(_h3string[0].ToString()))
        {
            UpdateEnteredText(m3Text.text);
            CheckAnswer(_h3string, ref _3aNum);
        }
        else if (Input.anyKeyDown)
        {
            // ���s
            Miss();
        }

        // Update m7Text with entered text
        m7Text.text = enteredText;

        // �ǉ��F�i���\���p�̃X���C�_�[�̒l���X�V
        UpdateProgressSlider();
    }

    void UpdateEnteredText(string textToUpdate)
    {
        // Concatenate entered text from the first letter of the provided text
        enteredText = textToUpdate.Substring(0, 1);
    }

    void CheckAnswer(string currentString, ref int currentAnswerNum)
    {
        // ����
        currentAnswerNum++;
        UpdateEnteredText(currentString);

        Debug.Log("����");

        if (currentAnswerNum >= currentString.Length)
        {
            Correct();
            OutPut();
        }
    }

    void OutPut()
    {
        _1aNum = 0;
        _2aNum = 0;
        _3aNum = 0;

        _1qNum = Random.Range(0, _hatudou1.Length);
        _2qNum = Random.Range(0, _hatudou2.Length);
        _3qNum = Random.Range(0, _hatudou3.Length);

        _h1string = _hatudou1[_1qNum];
        _h2string = _hatudou2[_2qNum];
        _h3string = _hatudou3[_3qNum];

        // �����ύX
        m1Text.text = _h1string;
        m2Text.text = _h2string;
        m3Text.text = _h3string;

        // �ǉ��F�X���C�_�[�̒l�����Z�b�g
        progressSlider.value = 0;
    }

    void Correct()
    {
        Debug.Log("����");
        // �����ɐ������̏�����ǉ�

        // �ǉ��F�i���\���p�̃X���C�_�[�̒l���X�V
        UpdateProgressSlider();
    }

    void Miss()
    {
        Debug.Log("�s����");
        // �����ɕs�������̏�����ǉ�
    }

    // �ǉ��F�i���\���p�̃X���C�_�[�̒l���X�V
    void UpdateProgressSlider()
    {
        float totalQuestions = _hatudou1.Length + _hatudou2.Length + _hatudou3.Length;
        float answeredQuestions = _1aNum + _2aNum + _3aNum;

        // �i�����v�Z���A�X���C�_�[�ɔ��f
        float progress = answeredQuestions / totalQuestions;
        progressSlider.value = progress;
    }
}