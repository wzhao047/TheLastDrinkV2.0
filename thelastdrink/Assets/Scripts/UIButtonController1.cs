using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController1 : MonoBehaviour
{
    public GameObject shootButton;  // �����ť
    public GameObject talkButton;   // �Ի���ť
    public GameObject interactButton; // ������ť

    // ���ť����
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

    // ���ð�ť����
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
