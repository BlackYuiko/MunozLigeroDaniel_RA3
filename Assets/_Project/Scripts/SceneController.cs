using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private readonly string menuInicial = "MenuInicial";
    private readonly string levelOne = "LevelOne";
    private readonly string levelTwo = "LevelTwo";
    private readonly string levelThree = "LevelThree";
    private readonly string levelFour = "LevelFour";
    private readonly string menuMuerte = "MenuMuerte";
    private readonly string menuVictoria= "MenuVictoria";

    private static int lastLevelBuildIndex = -1;


    private void Awake()
    {
        Instance = this;
    }

    public void StartGame() 
        => SceneManager.LoadScene(menuInicial);
    public void LoadLevelOne() 
        => SceneManager.LoadScene(levelOne);
    public void LoadLevelTwo() 
        => SceneManager.LoadScene(levelTwo);
    public void LoadLevelThree() 
        => SceneManager.LoadScene(levelThree);
    public void LoadLevelFour() 
        => SceneManager.LoadScene(levelFour);

    public void LoadMenuDeath()
    {
        lastLevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(menuMuerte);
    }

    public void LoadMenuVictory() => 
        SceneManager.LoadScene(menuVictoria);
    public void ExitGame() => 
        Application.Quit();

    public void RestartScene() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void RestartLastScene()
    {
        if (lastLevelBuildIndex >= 0)
        {
            SceneManager.LoadScene(lastLevelBuildIndex);
        }
    }

    public void LoadNextScene() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    

}
