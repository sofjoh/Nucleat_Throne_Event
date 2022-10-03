using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public void playWinGameSound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
