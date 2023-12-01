using System;
using UnityEngine;

public enum SoundType
{
    Jump,
    Background_Music
}

[Serializable]
public class Sound
{
    public SoundType Type;
    public AudioClip Clip;
    public float Volume;
}

// Singleton class for sounds in the game

public class SoundManager : GenericMonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource _sourceFX;
    [SerializeField] private AudioSource _sourceBG;

    [SerializeField] private Sound[] sounds;

    private void Start()
    {
        PlayBG(SoundType.Background_Music);
    }

    public void PlaySFX(SoundType Type)
    {
        Sound sound = Array.Find(sounds, i => i.Type == Type);
        _sourceFX.clip = sound.Clip;
        _sourceFX.volume = sound.Volume;
        _sourceFX.Play();
    }

    public void PlayBG(SoundType Type)
    {
        Sound sound = Array.Find(sounds, i => i.Type == Type);
        _sourceBG.clip = sound.Clip;
        _sourceBG.volume = sound.Volume;
        _sourceBG.loop = true;
        _sourceBG.Play();
    }
}
