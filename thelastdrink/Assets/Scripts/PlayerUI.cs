using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public RectTransform playerRect; // 玩家对象的 RectTransform
    public float moveSpeed = 100f;   // 移动速度

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRect.anchoredPosition += input * moveSpeed * Time.deltaTime;

        // 限制位置到屏幕范围
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(playerRect.anchoredPosition.x, -Screen.width / 2f, Screen.width / 2f),
            Mathf.Clamp(playerRect.anchoredPosition.y, -Screen.height / 2f, Screen.height / 2f)
        );

        playerRect.anchoredPosition = clampedPosition;
    }
}
