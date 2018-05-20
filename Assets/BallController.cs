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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突相手から「ぶつかったら壊れるブロック」の取得を試みる
        TargetBlockController target = collision.gameObject.GetComponent<TargetBlockController>();
        if (target != null) // 衝突相手が「ぶつかったら壊れるブロック」なら target にはコンポーネントが取得できる。そうでない場合は null になる
        {
            m_score += target.m_score;
            m_scoreText.text = m_score.ToString();
        }

        // ボールが水平に飛ぶようになってしまったら調整する（強引）
        if (Vector2.Angle(Vector2.right, m_rb2d.velocity) < 20f)
        {
            m_rb2d.AddForce(Vector2.up * (m_rb2d.velocity.y >= 0 ? 1 : -1) * 15);
        }
    }

    /// <summary>元々 Start() にあった内容はここに移動する。</summary>
    public void Reset()
    {
        m_rb2d = GetComponent<Rigidbody2D>();   // RigidBody を取得する
        m_rb2d.velocity = Vector2.zero;     // 一旦速度をリセットする。ゲームオーバーから再開した時のため
        m_rb2d.AddForce(m_power * m_powerScale);    // 力を加えてボールを動かす
        GameObject go = GameObject.Find("ScoreText"); // ScoreText という名前のオブジェクトを探してとっておく
        m_scoreText = go.GetComponent<Text>();  // ScoreText という名前のオブジェクトから Text を取り出す
        m_score = 0;    // スコアをリセットする
        m_scoreText.text = m_score.ToString();  // ToString() を使って整数を文字列に変換する
    }
}
