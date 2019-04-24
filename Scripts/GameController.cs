using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float scrollSpeed;
    public float timeLeft = 30.0f;
    

    public float startWait;
    public float waveWait;

    public AudioClip Musicwin;
    public AudioClip MusicStandard;

    public Text scoreText;
    public Text winText;
    public Text restartText;
    public Text gameoverText;
    public Text hardmodeText;
    public Text timeText;
    public Text wowText;
    public Text megawowText;
    public Text magnawowText;
    public Text tributewowText;
    public Text dogwowText;
    public Text dogendText;
    public Text timeleftText;

    private bool gameOver;
    private bool win;
    private bool restart;
    private bool Hardmode;
    private bool TimeAttack;
    private bool megawow;
    private bool Wow;
    private bool MainAudio;
    private bool WinAudio;
    private bool Magnawow;
    private bool Tributewow;
    private bool Dogwow;
    private bool Dogend;
    public int score;

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        
        win = false;
        gameOver = false;
        restart = false;
        Hardmode = false;
        Wow = false;
        megawow = false;
        Magnawow = false;
        Tributewow = false;
        Dogwow = false;
        Dogend = false;
        
        
        winText.text = "";
        hardmodeText.text = "";
        restartText.text = "";
        gameoverText.text = "";
        timeText.text = "";
        wowText.text = "";
        megawowText.text = "";
        magnawowText.text = "";
        tributewowText.text = "";
        dogwowText.text = "";
        dogendText.text = "";
        
     
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        
    }
    
    

    private void Update()

    {


        if (score >= 100)
        {
            

        }

            timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            GameOver();
        }
        timeleftText.text = ("" + timeLeft);

        if (Hardmode)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("Scene2");
            }


        }
        if (TimeAttack)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene("Scene3");
            }

            

        }
        if (restart)
        {
            scrollSpeed = -6;

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Scene1");

            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
        

    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        
    }

    IEnumerator SpawnWaves()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)]; 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                hardmodeText.text = "Press H for Hardmode";
                restartText.text = "Press 'T' for Restart";
                timeText.text = "Press 'Y' for Time Attack";
                restart = true;
                TimeAttack = true;
                Hardmode = true; 
                break;
            }
        }
    }

    
        public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {


        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            wowText.text = "Great job keep it up!";
            winText.text = "You win! Game Created by Kellen Cosgrove";
            Wow = true;
            gameOver = true;
            win = true;
            restart = true;
            Hardmode = true;
            TimeAttack = true;

            GetComponent<AudioSource>().enabled = true;




            restartText.text = "Press 'T' for Restart";
            hardmodeText.text = "Press H for Hardmode";
            timeText.text = "Press 'Y' for Time Attack";




        }
        if (score >= 200)
        {
            megawowText.text = "You really are shooting for the stars!";

            megawow = true;
        }
        if (score >= 250)
        {
            magnawowText.text = "You know... I once also shot for the stars...";

            Magnawow = true;
        }
        if (score >= 300)
        {
            tributewowText.text = "on 4 small legs that pushed me towards the heavens..";

            Tributewow = true;
        }
        if (score >= 350)
        {
            dogwowText.text = "I was once rejected, then accepted and went to explore..";

            Dogwow = true;
        }
        if (score >= 400)
        {
            dogendText.text = "I observed and absorbed the beautiful sights until it hurt to much to continue.... I miss you Binky";

            Dogend = true;
        }
    }
    public void GameOver ()
    {
        gameoverText.text = "Game Over";
        gameOver = true;
        restart = true;
        Hardmode = true;
        TimeAttack = true;

    }
}
