using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSettings : MonoBehaviour
{
    void Start()
    {
        // ��ʃT�C�Y�̌Œ�
        Canvas canvas = GetComponent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // �V�����T�C�Y��ݒ�
        canvasRect.sizeDelta = new Vector2(800f, 600f);
    }
}
