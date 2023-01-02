using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Device;

public enum KeyColor
{
    Red,
    Blue,
    Gold
}
public class Key : PickUp
{
    //zajecia 13
    public Material red;
    public Material blue;
    public Material gold;
    AudioClip pickClip;


    public KeyColor color;
    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        //Debug.Log("Podnios³eœ " + color  + " klucz");
        GameManager.gameManager.PlayClip(pickClip);
        Destroy(this.gameObject);
    }
    void Update()
    {
        Rotation();
    }

    void SetMyColor()
    {
        switch (color)
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
