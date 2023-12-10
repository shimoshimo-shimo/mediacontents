using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CommandSelectColor : MonoBehaviour
{
    public Button[] buttons; // 3�̃{�^�������蓖�Ă�
    private int currentIndex = 0;

    private BtnCtrl buttonController;

    private void Start()
    {
        buttonController = GetComponent<BtnCtrl>();
        UpdateButtonColors();
    }

    private void Update()
    {
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

        // Enter�L�[||�X�y�[�X�L�[�Ń{�^����I��
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
            colors.normalColor = Color.cyan; // ���F�ɕύX
            button.colors = colors;

            // �N���b�N�C�x���g����x�N���A���čĐݒ�
            buttons[currentIndex].onClick.RemoveAllListeners();
            buttons[currentIndex].onClick.AddListener(() => OnButtonClick(buttons[currentIndex]));
        }

        // ���݂̃{�^�����O���[�ɕύX
        ColorBlock selectedButtonColors = buttons[currentIndex].colors;
        selectedButtonColors.normalColor = Color.gray; // �O���[�ɕύX
        buttons[currentIndex].colors = selectedButtonColors;
    }

    private void OnButtonClick(Button clickedButton)
    {
        // �{�^�����Ƃ̏�����BtnCtrl�Ɉϑ�
        buttonController.HandleButtonClick(clickedButton);
    }
}
