using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    

    public GameObject target; // �Ǐ]����Ώۂ����߂�ϐ�
    Vector3 pos;              // �J�����̏����ʒu���L�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; //�J�����̏����ʒu��ϐ�pos�ɓ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position; // cameraPos�Ƃ����ϐ������A�Ǐ]����Ώۂ̈ʒu������

        // �����Ώۂ̉��ʒu��0��菬�����ꍇ
        /*if (target.transform.position.x < 0)
        {
            cameraPos.x = 0; // �J�����̉��ʒu��0������
        }

        // �����Ώۂ̏c�ʒu��0��菬�����ꍇ
        if (target.transform.position.y < 0)
        {
            cameraPos.y = 0;  // �J�����̏c�ʒu��0������
        }

        // �����Ώۂ̏c�ʒu��0���傫���ꍇ
        if (target.transform.position.y > 0)
        {
            cameraPos.y = target.transform.position.y;   // �J�����̏c�ʒu�ɑΏۂ̈ʒu������
        }*/

        cameraPos.z = -10; // �J�����̉��s���̈ʒu��-10������
        Camera.main.gameObject.transform.position = cameraPos; //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������

        
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
                Debug.Log($"Savepos - �擾�������W: {worldPos}");

                x = worldPos.x;
                y = worldPos.y;
                a = a + 1;
                PlayerPrefs.SetFloat("X", x);
                PlayerPrefs.SetFloat("Y", y);
                PlayerPrefs.SetInt("A", a);

                Debug.Log($"Savepos - �ۑ��������W: {x}, {y}");
                Debug.Log(a);
            }
            else
            {
                Debug.LogError("�v���C���[�I�u�W�F�N�g��������܂���ł����B");
            }
        }

        public static void Loadpos()
        {
            x = PlayerPrefs.GetFloat("X", 0);
            y = PlayerPrefs.GetFloat("Y", 3);
            a = PlayerPrefs.GetInt("A", 0);
            
            Debug.Log($"Loadpos - �ǂݍ��񂾍��W: {x}, {y}");
            
            GameObject playerObject = GameObject.Find("pipo-charachip029_0");
            GameObject gaga = GameObject.Find("pipo-charachip019_0");

            // �v���C���[�I�u�W�F�N�g�̍��W��ݒ�
            playerObject.transform.position = new Vector3(x, y);

            if(a == 3)
            {
                SceneManager.LoadScene("Test scene");
            }
        }
        
    }
}