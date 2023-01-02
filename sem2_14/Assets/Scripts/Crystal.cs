using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;
    //zajecia 13:
    AudioClip pickClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        //zajecia 13
        GameManager.gameManager.PlayClip(pickClip);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
