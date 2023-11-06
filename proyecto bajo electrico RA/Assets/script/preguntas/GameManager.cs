using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_correctsound = null;
    [SerializeField] private AudioClip m_incorectsound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrecttColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;


    private db_quiz m_db_Quiz = null;
    private quizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_db_Quiz = GameObject.FindObjectOfType<db_quiz>();
        m_quizUI = GameObject.FindObjectOfType<quizUI>();
        m_audioSource = GetComponent<AudioSource>();
    }
    private void nextquestion()
    {
        m_quizUI.Construtc(m_db_Quiz.GetRandom(),GiveAnswer);
    }
    private void GiveAnswer(optionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }
    private IEnumerator GiveAnswerRoutine(optionButton optionButton)
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();
        m_audioSource.clip = optionButton.Opcion.correct ? m_correctsound : m_incorectsound;
        optionButton.SetColor(optionButton.Opcion.correct ? m_correctColor : m_incorrecttColor);
        m_audioSource.Play();
        yield return new WaitForSeconds(m_waitTime);
        nextquestion();
    }
}
