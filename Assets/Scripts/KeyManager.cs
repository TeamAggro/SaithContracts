using UnityEngine;
using System.Collections;
using System;
using Aggro.Command;


public class KeyManager : MonoBehaviour
{

    // Use this for initialization
    enum Scenetype { menu, game, map, battle };

    Scenetype scene;
    InputManager input = new InputManager();
    Player player = new Player();
    private bool _facingRight = true;

    #region Events
    void OnEnable()
    {
        GameEvents.OnMenuScreen += Menu;
        GameEvents.OnMapScreen += Map;
        GameEvents.OnPlatformScreen += Game;
        GameEvents.OnBattleScreen += Battle;
    }
    void OnDisable()
    {
        GameEvents.OnMenuScreen -= Menu;
        GameEvents.OnMapScreen -= Map;
        GameEvents.OnPlatformScreen -= Game;
        GameEvents.OnBattleScreen -= Battle;
    }
    #endregion Events

    #region KeyBindingGroups
    void Menu()
    {
        scene = Scenetype.menu;
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Yes", blank);
        input.AddControl("No", blank);
        input.AddControl("Start", blank);
        input.AddControl("Select", blank);
    }
    void Map()
    {
        scene = Scenetype.map;
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Yes", blank);
        input.AddControl("No", blank);
    }
    void Battle()
    {
        scene = Scenetype.battle;
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Left", blank);
        input.AddControl("Right", blank);
        input.AddControl("W", blank);
        input.AddControl("A", blank);
        input.AddControl("S", blank);
        input.AddControl("D", blank);
        input.AddControl("Start", blank);
        input.AddControl("Select", blank);
    }
    void Game()
    {
        scene = Scenetype.game;
        input.ResetControls();
        input.AddControl("Move", player.Move);
        input.AddControl("Run", player.Run);
    }

    #endregion KeyBindingGroups

    void Update()
    {
        if (scene == Scenetype.game)
        {
            if (Input.GetAxis("HORIZONTAL") != 0)
            {
                if (Input.GetAxis("HORIZONTAL") > 0 && _facingRight) flip();
                else if (Input.GetAxis("HORIZONTAL") < 0 && !_facingRight) flip();
                if (Input.GetButton("L_SHIFT")) input.ExecuteCommand("Run");
                input.ExecuteCommand("Move");
            }
            if (Input.GetButton("T")) input.ExecuteCommand("test");
        }
        if (scene == Scenetype.map)
        {

        }
        if (scene == Scenetype.menu)
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("change to Game Screen");
            GameEvents.PlatformScreen();
        }
    }

    void blank() { }
    void flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}

