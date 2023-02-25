using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private List<GameObject> _offObjects;
    [SerializeField] private List<GameObject> _onObjects;

    [ContextMenu("TESTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT")]
    public void Open()
    {
        foreach (var obj in _offObjects)
        {
            obj.SetActive(false);
        }
        
        foreach (var obj in _onObjects)
        {
            obj.SetActive(true);
        }
    }
}
