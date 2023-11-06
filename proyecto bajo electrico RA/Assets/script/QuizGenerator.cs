using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Question
{
    public string QuestionSprite;
    public string Answer1Sprite;
    public string Answer2Sprite;
    public string Answer3Sprite;
    public int CorrectAnswer;
    public string Theme;



}

public class QuizGenerator : MonoBehaviour
{
    public Question CurrentQuestion;
    public Question[] Questions;
    public Text QuestionImage;
    public Text Answer1Image;
    public Text Answer2Image;
    public Text Answer3Image;

    public GameObject CorrecAnswerBG1;
    public GameObject CorrecAnswerBG2;
    public GameObject CorrecAnswerBG3;

    public int QuestionCounter;

    //desplazar con las preguntas
    public GameObject Car;
    public GameObject[] SliderPoints;
    public float CarSpeed;

    //tiempo por pregunta
    public Text CounterText;
    public float Counter;
    private float _counter;
    // pantalla despues de las preguntas
    public GameObject FinishScreen;

    // para el puntaje 
    public int CorrectAnswer;
    public Image FinalPrice;
    public Image CorrectAnswerText;
    public Sprite[] Prices;
    public Sprite[] NumAnswers;


    void Start()
    {
        _counter = Counter;
        GenerateQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        // pasar a resultado de preguntas
        if(QuestionCounter == 5)
        {
            ShowFinalScreen();
            return;
        }
        // tiempo por pregunta
        Counter -= Time.deltaTime;
        CounterText.text = Mathf.Floor(Counter).ToString();
        if(Counter <=0)
        {
            Counter = _counter; 
           CompareAnswer();
        }
        // desplazamiento del foco segun numero de pregunta
        if(SliderPoints[QuestionCounter] != null)
        {
            Car.transform.position = Vector3.Lerp(Car.transform.position, SliderPoints[QuestionCounter].transform.position,CarSpeed* Time.deltaTime);
        }
        
    }

    public void RestarGame()
    {
        QuestionCounter = 0;
        Counter = _counter;
    }

    void ShowFinalScreen()
    {
        
        FinalPrice.sprite= Prices[CorrectAnswer];
        CorrectAnswerText.sprite = NumAnswers[CorrectAnswer];

        FinishScreen.SetActive(true);
        gameObject.SetActive(false); 
        return;
    }
    // lista para no repetir preguntas
    List<Question> usedQuestions = new List<Question>();

    public void GenerateQuiz()
    {
        Counter = _counter;

        CorrecAnswerBG1.SetActive(false);
        CorrecAnswerBG2.SetActive(false);
        CorrecAnswerBG3.SetActive(false);

        //int index = Random.Range(0, Questions.Length);
        int index;
        do
        {
            index = Random.Range(0, Questions.Length);
            CurrentQuestion = Questions[index];
        }
        while (usedQuestions.Contains(CurrentQuestion));

        usedQuestions.Add(CurrentQuestion);

        CurrentQuestion = Questions[index];
        QuestionImage.text = CurrentQuestion.QuestionSprite;
        Answer1Image.text = CurrentQuestion.Answer1Sprite;
        Answer2Image.text = CurrentQuestion.Answer2Sprite;
        Answer3Image.text =  CurrentQuestion.Answer3Sprite;

    }


    public void CompareAnswer(int UserAnswer = 0)
    {
    if (UserAnswer == CurrentQuestion.CorrectAnswer)
    {
        CorrectAnswer++;
         Debug.Log("Correcto");
    }
    else
    {
        Debug.Log("Incorrecto");
    }

    StartCoroutine(ShowAnswer());
    }

    IEnumerator ShowAnswer()
    {
        if(CurrentQuestion.CorrectAnswer == 1)
        {
            CorrecAnswerBG1.SetActive(true);

        }else if(CurrentQuestion.CorrectAnswer == 2)
        {
            CorrecAnswerBG2.SetActive(true);

        } else if(CurrentQuestion.CorrectAnswer == 3)
        {
            CorrecAnswerBG3.SetActive(true);

        }
        yield return new WaitForSeconds(2);
        QuestionCounter++;
        GenerateQuiz();

       
    }
}
