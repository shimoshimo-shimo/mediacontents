using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField] Text m1Text; // 発動中魔１
    [SerializeField] Text m2Text; // 発動中魔２
    [SerializeField] Text m3Text; // 発動中魔３

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

    void Start()
    {
        OutPut();
    }

    void Update()
    {
        if (Input.GetKeyDown(_h1string[_1aNum].ToString()))
        {
            // 正解
            _1aNum++;
            Debug.Log("正解");

            if (_1aNum >= _h1string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.GetKeyDown(_h2string[_2aNum].ToString()))
        {
            // 正解
            _2aNum++;
            Debug.Log("正解");

            if (_2aNum >= _h2string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.GetKeyDown(_h3string[_3aNum].ToString()))
        {
            // 正解
            _3aNum++;
            Debug.Log("正解");

            if (_3aNum >= _h3string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.anyKeyDown)
        {
            // 失敗
            Miss();
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

        // 文字変更
        m1Text.text = _h1string;
        m2Text.text = _h2string;
        m3Text.text = _h3string;
    }

    void Correct()
    {
        Debug.Log("正解");
        // ここに正解時の処理を追加
    }

    void Miss()
    {
        Debug.Log("不正解");
        // ここに不正解時の処理を追加
    }
}