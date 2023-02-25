using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogueSO : ScriptableObject
{
    [TextArea(3,5)] public string Text;
}
