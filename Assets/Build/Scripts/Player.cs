using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Animator _animator;
    public Transform _transform;
    public Rigidbody2D _rigidbody2D;

    private InputManager input = new InputManager();

    private bool _facingRight = true;
    private static float speed = 10f;

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
        _transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    public void Left()
    {
        if (!_facingRight) { flip(); }
        _transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    public void flip()
    {
        _facingRight = !_facingRight;
        _transform.localScale = new Vector3(_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
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

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        GameEvents.PlatformScreen();
    }
    void Update()
    {
        if(scene == Scenetype.game)
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


}