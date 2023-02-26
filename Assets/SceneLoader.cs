using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame(){
        UnityEngine.SceneManagement.SceneManger.LoadScene(SceneManger.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame(){
        Application.Quit();
    }
 
}
