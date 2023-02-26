using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _turnOff;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private BgScroller _bg;
    private int _score;
    
    public void AddScore()
    {
        _score++;
        _text.text = $"{_score}/10";
        if (_score == 10)
        {
            foreach (var obj in _turnOff)
            {
                obj.SetActive(false);
            }
            _bg.Stop();
        }
    }
}
