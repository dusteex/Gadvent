using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundEventManager : MonoBehaviour
{
    static public UnityEvent<AudioClip[]> GunSoundEvent = new UnityEvent<AudioClip[]>();
    static public UnityEvent<AudioClip[]> EnemyDeathSoundEvent = new UnityEvent<AudioClip[]>();

    [SerializeField] AudioSource _audioGun;
    [SerializeField] AudioSource _audioEnemy;


    void Start()
    {
        GunSoundEvent.AddListener(clips => 
        {
            PlaySound(_audioGun,clips);
        });
        EnemyDeathSoundEvent.AddListener(clips => 
        {
            PlaySound(_audioEnemy,clips);
        });
    }

    private void PlaySound(AudioSource source , AudioClip[] clips)
    {
        source.clip = clips[Random.Range(0,clips.Length)];
        source.Play();
    }

}
