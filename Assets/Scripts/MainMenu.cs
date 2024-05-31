using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public Button startButton;
  public Button exitButton;

  string sceneName = "MainScene";

  void Start()
  {
    startButton = GameObject.FindWithTag("StartButton").GetComponent<Button>();
    exitButton = GameObject.FindWithTag("ExitButton").GetComponent<Button>();

    startButton.onClick.AddListener(() =>
    {
      StartGame();
    });

    exitButton.onClick.AddListener(() =>
    {
      ExitGame();
    });

  }

  public void ExitGame()
  {
    Application.Quit();
    Debug.Log("Game Closed");
  }

  public void StartGame()
  {
    SceneManager.LoadScene(sceneName);
  }
}
