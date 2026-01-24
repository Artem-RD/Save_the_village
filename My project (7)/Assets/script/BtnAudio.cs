using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAudio : MonoBehaviour
{
    public AudioSource Clik;
    public AudioClip clik;
    public void ClikSound()
    {
        Clik.PlayOneShot(clik);
    }
}
