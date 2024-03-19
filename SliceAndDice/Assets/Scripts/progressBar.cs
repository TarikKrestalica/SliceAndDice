using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class progressBar : MonoBehaviour
{
   
    private Slider slider;
    /*public health_bar_script health;*/
    
    
    public float fillspeed = 0.1f;
    public static int slider_count = 0;
    /*private float maxhealth = 100f*/
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
  

    // Update is called once per frame
    void Update()
    {
        if (slider.value < 1f && Input.GetKeyDown(KeyCode.Space))
        {
            slider.value += fillspeed * Time.deltaTime;
        }

      
        if (slider.value == slider.maxValue)
        {
            slider_count = 1;
            SceneManager.LoadScene(6);
           
            
        }

       
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(5);
    }

    

   

    
}
