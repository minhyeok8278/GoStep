using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject exitMenu;

    public void StageStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnOptionMenu()
    {
        optionMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitOptionMenu()
    {
        optionMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
