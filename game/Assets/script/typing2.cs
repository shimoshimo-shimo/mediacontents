using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーンマネジメントを使用するための追加

public class typing2 : MonoBehaviour
{
    [SerializeField] Text m1Text; // 発動前魔１
    [SerializeField] Text m2Text; // 発動前魔２
    [SerializeField] Text m3Text; // 発動前魔３
    [SerializeField] Text m4Text; // 発動中魔１
    [SerializeField] Text m5Text; // 発動中魔２
    [SerializeField] Text m6Text; // 発動中魔３
    [SerializeField] Text m7Text; // 入力する魔法
    [SerializeField] Text m8Text; // 入力してる魔法
    [SerializeField] Slider mslider;

    private string[] _hatudou1 = { "1act", "1ice", "1mad", "1sue" }; // 3
    private string[] _hatudou2 = { "2abortion", "2covenant", "2suppress", "2betrayal" }; // 8
    private string[] _hatudou3 = { "3diversification", "3gastroenteritis", "3transfiguration" }; // 15

    private bool isTyping = false; // キーが押されているかどうかを示すフラグ

    public int flag;

    // Start is called before the first frame update
    void Start()
    {
        // 初期値を設定
        m1Text.text = "弱攻撃";
        m2Text.text = "中攻撃";
        m3Text.text = "強攻撃";

        mslider.maxValue = 1000; // スライダーの最大値を1000に設定
        mslider.value = mslider.maxValue; // ゲーム開始時にスライダーの値を最大に設定

        // Unityのランダム関数を初期化
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {

        // キーボードの1, 2, 3が押されたら対応する_hatudouのランダムな要素を表示
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

        // m7Textに表示された文字列が正確に入力された場合、スライダーの値を10減少させる
        if (Input.GetKeyDown(KeyCode.Return)) // Enterキーが押された場合
        {
            CheckInputAndUpdateSlider();
            isTyping = true;
            m8Text.text = "";
        }

        // キーが押されている場合、m8Textに入力された文字列を表示
        if (isTyping)
        {
            
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                // 数字キーは表示しない
                if ((keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9) || keyCode == KeyCode.Return)
                {
                    continue;
                }

                if (Input.GetKeyDown(keyCode))
                {
                    m8Text.text += keyCode.ToString().ToLower(); // 小文字に変換して追加
                }
            }
        }
    }

    // 配列からランダムな要素の最初の文字を取得して表示
    void DisplayRandomElement(string[] array)
    {
        if (array.Length > 0)
        {
            m8Text.text = "";
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            // 最初の1文字以外を表示
            m7Text.text = array[randomIndex].Substring(1);
            // タイピング開始
            isTyping = true;
            m8Text.text = "";
        }
        else
        {
            m7Text.text = "Empty Array";
        }
    }

    void CheckInputAndUpdateSlider()
    {
        // m8Text と m7Text が等しいか確認
        if (m8Text.text == m7Text.text)
        {
            // 入力が正確な場合、スライダーの値を10減少させる
            mslider.value = Mathf.Max(0, mslider.value - 100);

            // 正解時の処理を呼び出し
            Correct();
        }
        else
        {
            // 不正解時の処理を呼び出し
            Miss();
        }

        // タイピング終了
        isTyping = false;
        m8Text.text = "";


        // スライダーが減少したら m8Text と m7Text をリセット
        if (mslider.value <= 0)
        {
            m8Text.text = "";
            m7Text.text = "";

            // 新しいシーンを読み込む（ここでは"GameOverScene"を仮定）
            //SceneManager.LoadScene("GameOverScene");
        }
    }

    // 入力された文字列が正解かどうかを判定
    bool IsCorrectInput(string inputText)
    {
        return Array.Exists(_hatudou1, element => element.Substring(1) == inputText) ||
               Array.Exists(_hatudou2, element => element.Substring(1) == inputText) ||
               Array.Exists(_hatudou3, element => element.Substring(1) == inputText);
        m8Text.text = "";
    }

    // 正解時の処理
    void Correct()
    {
        Debug.Log("正解");
        // ここに正解時の処理を追加
        if (flag == 1)
        {
            DisplayRandomElement(_hatudou1);
            m8Text.text = "";
        }
        else if (flag == 2)
        {
            DisplayRandomElement(_hatudou2);
            m8Text.text = "";
        }
        else if (flag == 3)
        {
            DisplayRandomElement(_hatudou3);
            m8Text.text = "";
        }

    }

    // 不正解時の処理
    void Miss()
    {
        Debug.Log("不正解");
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
        // ここに不正解時の処理を追加
    }
}
