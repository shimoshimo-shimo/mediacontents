using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    

    public GameObject target; // 追従する対象を決める変数
    Vector3 pos;              // カメラの初期位置を記憶するための変数

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; //カメラの初期位置を変数posに入れる
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position; // cameraPosという変数を作り、追従する対象の位置を入れる

        // もし対象の横位置が0より小さい場合
        /*if (target.transform.position.x < 0)
        {
            cameraPos.x = 0; // カメラの横位置に0を入れる
        }

        // もし対象の縦位置が0より小さい場合
        if (target.transform.position.y < 0)
        {
            cameraPos.y = 0;  // カメラの縦位置に0を入れる
        }

        // もし対象の縦位置が0より大きい場合
        if (target.transform.position.y > 0)
        {
            cameraPos.y = target.transform.position.y;   // カメラの縦位置に対象の位置を入れる
        }*/

        cameraPos.z = -10; // カメラの奥行きの位置に-10を入れる
        Camera.main.gameObject.transform.position = cameraPos; //　カメラの位置に変数cameraPosの位置を入れる

        
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           SceneManager.LoadScene("Title scene");
        }
        */
        
    }
}
namespace pos
{
    public static class playerpos
    {
        public static float x;
        public static float y;
        public static int a;
        



        public static void Savepos()
        {
            GameObject playerObject = GameObject.Find("pipo-charachip029_0");

            if (playerObject != null)
            {
                Vector3 worldPos = playerObject.transform.position;
                Debug.Log($"Savepos - 取得した座標: {worldPos}");

                x = worldPos.x;
                y = worldPos.y;
                a = a + 1;
                PlayerPrefs.SetFloat("X", x);
                PlayerPrefs.SetFloat("Y", y);
                PlayerPrefs.SetInt("A", a);

                Debug.Log($"Savepos - 保存した座標: {x}, {y}");
                Debug.Log(a);
            }
            else
            {
                Debug.LogError("プレイヤーオブジェクトが見つかりませんでした。");
            }
        }

        public static void Loadpos()
        {
            x = PlayerPrefs.GetFloat("X", 0);
            y = PlayerPrefs.GetFloat("Y", 3);
            a = PlayerPrefs.GetInt("A", 0);
            
            Debug.Log($"Loadpos - 読み込んだ座標: {x}, {y}");
            
            GameObject playerObject = GameObject.Find("pipo-charachip029_0");
            GameObject gaga = GameObject.Find("pipo-charachip019_0");

            // プレイヤーオブジェクトの座標を設定
            playerObject.transform.position = new Vector3(x, y);

            if(a == 3)
            {
                SceneManager.LoadScene("Test scene");
            }
        }
        
    }
}