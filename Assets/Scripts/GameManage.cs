using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public Button restartbutton;
    public TextMeshProUGUI gameOverText;
    public static GameManage instance;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreTexts;
    public bool isGameActive { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore ( int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTexts.text = "Score: " + score;
    }
    
        
    
    IEnumerator SpawnTarget() {
        while (isGameActive)
        {     
            yield return new WaitForSeconds(spawnRate);
            //spawn a target
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }


    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        restartbutton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    

} 
