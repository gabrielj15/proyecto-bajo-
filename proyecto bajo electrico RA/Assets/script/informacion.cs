using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informacion : MonoBehaviour
{

    string objectName;
      //List<GameObject> objectsInformation;

    [SerializeField]
    GameObject objectInformation;
    // Start is called before the first frame update
    void Start()
    {
        objectName = gameObject.name;
    }

    void Update(){
        

        if(Input.touchCount ==2){
            
            objectInformation.SetActive(false);  
        }
        if(Input.touchCount ==1){
            
            objectInformation.SetActive(true);  
        }
        

    }
}
