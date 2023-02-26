using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndTransition : MonoBehaviour
{
    public GameObject EndCam;
    public GameObject DisableLvl;

    [ContextMenu("TESTTTTTTTTTTTTTTTTTTTTTT")]
    public void StartEndTrans()
    {
        StartCoroutine(StartTrans());
    }
    
    private IEnumerator StartTrans()
    {
        EndCam.SetActive(true);
        yield return new WaitForSeconds(3f);
        DisableLvl.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
