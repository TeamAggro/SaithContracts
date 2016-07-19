using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private static Animator _animator;
    private static Rigidbody2D _rigidbody2D;
    private static float _mspd { get; set; }

    #region Game Controls
    public void Move()
    {
        _mspd = 10f;
        float move = Input.GetAxis("HORIZONTAL");
        _rigidbody2D.velocity = new Vector2(move * _mspd, _rigidbody2D.velocity.y);
    }

    public void Run()
    {
        _mspd = 20f;
    }


    public void Confirm()
    {

    }
    public void Deny()
    {

    }

    #endregion Game Controls

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(transform.localScale);
    }
    void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("HORIZONTAL")));
    }
}