using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreTexts;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        
    }
    public void UpdateScore ( int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTexts.text = "Score: " + score;
    }
    
        
    
    IEnumerator SpawnTarget() {
        while (true)
        {     
            yield return new WaitForSeconds(spawnRate);
            //spawn a target
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }


    }
    

} 
