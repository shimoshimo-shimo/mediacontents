using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HandleButtonClick(Button clickedButton)
    {
        // ここにボタンがクリックされたときの具体的な処理を追加
        // 例えば、ボタンごとに異なる処理を行いたい場合は、条件分岐を使って判別することができます

        // 仮の例: ボタンの名前をログに出力
        Debug.Log("Button Clicked: " + clickedButton.name);
    }

}
