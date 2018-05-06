using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] m_targetPrefabArray;
    [SerializeField] Vector2 m_startGeneratePostion;
    [SerializeField] int m_columns = 7;
    [SerializeField] int m_rows = 6;

    void Start()
    {
        Vector2 pos = m_startGeneratePostion;
        float blockHeight = 0f, blockWidth = 0f;
        for (int j = 0; j < m_rows; j++)
        {
            for (int i = 0; i < m_columns; i++)
            {
                int prefabIndex = j % m_targetPrefabArray.Length;
                GameObject go = Instantiate(m_targetPrefabArray[prefabIndex], this.gameObject.transform);
                go.transform.position = pos;
                blockWidth = go.GetComponent<SpriteRenderer>().bounds.size.x;
                blockHeight = go.GetComponent<SpriteRenderer>().bounds.size.y;
                pos = pos + new Vector2(blockWidth, 0);
            }
            pos = new Vector2(m_startGeneratePostion.x, pos.y - blockHeight);
        }
    }

    void Update()
    {

    }
}
