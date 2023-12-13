/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandSelectColor : MonoBehaviour
{
    public Button[] buttons; // 3つのボタンを割り当てる
    private int currentIndex = 0;


    private void Start()
    {

        UpdateButtonColors();
    }

    private void Update()
    {

        // ↑キーと↓キーでボタンを選択
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

        // Enterキー || スペースキーでボタンを選択
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            // ボタンのクリックをシミュレート
            buttons[currentIndex].onClick.Invoke();
        }
    }

    private void UpdateButtonColors()
    {
        // すべてのボタンをデフォルトの色に設定（ここで3つのボタンの色を一括変更可能）
        foreach (Button button in buttons)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.cyan; // 水色に変更
            button.colors = colors;

            // クリックイベントを一度クリアして再設定
            button.onClick.RemoveAllListeners();

        }

        // 現在のボタンをグレーに変更
        ColorBlock selectedButtonColors = buttons[currentIndex].colors;
        selectedButtonColors.normalColor = Color.gray; // グレーに変更
        buttons[currentIndex].colors = selectedButtonColors;
    }



}*/
