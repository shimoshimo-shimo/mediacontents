using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl_V : MonoBehaviour
{
    public Button[] buttons; // 3つのボタンを割り当てる
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

        // いずれかのパネルがアクティブの場合は処理をスキップ
        if (OptionPanel.activeSelf || StartConfirm.activeSelf || QuitConfirm.activeSelf)
        {
            return;
        }


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
            colors.normalColor = Color.gray; // 水色に変更
            button.colors = colors;

            // クリックイベントを一度クリアして再設定
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnButtonClick(button)); // ボタンがクリックされたときの処理を追加
        }

        // 現在のボタンをグレーに変更
        ColorBlock selectedButtonColors = buttons[currentIndex].colors;
        selectedButtonColors.normalColor = Color.cyan; // グレーに変更
        buttons[currentIndex].colors = selectedButtonColors;
    }

    private void OnButtonClick(Button clickedButton)
    {
        // ボタンがクリックされたときの処理をここに追加
        Debug.Log(clickedButton.name + " clicked!");
    }

}