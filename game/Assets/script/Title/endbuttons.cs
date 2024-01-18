using UnityEngine;
using UnityEngine.UI;

public class EndButtons : MonoBehaviour
{
    void Start()
    {
        // 同じGameObjectにButtonコンポーネントがアタッチされていると仮定
        Button button = GetComponent<Button>();

        // Buttonコンポーネントが存在するか確認
        if (button != null)
        {
            // ボタンのonClickイベントにリスナーを追加
            button.onClick.AddListener(EndGame);
        }
        else
        {
            Debug.LogError("GameObjectにButtonコンポーネントが見つかりませんでした。");
        }
    }

    // ボタンがクリックされたときに呼び出される関数
    private void EndGame()
    {
        // ボタンがクリックされたときと同様にゲームを終了させる
        //UnityEditor.EditorApplication.isPlaying = false; // エディタ内での再生を停止
        Application.Quit(); // アプリケーションを終了
    }
}
