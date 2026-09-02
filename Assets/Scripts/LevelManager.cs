using UnityEngine;

/// <summary>
/// Handles level progression and scene transitions
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int totalLevels = 3;
    private bool levelComplete = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CompleteLevel()
    {
        levelComplete = true;
        
        if (currentLevel < totalLevels)
        {
            LoadNextLevel();
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void FailLevel()
    {
        // Reload current level
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    private void LoadNextLevel()
    {
        currentLevel++;
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Level{currentLevel}");
    }

    private void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public int GetCurrentLevel() => currentLevel;
    public bool IsLevelComplete() => levelComplete;
}
