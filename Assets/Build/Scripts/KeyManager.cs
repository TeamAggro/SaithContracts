using UnityEngine;
using System.Collections;
using System;
using Aggro.Command;


public class KeyManager : MonoBehaviour  
{

    // Use this for initialization
    InputManager input = new InputManager();
    Player player = new Player();

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
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Left", blank);
        input.AddControl("Right", blank);
        input.AddControl("Start", blank);
        input.AddControl("Select", blank);
    }
    void Map()
    {
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Left", blank);
        input.AddControl("Right", blank);
        input.AddControl("Start", blank);
        input.AddControl("Select", blank);
    }
    void Battle()
    {
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
        input.ResetControls();
        input.AddControl("Up", blank);
        input.AddControl("Down", blank);
        input.AddControl("Right", player.Right);
        input.AddControl("Left", player.Left);
        input.AddControl("L_SHIFT", player.Ability);
        input.AddControl("W", blank);
        input.AddControl("A", blank);
        input.AddControl("S", blank);
        input.AddControl("D", blank);
    }

    #endregion KeyBindingGroups

    void blank() { }
}

