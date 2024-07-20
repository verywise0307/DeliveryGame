using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlaySceneChange : MonoBehaviour
{

    public void SceneChange()
    {
            SceneManager.LoadScene("HowToPlay_1");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
