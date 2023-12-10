using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelCtrl : MonoBehaviour
{
    [SerializeField] public GameObject OptionPanel;
    [SerializeField] public GameObject StartConfirm;
    [SerializeField] public GameObject QuitConfirm;



    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
        StartConfirm.SetActive(false);
        QuitConfirm.SetActive(false);
    }


    // 【　オプションパネル　】
    public void ShowOptionPanel()
    {
        OptionPanel.SetActive(true);
    }

    public void HideOptionPanel()
    {
        OptionPanel.SetActive(false);
    }

    // 【　ゲームを開始　】
    public void ShowStartConfirm()
    {
        StartCoroutine(ShowPopupAndLoadScene());
    }

    IEnumerator ShowPopupAndLoadScene()
    {
        // ポップアップを表示
        StartConfirm.SetActive(true);

       // 1.0秒待機
       yield return new WaitForSeconds(1f);

       // ポップアップを非表示にしてシーンを遷移
       StartConfirm.SetActive(false);
       SceneManager.LoadScene("RPG scene");
    }


    // 【　ゲームを終了　】
    public void ShowQuitConfirm()
    {
        QuitConfirm.SetActive(true);
    }

    public void HideQuitConfirm()
    {
        QuitConfirm.SetActive(false);
    }
    public void GoQuit()
    {
        Application.Quit();
    }




}