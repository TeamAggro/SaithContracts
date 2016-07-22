using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private static Animator _animator;
    private static Rigidbody2D _rigidbody2D;
    private InputManager input = new InputManager();

    private bool _facingRight = true;
    private static float _mspd;

    private enum Scenetype { menu, game, map, battle };
    static Scenetype scene;
    private enum Character { a, b, c, d, e, f, g, h, i, j, k, l, m, n};
    static Character character;

    #region Game Controls
    public void Right()
    {
        _rigidbody2D.velocity = new Vector2(_mspd, _rigidbody2D.velocity.y);
    }
    public void Left()
    {
        _rigidbody2D.velocity = new Vector2(_mspd * -1, _rigidbody2D.velocity.y);
    }
    public void Idle() {
        _mspd = 0;
    }
    public void Run()
    {
        _mspd = 20f;
    }
    public void Walk()
    {
        _mspd = 10f;
    }
    public void flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    #endregion Game Controls

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        GameEvents.PlatformScreen();
    }
    void Update()
    {
        _animator.SetFloat("Speed", _mspd*Mathf.Abs(Input.GetAxis("HORIZONTAL")));
    }
    void FixedUpdate()
    {
        if (Input.GetAxis("HORIZONTAL") < 0)
        {
            if (!_facingRight) { flip(); }
            if (Input.GetButton("L_SHIFT"))
            {
                Run();
                input.ExecuteCommand("Left");
            }
            else
            {
                Walk();
                input.ExecuteCommand("Left");
            }
        }
        if (Input.GetAxis("HORIZONTAL") > 0)
        {
            if (_facingRight) { flip(); }
            if (Input.GetButton("L_SHIFT"))
            {
                Run();
                input.ExecuteCommand("Right");
            }
            else
            {
                Walk();
                input.ExecuteCommand("Right");
            }
        }
    }
}