using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_text : MonoBehaviour
{
    public GameObject score_object = null; // Text�I�u�W�F�N�g
    private int HP; // �܂��͑��̓K�؂Ȍ^

    // statasManager��錾
    

    // ������
    void Start()
    {
        // statasManager���C���X�^���X��
        

        // �f�[�^�̃��[�h
        statasManager.LoadData();

        // HP���擾
        HP = statasManager.HP;
    }

    // �X�V
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();

        // HP�𕶎���ɕϊ����ĕ\��
        score_text.text = HP.ToString();
    }
}