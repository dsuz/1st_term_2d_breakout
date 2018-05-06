using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Vector2 m_power;
    [SerializeField] float m_powerScale;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        m_rb2d.AddForce(m_power * m_powerScale);
    }

    void Update()
    {

    }
}
