using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockController : MonoBehaviour
{
    public int m_score = 200;   // このブロックが壊れた時にこのスコアが入る。public なので Inspector から設定できる。

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
