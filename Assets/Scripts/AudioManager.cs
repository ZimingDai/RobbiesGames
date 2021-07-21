using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Audio;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    private static AudioManager current;

    [Header("环境声音")] 
    public AudioClip ambientClip;
    public AudioClip musicClip;
    
    
    [Header("FX音效")] 
    public AudioClip deathFXClip;

    public AudioClip orbFXClip;

    [Header("Robbie音效")] 
    public AudioClip[] walkStepClips;
    public AudioClip[] crouchStepClips;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    public AudioClip jumpVoiceClip;
    public AudioClip deathVoiceClip;
    public AudioClip orbVoiceClip;

    private AudioSource ambientSource;
    private AudioSource musicSource;
    private AudioSource fxSource;
    private AudioSource playerSource;
    private AudioSource voiceSource;
    
    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        
        current = this;
        
        DontDestroyOnLoad(gameObject);

        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();

        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        current.ambientSource.clip = current.ambientClip;
        current.ambientSource.loop = true;
        current.ambientSource.Play();

        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();
        
        
    }
    public static void PlayFootstepAudio()
    {
        int index = new Random().Next(0, current.walkStepClips.Length);
        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }
    public static void PlayCrouchFootstepAudio()
    {
        int index = new Random().Next(0, current.crouchStepClips.Length);
        current.playerSource.clip = current.crouchStepClips[index];
        current.playerSource.Play();
    }

    public static void PlayJumpAudio()
    {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();
        
        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }

    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.deathFXClip;
        current.fxSource.Play();
    }

    public static void PlayOrbAudio()
    {
        current.fxSource.clip = current.orbFXClip;
        current.fxSource.Play();

        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();
    } 
}
