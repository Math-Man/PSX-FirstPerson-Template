using System;
using System.Collections;
using System.Collections.Generic;
using PSX;
using UnityEngine;

public class FogAwaken : MonoBehaviour
{
    private FogController fog;
    private void Awake()
    {
        fog = GetComponent<FogController>();
        StartCoroutine(FadeOutFog(fog, 2f, 1500f, 60f));
    }
    
    
    public static IEnumerator FadeOutFog(FogController fogController, float duration, float start, float target)
    {
        float currentTime = 0;
        fogController.setFogDistance(start);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            fogController.setFogDistance(Mathf.Lerp(start, target, currentTime / duration));
            yield return null;
        }
        yield break;
    }
}
