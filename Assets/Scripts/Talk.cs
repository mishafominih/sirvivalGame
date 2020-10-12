using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public List<AudioClip> audios;
    bool start = false;
    public void StartTalk()
    {
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            var audioSource = GetComponent<AudioSource>();
            if (audios.Count > 0 && !audioSource.isPlaying)
            {
                var audio = audios[0];
                audios.RemoveAt(0);
                audioSource.PlayOneShot(audio);
            }
        }
    }
}
