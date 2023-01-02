using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //zajecia 13
    AudioClip pickClip;
    
    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }

    public virtual void Picked()
    {
        //Debug.Log("Podnios³em");
        GameManager.gameManager.PlayClip(pickClip);
        Destroy(this.gameObject);
    }

   
}
