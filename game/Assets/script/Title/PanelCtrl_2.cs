using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PanelCtrl_2 : MonoBehaviour
{
    [SerializeField] public GameObject TitlePanel;
    [SerializeField] public GameObject OptionPanel;
    [SerializeField] public GameObject StartConfirm;
    [SerializeField] public GameObject QuitConfirm;
    [SerializeField] public GameObject ReadmePanel;

    private int currentIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        TitlePanel.SetActive(false);
        OptionPanel.SetActive(false);
        StartConfirm.SetActive(false);
        QuitConfirm.SetActive(false);
        ReadmePanel.SetActive(false);

        currentIndex = 0;
        Debug.Log(currentIndex);
    }

    //�I�v�V�����p�l�������@���̎�i
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentIndex == 0)
            {
                ShowTitlePanel();
                currentIndex = 1;
            }
            else if (currentIndex == 1)
            {
                if (OptionPanel.activeSelf)
                {
                    HideOptionPanel();
                }
                else if (ReadmePanel.activeSelf)
                {
                    HideReadmePanel();
                }
                else
                {
                    HideTitlePanel();
                    currentIndex = 0;
                }
            }
        }
    }


    // �y�@���j���|�p�l���@�z
    public void ShowTitlePanel()
    {
        TitlePanel.SetActive(true);
    }

    public void HideTitlePanel()
    {
        TitlePanel.SetActive(false);
    }


    // �y�@�I�v�V�����p�l���@�z
    public void ShowOptionPanel()
    {
        OptionPanel.SetActive(true);
        //currentIndex = 2;
        Debug.Log(currentIndex);
    }

    public void HideOptionPanel()
    {
        OptionPanel.SetActive(false);
    }

    // �y�@�Q�[�����J�n�@�z
    public void ShowStartConfirm()
    {
        StartCoroutine(ShowPopupAndLoadScene());
    }

    IEnumerator ShowPopupAndLoadScene()
    {
        // �|�b�v�A�b�v��\��
        StartConfirm.SetActive(true);

        // 1.0�b�ҋ@
        yield return new WaitForSeconds(1f);

        // �|�b�v�A�b�v���\���ɂ��ăV�[����J��
        StartConfirm.SetActive(false);
        SceneManager.LoadScene("RPG scene");
    }


    // �y�@�Q�[�����I���@�z
    public void ShowQuitConfirm()
    {
        QuitConfirm.SetActive(true);
        //currentIndex = 2;
    }

    public void HideQuitConfirm()
    {
        QuitConfirm.SetActive(false);
        currentIndex = 1;
    }
    public void GoQuit()
    {
        Application.Quit();
    }




    // �y�@Readme�t�@�C���@�z
    public void ShowReadmePanel()
    {
        ReadmePanel.SetActive(true);
        ReadmeFiles();
        //currentIndex = 2;
    }

    public void HideReadmePanel()
    {
        ReadmePanel.SetActive(false);
    }




    // �y�@Readme�t�@�C���ǂݍ��݁@�z
    public Text readmeText;

    public void ReadmeFiles()
    {
        string filePath = "Assets/ReadmeFile.txt";

        if (File.Exists(filePath))
        {
            string readmeContent = File.ReadAllText(filePath);

            // readmeText �t�B�[���h�� null �łȂ����Ƃ��m�F����
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