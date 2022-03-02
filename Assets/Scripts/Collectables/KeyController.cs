using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private int _score;
    private PlayerController _playercontroller;
    void Awake()
    {
        _score = 10;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playercontroller = collision.gameObject.GetComponent<PlayerController>();
        if (_playercontroller != null)
        {
            _playercontroller.pickUpKey(_score);
            Destroy(this.gameObject);
        }
    }
}
