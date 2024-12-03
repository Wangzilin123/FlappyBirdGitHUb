using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    void Start()
    {
        float y = Random.Range(-1.5f,2);
        this.transform.localPosition+=new Vector3(0,y,0);
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        this.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
    }
}
