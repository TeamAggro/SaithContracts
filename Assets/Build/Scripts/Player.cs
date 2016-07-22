using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private static Animator _animator;
    private static Transform _transform;
    private InputManager input = new InputManager();

    private bool _facingRight = true;
    private static float speed = 10f;

    private enum Scenetype { menu, game, map, battle };
    static Scenetype scene;
    private enum Character { a, b, c, d, e, f, g, h, i, j, k, l, m, n};
    static Character character;

    #region Game Controls
    public void Right()
    {
        if (_facingRight) { flip(); }
        _transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    public void Left()
    {
        if (!_facingRight) { flip(); }
        _transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    public void AbilityOn()
    {
        speed = 20f;
        _animator.SetBool("Ability", true);
    }
    public void AbilityOff()
    {
        speed = 10f;
        _animator.SetBool("Ability", false);
    }
    public void flip()
    {
        _facingRight = !_facingRight;
        _transform.localScale = new Vector3(_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
    }

    #endregion Game Controls

    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>(); 
        GameEvents.PlatformScreen();
    }
    void Update()
    {
        _animator.SetFloat("Speed", speed * Mathf.Abs(Input.GetAxis("HORIZONTAL")));
        if (Input.GetAxis("HORIZONTAL") > 0)
        {
            input.ExecuteCommand("Right");
        }
        if (Input.GetAxis("HORIZONTAL") < 0)
        {
            input.ExecuteCommand("Left");
        }
        if (Input.GetAxis("VIRTICAL") < 0)
        {
            input.ExecuteCommand("Down");
        }
        if (Input.GetAxis("VIRTICAL") > 0)
        {
            input.ExecuteCommand("Up");
        }
        if (Input.GetButtonDown("L_SHIFT"))
        {
            input.ExecuteCommand("L_SHIFT_On");
        }
        if (Input.GetButtonUp("L_SHIFT"))
        {
            input.ExecuteCommand("L_SHIFT_Off");
        }
    }
}