using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField] Text m1Text; // ”­“®’†–‚‚P
    [SerializeField] Text m2Text; // ”­“®’†–‚‚Q
    [SerializeField] Text m3Text; // ”­“®’†–‚‚R

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
            // ³‰ğ
            _1aNum++;
            Debug.Log("³‰ğ");

            if (_1aNum >= _h1string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.GetKeyDown(_h2string[_2aNum].ToString()))
        {
            // ³‰ğ
            _2aNum++;
            Debug.Log("³‰ğ");

            if (_2aNum >= _h2string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.GetKeyDown(_h3string[_3aNum].ToString()))
        {
            // ³‰ğ
            _3aNum++;
            Debug.Log("³‰ğ");

            if (_3aNum >= _h3string.Length)
            {
                Correct();
                OutPut();
            }
        }
        else if (Input.anyKeyDown)
        {
            // ¸”s
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

        // •¶š•ÏX
        m1Text.text = _h1string;
        m2Text.text = _h2string;
        m3Text.text = _h3string;
    }

    void Correct()
    {
        Debug.Log("³‰ğ");
        // ‚±‚±‚É³‰ğ‚Ìˆ—‚ğ’Ç‰Á
    }

    void Miss()
    {
        Debug.Log("•s³‰ğ");
        // ‚±‚±‚É•s³‰ğ‚Ìˆ—‚ğ’Ç‰Á
    }
}