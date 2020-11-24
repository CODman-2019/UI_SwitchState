using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager control = null;

    public GameObject TitleUI;
    public GameObject OptionsUI;
    public GameObject GameplayUI;
    public GameObject PauseUI;
    public GameObject GameOverUI;

    public GameObject player; 

    //addin map, inventory, stats
    public enum GameState { TitleScreen, Options, Gameplay, PauseMenu, GameOver};
    
    private GameState currentState;
    private GameState lastState;

    private void Awake()
    {
        if (control == null) control = this;
        else Destroy(this);
    }

 

    private void Update()
    {
        switch (currentState)
        {
            case GameState.TitleScreen:
                TitleUI.SetActive(true);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);

                player.SetActive(false);

                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //    currentState = GameState.Gameplay;
                //}
                break;

            case GameState.Options:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(true);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);

                player.SetActive(false);

                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //    currentState = GameState.TitleScreen;
                //}
                break;

            case GameState.Gameplay:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(true);
                GameOverUI.SetActive(false);

                player.SetActive(true);

                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //    currentState = GameState.PauseMenu;
                //}
                break;

            case GameState.PauseMenu:
                TitleUI.SetActive(false);
                PauseUI.SetActive(true);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);

                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //    currentState = GameState.Options;
                //}
                break;

            case GameState.GameOver:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(true);

                player.SetActive(false);

                break;
        }
    }

    public void OnGamePlay()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.Gameplay;
    }

    public void OnDeath()
    {
        Time.timeScale = 0f;
        lastState = currentState;
        currentState = GameState.GameOver;
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        lastState = currentState;
        currentState = GameState.PauseMenu;
    }

    public void OpenOptions()
    {
        Time.timeScale = 0f;
        lastState = currentState;
        currentState = GameState.Options;
    }

    public void ExitOptions()
    {
        currentState = lastState;
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.Gameplay;
    }

    public void ReturnToTitleScreen()
    {
        Time.timeScale = 0f;
        lastState = currentState;
        currentState = GameState.TitleScreen;
    }

    public void ExitAppllication()
    {
        Application.Quit();
    }
}
