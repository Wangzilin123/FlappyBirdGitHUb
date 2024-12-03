using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiepLineManager : MonoBehaviour
{
    public GameObject pipeTemplate;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    Coroutine coroutine = null;
    public void StartRun()
    {
        coroutine= StartCoroutine(GeneratePipeLines());
    }
    public void OnParticleSystemStopped()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator GeneratePipeLines()
    {
        while (true)
        {
            GeneratePipeLine();
            yield return new WaitForSeconds(2f);
        }
    }
    void GeneratePipeLine()
    {
        Instantiate(pipeTemplate, this.transform);
    }
}
