using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         
    public Text scoreText;                     
    public GameObject gameOvertext;            
    public GameObject highscoreText;
    public Text scoreOneText;
    public Text scoreTwoText;
    public Text scoreThreeText;

    public int score = 0;                      
    public bool gameOver = false;              

    public bool raised = false;
    public float scrollSpeed = -1.5f;
    public float spawnRate = 3f;

    //Itmes
    public bool faster = false;
    public int xF = 0;

    public bool slower = false;
    public int xS = 0;

    public bool multiplier = false;
    public int xM = 0;
    //Sound
    public AudioSource source; //items
    public AudioSource source2; // dead
    //highscore
    public int scoreOne;
    public int scoreTwo;
    int scoreThree;


    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {

        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (gameOver && Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            Destroy(InformationSave.instance);
        }
        getMultiplier();

    }

    public void UnicornScored()
    {
 
        if (gameOver)
            return;
 
        score++;
        if (multiplier)
        {
            score++;

        }
        //Item
        xM++;
        xF++;
        raised = false;

        scoreText.text = "Score: " + score.ToString();
    }

    public void UnicornDied()
    {
        saveScore();
        scoreOneText.text = "1: " + PlayerPrefs.GetInt("hScoreOne").ToString();
        scoreTwoText.text = "2: " + PlayerPrefs.GetInt("hScoreTwo").ToString();
        scoreThreeText.text = "3: " + PlayerPrefs.GetInt("hScoreThree").ToString();
        highscoreText.SetActive(true);

        gameOvertext.SetActive(true);
        source2.Play();

        gameOver = true;
    }

    public void scalingSpeed()
    {
        if (score % 5 == 0 && score != 0 && raised == false)
        {
            if (scrollSpeed > -6.5f)
            {
                scrollSpeed = scrollSpeed - 0.5f;
                raised = true;
            }

        }

        

    }

    public void scalingSpawn()
    {
        if (score % 10 == 0 && score != 0 && raised == false)
        {
            if (spawnRate > 1.5f || score == 50)
            {
                spawnRate = spawnRate - 0.5f;
            }
        }

    }

    public void getFaster()
    {
        if (faster)
        {
            source.Play();
            scrollSpeed = scrollSpeed - 0.5f;
        }


    }

    public void getSlower()
    {
        if (slower)
        {
            source.Play();
            scrollSpeed = scrollSpeed + 0.4f;
        }

    }

    public void getMultiplier()
    {
        if (multiplier && xM > 3)
        {
            xM = 0;
            source.Play();
        }

        if (xM == 3 && multiplier)
        {
            multiplier = false;

        }

    }

    public void saveScore()
    {
        if (PlayerPrefs.GetInt("hScoreThree") < score && PlayerPrefs.GetInt("hScoreTwo") > score)
        {
            scoreThree = score;
            PlayerPrefs.SetInt("hScoreThree", scoreThree);

        }

        if (PlayerPrefs.GetInt("hScoreTwo") < score && PlayerPrefs.GetInt("hScoreOne") > score)
        {
            
            scoreThree = PlayerPrefs.GetInt("hScoreTwo");
            PlayerPrefs.SetInt("hScoreThree", scoreThree);
            
            scoreTwo = score;
            PlayerPrefs.SetInt("hScoreTwo", scoreTwo);

        }


        if (PlayerPrefs.GetInt("hScoreOne") < score && PlayerPrefs.GetInt("hScoreTwo") < score)
        {
            scoreThree = PlayerPrefs.GetInt("hScoreTwo");
            PlayerPrefs.SetInt("hScoreThree", scoreThree);
            

            scoreTwo = PlayerPrefs.GetInt("hScoreOne");
            PlayerPrefs.SetInt("hScoreTwo", scoreTwo);
            
            scoreOne = score;
            PlayerPrefs.SetInt("hScoreOne", scoreOne);

        }

    }

}

