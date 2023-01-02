using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    Animator key;
    
    //zajecia 13
    public Renderer myLock;
    public Material red;
    public Material blue;
    public Material gold;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = true;
            GameManager.gameManager.useInfo.text="";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("Nie masz klucza"); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    public void UseKey()
    {
        foreach(Door door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKey > 0 && myColor == KeyColor.Red )
        {
            GameManager.gameManager.redKey--;
            GameManager.gameManager.redKeyText.text = GameManager.gameManager.redKey.ToString();
            locked = true;
            return true;
        } 
        else if(GameManager.gameManager.blueKey > 0 
            && myColor == KeyColor.Blue)
        {
            GameManager.gameManager.blueKey--;
            GameManager.gameManager.blueKeyText.text = GameManager.gameManager.blueKey.ToString();
            locked = true;
            return true;
        } 
        else if(GameManager.gameManager.goldKey > 0 
            && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            GameManager.gameManager.goldKeyText.text = GameManager.gameManager.goldKey.ToString();
            locked = true;
            return true;
        } else {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            GameManager.gameManager.useInfo.text = "Naciœnij E ¿eby utrzyæ klucza";
            key.SetBool("useKey" , CheckTheKey());
        }
    }

    void SetMyColor()
    {
        switch (myColor)
        {
            case KeyColor.Red:
            GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Blue:
                GetComponent<Renderer>().material = blue;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                break;
        }
    }
}
