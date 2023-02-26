using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndTransition : MonoBehaviour
{
    public GameObject EndCam;
    public GameObject DisableLvl;
    public GameObject DisablePlayer;

    public void OnEnable()
    {
        StartCoroutine(StartTrans());
    }
    
    private IEnumerator StartTrans()
    {
        EndCam.SetActive(true);
        yield return new WaitForSeconds(3f);
        DisableLvl.SetActive(false);
        DisablePlayer.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
