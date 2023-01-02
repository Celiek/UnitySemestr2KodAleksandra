using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int freezeTime = 10;
    //zajecia 13

    AudioClip pickClip;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        GameManager.gameManager.PlayClip(pickClip);
        Destroy(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
