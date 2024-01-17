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

    private int currentIndex = 0;



    void Start()
    {
        OptionPanel.SetActive(false);
        StartConfirm.SetActive(false);
        QuitConfirm.SetActive(false);
        ReadmePanel.SetActive(false);

        currentIndex = 0;
    }

    //オプションパネルを閉じる
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentIndex == 0)
            {
                ShowQuitConfirm();
                currentIndex = 1;
            }
            else if (currentIndex == 1)
            {
                if (OptionPanel.activeSelf)
                {
                    HideOptionPanel();
                    currentIndex = 0;
                }
                else if (QuitConfirm.activeSelf)
                {
                    HideQuitConfirm();
                    currentIndex = 0;
                }
                else if (ReadmePanel.activeSelf)
                {
                    HideReadmePanel();
                    currentIndex = 0;
                }

            }
        }
    }


    // 【　オプションパネル　】
    public void ShowOptionPanel()
    {
        OptionPanel.SetActive(true);
        currentIndex = 1;
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
        currentIndex = 1;
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