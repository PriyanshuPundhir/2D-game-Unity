using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplaycontroller : MonoBehaviour
{
    public static Gameplaycontroller instance;

    public Boxspawner box_Spawner;
    [HideInInspector]
    public Boxscript currentBox;
    public Camerafollow cameraScript;
    private int moveCount;
     void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();

    }
        void DetectInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentBox.Dropbox(); 
            }
        }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 1f);
    }
    void NewBox()
    {
        box_Spawner.SpawnBox();
    }
    public void MoveCamera()
    {
        moveCount++;
        if(moveCount==3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
