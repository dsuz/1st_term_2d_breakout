using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ゲーム全体を制御する</summary>
public class GameController : MonoBehaviour
{
    /// <summary>ゲーム中かどうかを判定するフラグ</summary>
    bool m_isInGame = false;
    /// <summary>ボール</summary>
    BallController m_ball;
    /// <summary>ボールの初期位置</summary>
    Vector2 m_initialPositionOfBall;
    /// <summary>メッセージを表示する Text</summary>
    Text m_console;
    /// <summary>ボールの y 座標がこれより小さくなったらゲームオーバー</summary>
    float m_bottomBorder = -10f;

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (m_isInGame) // 今ゲーム中の場合は
        {
            if (m_ball.transform.position.y < m_bottomBorder)   // ボールの場所を確認してあまりにも下だったらゲームオーバー
            {
                EndGame();
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Return)) // ゲーム中でない時に Enter が押されたらゲームを開始する
            {
                StartGame();
            }
        }
    }

    /// <summary>初期化する</summary>
    void InitializeGame()
    {
        GameObject ballObject = GameObject.Find("red_ball");    // ボールのオブジェクトを取得する
        m_initialPositionOfBall = ballObject.transform.position;    // ボールの初期位置を保存しておく
        m_ball = ballObject.GetComponent<BallController>();     // ボールから BallController を取り出しておく
        GameObject consoleObject = GameObject.Find("ConsoleText");  // メッセージを表示する Text を取得する
        m_console = consoleObject.GetComponent<Text>();
        m_console.text = "Hit Enter To Start";  // メッセージを設定する
    }

    /// <summary>ゲームを開始する</summary>
    void StartGame()
    {
        m_ball.transform.position = m_initialPositionOfBall;    // ボールを初期位置に移動する
        m_ball.Reset(); // ゲーム開始
        m_isInGame = true;  // フラグを立てる
        m_console.text = "";    // メッセージを消す
    }

    /// <summary>ゲームオーバーにする</summary>
    void EndGame()
    {
        m_isInGame = false; // フラグをゲーム中ではない状態にする
        m_console.text = "Game Over\r\nHit Enter To Restart";   // メッセージを表示する
    }
}
