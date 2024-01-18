using UnityEngine;
using UnityEngine.UI;

public class EndButtons : MonoBehaviour
{
    void Start()
    {
        // ����GameObject��Button�R���|�[�l���g���A�^�b�`����Ă���Ɖ���
        Button button = GetComponent<Button>();

        // Button�R���|�[�l���g�����݂��邩�m�F
        if (button != null)
        {
            // �{�^����onClick�C�x���g�Ƀ��X�i�[��ǉ�
            button.onClick.AddListener(EndGame);
        }
        else
        {
            Debug.LogError("GameObject��Button�R���|�[�l���g��������܂���ł����B");
        }
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��ɌĂяo�����֐�
    private void EndGame()
    {
        // �{�^�����N���b�N���ꂽ�Ƃ��Ɠ��l�ɃQ�[�����I��������
        //UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^���ł̍Đ����~
        Application.Quit(); // �A�v���P�[�V�������I��
    }
}
