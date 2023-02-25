using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _cam.SetActive(true);
            col.gameObject.SetActive(false);
            StartCoroutine(Load());
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ChestScene");
    }
}
