using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    private float _speedIncrement;
    private int _xRandom;
    private int _yRandom;
    private int _score;
    [SerializeField]
    private int _lives;
    private Rigidbody2D _rb2d;
    private Vector3 _start;
    private Vector3 _final;
    private Vector3 _direction;
    private float _angle;
    void Start ()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Pause());
    }
	
	void Update ()
    {
        if (_speedIncrement == 10f) _speedIncrement = 10f;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Boundary")
        {
            if(_lives > 0)
            {
                _lives--;
                transform.rotation = Quaternion.identity;
                StartCoroutine(Pause());
            }
            else
            {
                if (_score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", _score);
                    SceneManager.LoadScene("High-Score 1");
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.rotation = Quaternion.identity;
        _speedIncrement += 0.001f;
        if (other.gameObject.tag == "left")
        {
            if (_rb2d.velocity.x >= 10)
            {
                _rb2d.velocity = new Vector3(10, _rb2d.velocity.y, transform.position.z);
            }
            else
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x + _speedIncrement, _rb2d.velocity.y * 1.05f, transform.position.z);
            }
        }

        if(other.gameObject.tag == "right")
        {
            _angle = 180 - (other.transform.position.y - transform.position.y);
            if (_rb2d.velocity.x <= -10)
            {
                _rb2d.velocity = new Vector3(-10, _rb2d.velocity.y, transform.position.z);
            }
            else
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x - _speedIncrement, _rb2d.velocity.y * 1.05f, transform.position.z);
            }
        }
    
        if (other.gameObject.tag == "down")
        {
            _angle = other.transform.position.x - transform.position.x;
            if (_rb2d.velocity.y >= 10)
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x, 10, transform.position.z);
            }
            else
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x * 1.1f, _rb2d.velocity.y + _speedIncrement, transform.position.z);
            }
        }

        if(other.gameObject.tag == "up")
        {
            _angle = other.transform.position.x - transform.position.x;
            if (_rb2d.velocity.y <= -10)
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x, -10, transform.position.z);
            }
            else
            {
                _rb2d.velocity = new Vector3(_rb2d.velocity.x * 1.1f, _rb2d.velocity.y - _speedIncrement, transform.position.z);
            }
        }
        _final = _rb2d.velocity;
        _angle = Mathf.Abs(Vector3.Angle(_start, _final));
        if ((_rb2d.velocity.y > 0 && _rb2d.velocity.x > 0) || (_rb2d.velocity.y > 0 && _rb2d.velocity.x < 0))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, _angle);
        }
        if ((_rb2d.velocity.y < 0 && _rb2d.velocity.x > 0) || (_rb2d.velocity.y < 0 && _rb2d.velocity.x < 0))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, -_angle);
        }
        _score = Score(_score);
    }

    public void Launch()
    {
        transform.position = Vector3.zero;
        _xRandom = Random.Range(-2, 2);
        _yRandom = Random.Range(-2, 2);
        if (_xRandom == 0)
        {
            _xRandom = 1;
        }
        if (_yRandom == 0)
        {
            _yRandom = 1;
        }
        _speedIncrement = 1f;
        _direction = new Vector3(_xRandom, _yRandom, transform.position.z);
        _start = new Vector3(5, 0, 0);
        _final = _direction;
        _angle = Mathf.Abs(Vector3.Angle(_start, _final));
        if ((_yRandom > 0 && _xRandom > 0)||(_yRandom > 0 && _xRandom < 0))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, _angle);
        }
        if((_yRandom < 0 && _xRandom > 0)|| (_yRandom < 0 && _xRandom < 0))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, -_angle);
        }
        _rb2d.velocity = _direction;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);
        Launch();
    }

    int Score(int point)
    {
        point++;
        return point;
    }

}
