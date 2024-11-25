using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioSource Source;

    public void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }

    public enum Sounds
    {
        EnemyDeath,
        PlayerDeath,
        Select,
        Fire
    }



}
