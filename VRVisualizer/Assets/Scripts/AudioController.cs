using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip1, clip2, clip3;

    private AudioSource audioSource;
    private bool clip1IsPlaying = false;
    private bool clip2IsPlaying = false;
    private bool clip3IsPlaying = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip1);
        clip1IsPlaying = true;
    }

    private void Update()
    {
        if (SteamVR_Actions._default.AButtonPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (clip1IsPlaying)
            {
                audioSource.Stop();
                clip1IsPlaying = false;
                audioSource.PlayOneShot(clip2);
                clip2IsPlaying = true;
            }
            else if (clip2IsPlaying)
            {
                audioSource.Stop();
                clip2IsPlaying = false;
                audioSource.PlayOneShot(clip3);
                clip3IsPlaying = true;
            }
            else if (clip3IsPlaying)
            {
                audioSource.Stop();
                clip3IsPlaying = false;
                audioSource.PlayOneShot(clip1);
                clip1IsPlaying = true;
            }
        }
    }
}
