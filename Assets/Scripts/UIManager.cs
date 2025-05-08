using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainmenuUI;
    public GameObject levelSelectionUI;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    public void StartLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level"+ levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowLevelSelect()
    {
        mainmenuUI.SetActive(false);
        levelSelectionUI.SetActive(true);
    }
    public void ReturntoMainMenu()
    {
        mainmenuUI.SetActive(true);
        levelSelectionUI.SetActive(false);
        SceneManager.LoadScene("MainMenuUI");
    }
    public void QuitGame()
    {
        Debug.Log("Exited Game");
        Application.Quit();
    }
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
    public void ReturnFromGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
