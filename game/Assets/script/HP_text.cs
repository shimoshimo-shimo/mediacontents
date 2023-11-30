using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_text : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    private int HP; // または他の適切な型

    // statasManagerを宣言
    

    // 初期化
    void Start()
    {
        // statasManagerをインスタンス化
        

        // データのロード
        statasManager.LoadData();

        // HPを取得
        HP = statasManager.HP;
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();

        // HPを文字列に変換して表示
        score_text.text = HP.ToString();
    }
}