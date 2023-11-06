using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<optionButton> m_buttonList = null;

    public void Construtc(question q , Action<optionButton> callback)
    {
        m_question.text = q.text;

        for(int n = 0; n < m_buttonList.Count; n++)
        {
            m_buttonList[n].construc(q.options[n], callback);
        }
    }
}
