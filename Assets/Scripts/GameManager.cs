using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text timeText;
    public Text goldKeyText;
    public Text blueKeyText;
    public Text redKeyText;
    public Text cristalText;

    public GameObject infoPanel;
    public Text pauseEnd;
    public Text reloadInfo;
    public Text useInfo;

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

        audioSource = GetComponent<AudioSource>();
        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        pauseEnd.text = "Pause";
        reloadInfo.text = "";
        useInfo.text = "";
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
        timeText.text = timeToEnd.ToString();
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
        if (!endGame)
        {
            PlayClip(pauseClip);
            infoPanel.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
        }
    }
    public void ResumeGame()
    {
        if (!endGame)
        {
            infoPanel.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            pauseEnd.text = "Gratulacjie wygra³eœ !!!";
            reloadInfo.text = "Reload Y/N";
        }
        else
        {
            pauseEnd.text = "Skoñczy³ ci siê czas. Pzregra³eœ";
            reloadInfo.text = "Reload Y/N";
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
        Debug.Log("Podnios³em");
        Destroy(this.gameObject);
    }

    public int points = 0;
    public int redKey = 10;
    public int blueKey = 1;
    public int goldKey = 1;

    public void AddPoints(int points)
    {
        points += points;
        cristalText.text = points.ToString();
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
            goldKeyText.text = goldKey.ToString();
        } else if (color == KeyColor.Red)
        {
            redKey++;
            redKeyText.text = redKey.ToString();
        } else if(color == KeyColor.Blue)
        {
            blueKey++;
            blueKeyText.text = blueKey.ToString();
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
        timeText.text = timeToEnd.ToString();
    }

    //zajecia 13 

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }

    public void SetUseInfo(string info)
    {
        useInfo.text = info;
    }

}