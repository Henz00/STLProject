using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject SelectLevelMenuHolder;
    void Awake()
    {
        SelectLevelMenuHolder = GameObject.Find("SelectLevelMenuHolder");
    }

    void Start()
    {
        SelectLevelMenuHolder.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectLevelMenu()
    {
        SelectLevelMenuHolder.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
