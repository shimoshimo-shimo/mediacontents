using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PanelCtrl : MonoBehaviour
{
    [SerializeField] public GameObject OptionPanel;
    [SerializeField] public GameObject StartConfirm;
    [SerializeField] public GameObject QuitConfirm;
    [SerializeField] public GameObject ReadmePanel;



    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
        StartConfirm.SetActive(false);
        QuitConfirm.SetActive(false);
        ReadmePanel.SetActive(false);
    }

    //オプションパネルを閉じる　仮の手段
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            HideOptionPanel();
            HideReadmePanel();


        }
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




    // 【　Readmeファイル　】
    public void ShowReadmePanel()
    {
        ReadmePanel.SetActive(true);
        ReadmeFiles();
    }

    public void HideReadmePanel()
    {
        ReadmePanel.SetActive(false);
    }




    // 【　Readmeファイル読み込み　】
    public Text readmeText;

    public void ReadmeFiles()
    {
        string filePath = "Assets/ReadmeFile.txt";

        if (File.Exists(filePath))
        {
            string readmeContent = File.ReadAllText(filePath);

            // readmeText フィールドが null でないことを確認する
            if (readmeText != null)
            {
                readmeText.text = readmeContent;
            }
            else
            {
                Debug.LogError("readmeText is not assigned. Assign the Text component in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("Readme file not found!");
        }
    }
    


}