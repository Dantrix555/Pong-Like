using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _upMirror;
    [SerializeField]
    private GameObject _downMirror;
    [SerializeField]
    private GameObject _leftMirror;
    [SerializeField]
    private GameObject _rightMirror;
    private float _number;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _upMirror.transform.position = new Vector3(Mathf.Clamp(RandomNumberX(), -5, 5), _upMirror.transform.position.y, _upMirror.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _downMirror.transform.position = new Vector3(Mathf.Clamp(RandomNumberX(), -5, 5), _downMirror.transform.position.y, _downMirror.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _leftMirror.transform.position = new Vector3(_leftMirror.transform.position.x, Mathf.Clamp(RandomNumberY(), -2.5f, 2.5f), _leftMirror.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rightMirror.transform.position = new Vector3(_rightMirror.transform.position.x, Mathf.Clamp(RandomNumberY(), -2.5f, 2.5f), _rightMirror.transform.position.z);
        }
    }

    float RandomNumberX()
    {
        _number = Random.Range(-5,5);
        if (_number == 0)
        {
            _number = 1;
        }
        return _number;
    }

    float RandomNumberY()
    {
        _number = Random.Range(-1,1);
        if (_number == 0)
        {
            _number = 1;
        }
        return _number;
    }
}
