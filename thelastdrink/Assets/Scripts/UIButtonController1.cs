using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController1 : MonoBehaviour
{
    public GameObject shootButton;  // 射击按钮
    public GameObject talkButton;   // 对话按钮
    public GameObject interactButton; // 交互按钮

    // 激活按钮方法
    public void ActivateShootButton()
    {
        if (shootButton != null)
            shootButton.SetActive(true);
    }

    public void ActivateTalkButton()
    {
        if (talkButton != null)
            talkButton.SetActive(true);
    }

    public void ActivateInteractButton()
    {
        if (interactButton != null)
            interactButton.SetActive(true);
    }

    // 禁用按钮方法
    public void DeactivateShootButton()
    {
        if (shootButton != null)
            shootButton.SetActive(false);
    }

    public void DeactivateTalkButton()
    {
        if (talkButton != null)
            talkButton.SetActive(false);
    }

    public void DeactivateInteractButton()
    {
        if (interactButton != null)
            interactButton.SetActive(false);
    }
}
