using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Menu : MonoBehaviour
{
    public GameObject PlayerCamera;

    public src_GameManager scriptGameManager;

    void Start()
    {
        scriptGameManager = FindObjectOfType<src_GameManager>();
    }
    
    public void PlayEasy()
    {
        // Lógica para iniciar o jogo
        scriptGameManager.Play(150);
    }

    public void PlayMedium()
    {
        // Lógica para iniciar o jogo
        scriptGameManager.Play(100);
    }

    public void PlayDificult()
    {
        // Lógica para iniciar o jogo
        scriptGameManager.Play(60);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
