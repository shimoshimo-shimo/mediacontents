using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HandleButtonClick(Button clickedButton)
    {
        // �����Ƀ{�^�����N���b�N���ꂽ�Ƃ��̋�̓I�ȏ�����ǉ�
        // �Ⴆ�΁A�{�^�����ƂɈقȂ鏈�����s�������ꍇ�́A����������g���Ĕ��ʂ��邱�Ƃ��ł��܂�

        // ���̗�: �{�^���̖��O�����O�ɏo��
        Debug.Log("Button Clicked: " + clickedButton.name);
    }

}
