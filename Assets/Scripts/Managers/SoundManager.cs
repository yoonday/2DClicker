using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume; // BGM ����

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        changeBackgroundMusic(musicClip);
    }

    private void changeBackgroundMusic(AudioClip musicClip)
    {
        instance.musicAudioSource.Stop(); // ������ �ʰ� ���ٰ� �����ϱ�
        instance.musicAudioSource.clip = musicClip;
        instance.musicAudioSource.Play();
    }

    public static void PlayClip(AudioClip clip)
    {
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, instance.soundEffectVolume,instance.soundEffectPitchVariance);

    }
}
