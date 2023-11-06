using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class db_quiz : MonoBehaviour
{
    [SerializeField] private List<question> m_questionList = null;

    private List<question> m_backup = null;
    private void Awake()
    {
        m_backup = m_questionList;
    }

    public question GetRandom(bool remove = true )
    {
        if (m_questionList.Count == 0)
            RestoreBackup();
        int index = Random.Range(0, m_questionList.Count);
        if (!remove)
            return m_questionList[index];
        question q = m_questionList[index];
        m_questionList.RemoveAt(index);
        return q;
    }
    private void RestoreBackup()
    {
        m_questionList = m_backup;
    }
}
