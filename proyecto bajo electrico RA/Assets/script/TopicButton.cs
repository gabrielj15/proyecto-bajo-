using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicButton : MonoBehaviour
{
    public string topic;

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Preguntas");
        PlayerPrefs.SetString("SelectedTopic", topic);
    }
}
