using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamOnAwake : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
