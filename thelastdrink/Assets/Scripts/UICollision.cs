using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollision : MonoBehaviour
{
    public RectTransform playerRect;      // 玩家对象
    public RectTransform targetRect;      // 目标对象

    void Update()
    {
        // 检查两个 RectTransform 是否重叠
        if (IsOverlapping(playerRect, targetRect))
        {
            Debug.Log("Player is colliding with the target!");
        }
    }

    bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        // 获取两者的屏幕空间边界
        Rect rectA = GetWorldRect(rect1);
        Rect rectB = GetWorldRect(rect2);

        // 检测重叠
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
