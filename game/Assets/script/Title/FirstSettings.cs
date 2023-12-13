using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSettings : MonoBehaviour
{
    void Start()
    {
        // 画面サイズの固定
        Canvas canvas = GetComponent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // 新しいサイズを設定
        canvasRect.sizeDelta = new Vector2(800f, 600f);
    }
}
