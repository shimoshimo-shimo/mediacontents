using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle2 : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    public int d;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        d = PlayerPrefs.GetInt("D", 0);
        if (d == 1)
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
        audioSource.PlayOneShot(sound1);
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
        d = 1;
        PlayerPrefs.SetInt("D", d);
        // �I�u�W�F�N�g���A�N�e�B�u�ɂ���
        objectToDeactivate.SetActive(false);
        pos.playerpos.Savepos();
        // �V�[�������[�h
        SceneManager.LoadScene("Typing Scene 1");
    }
}







