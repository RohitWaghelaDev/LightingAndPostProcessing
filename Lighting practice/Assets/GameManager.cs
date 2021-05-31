using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject PostProcessorVolume;
    public Text FpsText;
    private bool showingposetProcessor = true;

    private bool showingFps=false;
    private void Start()
    {

        if (FpsText!= null)
        {
            FpsText.gameObject.SetActive(false);

        }
    }

    public void LoadScene(int index) 
    {
        Debug.Log("clicked post loadScene");
        SceneManager.LoadScene(index);
    }



    public void SetPostProcessor() 
    {

        Debug.Log("clicked post processor");
        if (!showingposetProcessor)
        {
            showingposetProcessor = true;
            PostProcessorVolume.SetActive(true);
        }
        else
        {
            showingposetProcessor = false;
            PostProcessorVolume.SetActive(false);
        }
    
    }


    public void SetFPS() 
    {
        Debug.Log("clicked post FPS");
        if (!showingFps)
        {
            showingFps = true;
            FpsText.gameObject.SetActive(true);
            StartCoroutine("ShowFps");

        }
        else
        {
            showingFps = false;
            StopCoroutine("ShowFps");
            FpsText.gameObject.SetActive(false);
           
        }
    
    }


    private  IEnumerator  ShowFps()
    {

        while (true)
        {
            float fps = 1 / Time.deltaTime;
            FpsText.text = Mathf.FloorToInt(fps).ToString();
            yield return new WaitForSeconds(1);
        }
    
    }
}
