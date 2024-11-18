using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public RectTransform playerRect; // ��Ҷ���� RectTransform
    public float moveSpeed = 100f;   // �ƶ��ٶ�

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRect.anchoredPosition += input * moveSpeed * Time.deltaTime;

        // ����λ�õ���Ļ��Χ
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(playerRect.anchoredPosition.x, -Screen.width / 2f, Screen.width / 2f),
            Mathf.Clamp(playerRect.anchoredPosition.y, -Screen.height / 2f, Screen.height / 2f)
        );

        playerRect.anchoredPosition = clampedPosition;
    }
}
