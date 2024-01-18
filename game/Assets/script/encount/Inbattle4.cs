using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle4
    : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    public int g;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        g = PlayerPrefs.GetInt("G", 0);
        if(g == 1)
        {
            objectToDeactivate.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // audioSource.PlayOneShot(sound1);
        AudioConfig.Instance.seAudioSources[0].Play();
        StartCoroutine(WaitAndLoadScene());
    }

    public GameObject objectToDeactivate;

    IEnumerator WaitAndLoadScene()
    {
        // ���W�ۑ�
        

        // ��A�N�e�B�u�ɂ������I�u�W�F�N�g�� DontDestroyOnLoad �Ŏw��
        DontDestroyOnLoad(objectToDeactivate);

        // �ҋ@
        yield return new WaitForSeconds(0.6f);
        g = 1;
        PlayerPrefs.SetInt("G", g);
        // �I�u�W�F�N�g���A�N�e�B�u�ɂ���
        objectToDeactivate.SetActive(false);
        pos.playerpos.Savepos();
        // �V�[�������[�h
        SceneManager.LoadScene("typing scene 3");
    }
}



