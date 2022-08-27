using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private AudioSource audioSrc;
    private FirstPersonController fpc;
    bool isMoving = false;
    
    void Start () {
        fpc = GetComponent<FirstPersonController> ();
        audioSrc = GetComponent<AudioSource> ();
    }
    
    void Update () {

        if (fpc.getCurrentSpeed() != 0 && fpc.Grounded)
            isMoving = true;
        else
            isMoving = false;

        
        
        if (isMoving) {
            audioSrc.volume = fpc.getCurrentSpeed() / fpc.SprintSpeed * 0.33f;
            if (!audioSrc.isPlaying)
            {
                StopAllCoroutines();
                audioSrc.Play();
            }

        }
        else
        {
            StartCoroutine(StartFade(audioSrc, 0.25f, 0.05f));
        }

    }
    
    
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }
}
