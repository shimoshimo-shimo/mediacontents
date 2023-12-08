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


    // �y�@�I�v�V�����p�l���@�z
    public void ShowOptionPanel()
    {
        OptionPanel.SetActive(true);
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