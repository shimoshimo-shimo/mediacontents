using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl_V : MonoBehaviour
{
    public Button[] buttons; // 3�̃{�^�������蓖�Ă�
    private int currentIndex = 0;

    public GameObject OptionPanel;
    public GameObject StartConfirm;
    public GameObject QuitConfirm;



    private void Start()
    {
        UpdateButtonColors();
    }



    private void Update()
    {

        // �����ꂩ�̃p�l�����A�N�e�B�u�̏ꍇ�͏������X�L�b�v
        if (OptionPanel.activeSelf || StartConfirm.activeSelf || QuitConfirm.activeSelf)
        {
            return;
        }


            // ���L�[�Ɓ��L�[�Ń{�^����I��
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentIndex = (currentIndex - 1 + buttons.Length) % buttons.Length;
                UpdateButtonColors();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentIndex = (currentIndex + 1) % buttons.Length;
                UpdateButtonColors();
            }

            // Enter�L�[ || �X�y�[�X�L�[�Ń{�^����I��
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                // �{�^���̃N���b�N���V�~�����[�g
                buttons[currentIndex].onClick.Invoke();
            }

    }

    private void UpdateButtonColors()
    {
        // ���ׂẴ{�^�����f�t�H���g�̐F�ɐݒ�i������3�̃{�^���̐F���ꊇ�ύX�\�j
        foreach (Button button in buttons)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.gray; // ���F�ɕύX
            button.colors = colors;

            // �N���b�N�C�x���g����x�N���A���čĐݒ�
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnButtonClick(button)); // �{�^�����N���b�N���ꂽ�Ƃ��̏�����ǉ�
        }

        // ���݂̃{�^�����O���[�ɕύX
        ColorBlock selectedButtonColors = buttons[currentIndex].colors;
        selectedButtonColors.normalColor = Color.cyan; // �O���[�ɕύX
        buttons[currentIndex].colors = selectedButtonColors;
    }

    private void OnButtonClick(Button clickedButton)
    {
        // �{�^�����N���b�N���ꂽ�Ƃ��̏����������ɒǉ�
        Debug.Log(clickedButton.name + " clicked!");
    }

}