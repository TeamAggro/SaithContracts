using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{

    public delegate void MenuScreenAction();
    public static event MenuScreenAction OnMenuScreen;
    // Change to menu screens
    public static void MenuScreen()
    {
        if (OnMenuScreen != null)
        {
            OnMenuScreen();
            Debug.Log("on Menu Screen");
        }
    }

    public delegate void MapScreenAction();
    public static event MapScreenAction OnMapScreen;
    // Change to Map Screens
    public static void MapScreen()
    {
        if (OnMapScreen != null)
        {
            OnMapScreen();
            Debug.Log("on Map Screen");
        }
    }

    public delegate void PlatformScreenAction();
    public static event PlatformScreenAction OnPlatformScreen;
    // change to Game screen
    public static void PlatformScreen() {
        if (OnPlatformScreen != null) {
            OnPlatformScreen();
            Debug.Log("on Game Screen");
        }
    }

    public delegate void BattleScreenAction();
    public static event BattleScreenAction OnBattleScreen;
    // change to battle screen
    public static void BattleScreen()
    {
        if (OnBattleScreen != null)
        {
            OnBattleScreen();
        }
    }

    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;
    // change to Gameover Screen
    public static void Gameover() {
        if (OnGameOver != null) {
            OnGameOver();
        }
    }

    public delegate void PauseGameAction();
    public static event PauseGameAction OnPauseGame;
    // Pause all objects that move
    public static void PauseGame() {
        if (OnPauseGame != null)
        {
            OnPauseGame();
        }
    }

}