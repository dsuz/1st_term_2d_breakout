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
        // パーティクルを再生してオブジェクトを破棄する
        Destroy(this.gameObject, 1.0f); // 一秒たったらオブジェクトを破棄する
        GetComponent<ParticleSystem>().Play();  // パーティクルを再生する
        GetComponent<Collider2D>().enabled = false; // 当たり判定を消す
        GetComponent<Renderer>().enabled = false;   // オブジェクトを見えなくする
    }
}
