using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class navegacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaAR()
    {
        SceneManager.LoadScene("RealidadAumentada");
      
    }
      public void EscenaMenu()
    {
        SceneManager.LoadScene("menu");
      
    }
    public void Preguntas()
    {
        SceneManager.LoadScene("Preguntas");

    }
    public void EscenaTemas(){
        SceneManager.LoadScene("temas");
    }
}
