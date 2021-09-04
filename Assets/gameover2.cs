using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover2 : MonoBehaviour
{
    // Start is called before the first frame update
    private static int i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if(i==1)
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        i++;
    }
}
