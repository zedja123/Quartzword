using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public GameObject cameraMenu;
    public AudioSource audioSource;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeMenu();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetSceneByName("Menu").name != SceneManager.GetActiveScene().name)
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
                Time.timeScale = 0;
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void InitializeMenu()
    {
        PlayAudio();
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        
    }

    public void LoadMainMenu()
    {
        InitializeMenu();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
        Destroy(cameraMenu);

    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        print("continue");
    }
    public void RestartButton()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadDeathMenu()
    {
        deathMenu.SetActive(true);
        //Time.timeScale = 0;
    }
    
    public void PlayAudio()
    {
        audioSource.Play();
    }


}
