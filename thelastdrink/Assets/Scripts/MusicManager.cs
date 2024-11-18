using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;      // 用于播放音乐的 AudioSource
    public AudioClip initialClip;       // 第一首曲子
    public AudioClip lightsOffClip;     // lights off 时的曲子

    private bool isLightsOff = false;   // 标记是否已经切换到 Lights Off 的音乐

    void Start()
    {
        // 确保 AudioSource 被正确分配
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
            return;
        }

        // 播放初始音乐
        PlayInitialMusic();
    }

    public void PlayInitialMusic()
    {
        if (initialClip != null)
        {
            audioSource.clip = initialClip;
            audioSource.loop = true; // 循环播放
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
            audioSource.loop = true; // 循环播放
            audioSource.Play();
            Debug.Log("Playing lights off music.");
            isLightsOff = true; // 防止重复切换
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
