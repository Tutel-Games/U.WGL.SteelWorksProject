using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameUI : MonoBehaviour
{
    public List<Button> _buttons;
    private int index;
    public void NextButton()
    {
        if (index == _buttons.Count) return;
        
        _buttons[index].interactable = true;
        index++;
    }
}
