using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            B b = Utility.LoadScene<B>("Bscene");
            if (b == null)
            {
                Debug.Log("b is null");
                return;
            }
            b.PrintData();
        }
    }
}
