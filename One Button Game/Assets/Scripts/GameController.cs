using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float matchTimer; // checking how long the match is going. might not need anymore

    public int round;
    public int score; // amt of homies kissed...don't think we REALLY need this but w/e

    public bool gameEnd;

    static GameController gc;

    public TextMeshProUGUI actionText, scoreTxt;

    float waitTime;
    public GameObject hearts, tutorial;
    bool didRestart;

    public AudioClip wrong, right, changeScene, textSnd, indicatorSnd;
    public AudioSource aud;


    // Start is called before the first frame update
    void Awake()
    {
        if (gc == null)
        {
            gc = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (gc != this)
                Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            scoreTxt.text = "Homies kissed: " + score;
            if (!gameEnd)
            {
                matchTimer += Time.deltaTime;
            }

            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
                if (waitTime < 2f && !didRestart)
                {
                    scoreTxt.enabled = true;
                    SceneManager.LoadScene(1);
                    didRestart = true;
                }
                
            }
            else if (waitTime <= 0f && gameEnd)
            {
                ShowNewText("");
                gameEnd = false;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                SceneManager.LoadScene(1);
                tutorial.SetActive(false);
            }
        }
    }

 
    public void RestartMatch(bool didLose = false)
    {
        didRestart = false;
       GameObject g = Instantiate(hearts, transform.position, Quaternion.identity, transform) as GameObject;
        Destroy(g, 5f);
        aud.clip = changeScene;
        aud.Play();
        scoreTxt.enabled = false;
        gameEnd = false;
        matchTimer = 0f;
        if (didLose)
        {
            round = 0;
            score = 0;
        }
        else
        {
            round++;
            score++;
        }
        waitTime = 4f;
    }

    public void ShowNewText(string s)
    {
        AudioSource.PlayClipAtPoint(textSnd, transform.position);
        actionText.text = s;
    }
}
