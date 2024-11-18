using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollision : MonoBehaviour
{
    public RectTransform playerRect;      // ��Ҷ���
    public RectTransform targetRect;      // Ŀ�����

    void Update()
    {
        // ������� RectTransform �Ƿ��ص�
        if (IsOverlapping(playerRect, targetRect))
        {
            Debug.Log("Player is colliding with the target!");
        }
    }

    bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        // ��ȡ���ߵ���Ļ�ռ�߽�
        Rect rectA = GetWorldRect(rect1);
        Rect rectB = GetWorldRect(rect2);

        // ����ص�
        return rectA.Overlaps(rectB);
    }

    Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];

        return new Rect(bottomLeft, topRight - bottomLeft);
    }
}
