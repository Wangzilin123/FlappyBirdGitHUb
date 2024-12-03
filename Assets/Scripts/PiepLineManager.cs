using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiepLineManager : MonoBehaviour
{
    public GameObject pipeTemplate;

    List<PipeMove> pipeLines=new List<PipeMove> ();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    Coroutine coroutine = null;

    public void Init()
    {
        for (int i = 0; i < pipeLines.Count; i++)
        {
            Destroy(pipeLines[i].gameObject);
        }
        pipeLines.Clear ();
    }
    public void StartRun()
    {
        coroutine= StartCoroutine(GeneratePipeLines());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipeLines.Count; i++)
        {
            pipeLines[i].enabled = false;
        }
    }

    IEnumerator GeneratePipeLines()
    {
        for (int i = 0; i < 3; i++)
        {
            if (pipeLines.Count<3)
            {
                GeneratePipeLine();
                yield return new WaitForSeconds(2f);
            }
            else
            {
                pipeLines[i].enabled=true;
                pipeLines[i].Init();
            }
           
        }
    }
    void GeneratePipeLine()
    {
        if (pipeLines.Count<3)
        {
            GameObject obj = Instantiate(pipeTemplate, this.transform);
            PipeMove p = obj.GetComponent<PipeMove>();
            pipeLines.Add(p);
        }

    }
}
