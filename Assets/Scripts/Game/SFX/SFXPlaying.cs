using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource _flap;
    public AudioSource _poof;

    public void PlayFlap()
    {
        _flap.Play();
    }

    public void PlayPoof()
    {
        _poof.Play();
    }
}
