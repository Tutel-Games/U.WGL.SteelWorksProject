using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _positions;
    private int _index = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_index > 0)
            {
                _index--;
                Move(_index);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_index < 2)
            {
                _index++;
                Move(_index);
            }
        }
    }

    private void Move(int index)
    {
        transform.position = _positions[index].position;
    }
}
