using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]public int timeToEnd;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    //zajecia 13
    AudioSource audioSource;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;


    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 100)
        {
            timeToEnd = 100;
        }

        //Debug.Log("Time: " + timeToEnd + " s");
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
    }
    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time " + timeToEnd + " s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        PlayClip(pauseClip);
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reoad?");
        }
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //zajecia 4

    public void Picked()
    {
        Debug.Log("Podnios?em");
        Destroy(this.gameObject);
    }

    public int points = 0;
    public int redKey = 10;
    public int blueKey = 1;
    public int goldKey = 1;

    public void AddPoints(int points)
    {
        points += points;
    }

    public void FreezeTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stoppe", freez, 1);
    }
    
    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Gold)
        {
            goldKey++;
        } else if (color == KeyColor.Red)
        {
            redKey++;
        } else if(color == KeyColor.Blue)
        {
            blueKey++;
        }
    }

    public void PickUpCheck()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red " + redKey + " green keys " + blueKey + " golden keys" + goldKey);
            Debug.Log("Points " + points);
        }
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    //zajecia 13 

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }

   
}