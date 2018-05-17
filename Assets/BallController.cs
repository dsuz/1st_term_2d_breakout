using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI を制御するのに必要です

public class BallController : MonoBehaviour
{
    /// <summary>点数を管理する</summary>
    int m_score = 0;
    /// <summary>得点を表示する</summary>
    Text m_scoreText;
    [SerializeField] Vector2 m_power;
    [SerializeField] float m_powerScale;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        m_rb2d.AddForce(m_power * m_powerScale);
        GameObject go = GameObject.Find("ScoreText"); // ScoreText という名前のオブジェクトを探してとっておく
        m_scoreText = go.GetComponent<Text>();  // ScoreText という名前のオブジェクトから Text を取り出す
        m_scoreText.text = m_score.ToString();  // ToString() を使って整数を文字列に変換する
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TargetBlockController target = collision.gameObject.GetComponent<TargetBlockController>();  // 衝突相手がら「ぶつかったら壊れるブロック」の取得を試みる
        if (target != null) // 衝突相手が「ぶつかったら壊れるブロック」だったら target にはコンポーネントが取得できる。そうでない場合は null になる
        {
            m_score += target.m_score;
            m_scoreText.text = m_score.ToString();
        }
    }
}
