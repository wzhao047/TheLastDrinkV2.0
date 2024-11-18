using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;      // ���ڲ������ֵ� AudioSource
    public AudioClip initialClip;       // ��һ������
    public AudioClip lightsOffClip;     // lights off ʱ������

    private bool isLightsOff = false;   // ����Ƿ��Ѿ��л��� Lights Off ������

    void Start()
    {
        // ȷ�� AudioSource ����ȷ����
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
            return;
        }

        // ���ų�ʼ����
        PlayInitialMusic();
    }

    public void PlayInitialMusic()
    {
        if (initialClip != null)
        {
            audioSource.clip = initialClip;
            audioSource.loop = true; // ѭ������
            audioSource.Play();
            Debug.Log("Playing initial music.");
        }
        else
        {
            Debug.LogError("Initial music clip is not assigned!");
        }
    }

    public void PlayLightsOffMusic()
    {
        if (!isLightsOff && lightsOffClip != null)
        {
            audioSource.clip = lightsOffClip;
            audioSource.loop = true; // ѭ������
            audioSource.Play();
            Debug.Log("Playing lights off music.");
            isLightsOff = true; // ��ֹ�ظ��л�
        }
        else if (isLightsOff)
        {
            Debug.Log("Lights off music is already playing.");
        }
        else
        {
            Debug.LogError("Lights off music clip is not assigned!");
        }
    }
}
