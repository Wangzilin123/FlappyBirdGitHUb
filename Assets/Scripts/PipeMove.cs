using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public Transform transformPipe;
    void Start()
    {
       Init();
    }

    float t = 0;

    public void Init()
    {
        float y = Random.Range(-1.5f, 2);
        this.transform.localPosition =Vector3.zero+new Vector3(0,y,0);
    }
    void Update()
    {
        this.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if (t >6f)
        {
            t = 0;
            Init();
        }
    }
}
