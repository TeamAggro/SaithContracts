using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Animator _animator;
    public Transform _transform;
    public Rigidbody2D _rigidbody2D;

    private InputManager input = new InputManager();

    private bool _facingRight = true;
    private bool _grounded = true;
    public  static float baseSpeed = 20f;
    public  static float jumpHeight = 30f;
    private float modifier = 1.75f;
    private float speed = baseSpeed;

    enum Scenetype { menu, game, map, battle };
    static Scenetype scene;
    enum Character { a, b, c, d, e, f, g, h, i, j, k, l, m, n};
    static Character _character;


    #region Characters
    void CurrentCharacter (Character character)
    {

    }
    #endregion Characters

    #region Game Controls
    public void Right()
    {
        if (_facingRight) { flip(); }
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }
    public void Left()
    {
        if (!_facingRight) { flip(); }
        _rigidbody2D.velocity = new Vector2(-speed, _rigidbody2D.velocity.y);
    }
    public void flip()
    {
        _facingRight = !_facingRight;
        _transform.localScale = new Vector3(_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
    }
    public void Jump()
    {
        if(_grounded)
        {
            Debug.Log("Jump Button was Pressed");
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpHeight);
            _grounded = false;
        }
    }

    public void AbilityOn()
    {
        speed = baseSpeed * modifier;
        _animator.SetBool("Ability", true);
    }
    public void AbilityOff()
    {
        speed = baseSpeed;
        _animator.SetBool("Ability", false);
    }

    #endregion Game Controls

    #region Events
    void OnEnable() {
        GameEvents.OnMenuScreen += Menu;
        GameEvents.OnMapScreen += Map;
        GameEvents.OnPlatformScreen += Game;
        GameEvents.OnBattleScreen += Battle;
    }
    void OnDisable() {
        GameEvents.OnMenuScreen -= Menu;
        GameEvents.OnMapScreen -= Map;
        GameEvents.OnPlatformScreen -= Game;
        GameEvents.OnBattleScreen -= Battle;
    }

    void Game() {
        scene = Scenetype.game;
    }
    void Menu() {
        scene = Scenetype.menu;
    }
    void Map() {
        scene = Scenetype.map;
    }
    void Battle() {
        scene = Scenetype.battle;
    }

    #endregion Events

    void OnCollisionEnter2D(Collision2D obj) {
        if (obj.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetButtonDown("A"))
            GameEvents.PlatformScreen();

        if(scene == Scenetype.game)
        {
            _animator.SetBool("Grounded", _grounded);
            _animator.SetFloat("Speed", speed);
            _animator.SetFloat("velocityX", Mathf.Abs(_rigidbody2D.velocity.x));
            _animator.SetFloat("velocityY",_rigidbody2D.velocity.y);

            if (_rigidbody2D.velocity.y > 0)
            {
                _animator.SetBool("Jumping", true);
            }
            else if (_rigidbody2D.velocity.y <= 0)
            {
                _animator.SetBool("Jumping", false);
            }
            if (Input.GetAxis("HORIZONTAL") > 0 || Input.GetAxis("HORIZONTAL_KEYBOARD") > 0)
            {
                input.ExecuteCommand("Right");
                Debug.Log("Right");
            }
            if (Input.GetAxis("HORIZONTAL") < 0 || Input.GetAxis("HORIZONTAL_KEYBOARD") < 0)
            {
                input.ExecuteCommand("Left");
                Debug.Log("Left");
            }
            if (Input.GetAxis("VERTICAL") < 0 || Input.GetAxis("VERTICAL_KEYBOARD") > 0 )
            {
                input.ExecuteCommand("Down");
                Debug.Log("Down");
            }
            if (Input.GetAxis("VERTICAL") > 0 || Input.GetAxis("VERTICAL_KEYBOARD") < 0) 
            {
                input.ExecuteCommand("Up");
                Debug.Log("Up");
            }
            if (Input.GetButtonDown("L_SHIFT"))
            {
                input.ExecuteCommand("L_SHIFT_On");
                Debug.Log("Left Shift Down");
            }
            if (Input.GetButtonUp("L_SHIFT"))
            {
                input.ExecuteCommand("L_SHIFT_Off");
                Debug.Log("Left Shift Up");
            }
            if (Input.GetButtonDown("ENTER"))
            {
                input.ExecuteCommand("ENTER");
                Debug.Log("Enter");
            }
        }
    }


}