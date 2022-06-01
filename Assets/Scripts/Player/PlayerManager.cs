using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    //public static bool isDead;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public GameObject scoreText;
    public GameObject highScoreText;
    public GameObject coinsTotal;

    //public GameObject coinsTotalText;
    //public GameObject coinsTotal;


    public static int numberOfCoins;
    public Text coinsText;
    public int highScore;
    private ScoreManager theScoreManager;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false; //at the base he is desactivated
        Time.timeScale = 1; //to begin the game with speed when you replay
        isGameStarted = true;
       // isDead = false;
        numberOfCoins = 0;
        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreIncreasing = false;
        theScoreManager.scoreCount = 0;

        scoreText = GameObject.Find("ScoreText");
        highScoreText = GameObject.Find("HighScoreText");
        coinsTotal = GameObject.Find("CoinsTotal");

        //coinsTotalText = GameObject.Find("CoinsTotalText");
        //coinsTotal = GameObject.Find("CoinsTotal");

        //scoreText = GameObject.FindGameObjectWithTag("")
    }

    // Update is called once per frame
    void Update()
    {
        //coinsTotalText.transform.position = new Vector3(5200, 1250, 1);
        //coinsTotal.transform.position = new Vector3(5200, 1250, 1);

        if (gameOver)
        {
            //Time.timeScale = 0;
            //isDead = true;
            gameOverPanel.SetActive(true);
            theScoreManager.scoreIncreasing = false;
            

            scoreText.transform.position = new Vector3(5000, 1250, 1);
            //highScoreText.transform.position = new Vector3(750, 1850, 0);
            //settings.transform.position = new Vector3(70, 1850, 0);

            Vector3 newPosition = coinsTotal.transform.position;
            newPosition.x = 330;
            coinsTotal.transform.position = newPosition;

            Vector3 nextPosition = highScoreText.transform.position;
            nextPosition.x = 770;
            highScoreText.transform.position = nextPosition;
            //settings.transform.position += new Vector3(-100, 0, 0);

            //coinsTotalText.transform.position = new Vector3(825, 1750, 0);
            //coinsTotal.transform.position = new Vector3(825, 1749, 0);


        }
        else if (SwipeManager.tap)
        {
           // isDead = false;
            theScoreManager.scoreIncreasing = true;
            isGameStarted = false; //to play the game when you tap the screen
            Destroy(startingText);
        }
        coinsText.text = "x " + numberOfCoins;
    }
}
