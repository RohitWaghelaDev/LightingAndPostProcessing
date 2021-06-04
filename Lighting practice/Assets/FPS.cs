using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour
{

    Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        fpsText = GetComponent<Text>();
        StartCoroutine(PrintFPS());
    }

    IEnumerator PrintFPS()
    {


        while (true)
        {
            float fps = 1 / Time.deltaTime;
            fpsText.text = Mathf.FloorToInt(fps).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
