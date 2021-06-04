using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Utility :MonoBehaviour
{
    public static  T LoadScene<T>(string SceneName) where T : Object
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        while (!asyncOperation.isDone)
        {
            Task.Delay(100);
        }

      
        
        T type = FindObjectOfType<T>();

       
        return type;
    }
}
