using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnInteraction : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;

    
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}
