using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{
    const string OpponentPushingTag = "Pushing";
    public bool pushing; //押し合い

    public bool isPushing()
    {
        return pushing;
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == OpponentPushingTag)
        {
            pushing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.tag == OpponentPushingTag)
        {
            pushing = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == OpponentPushingTag)
        {
            pushing = false;

        }
    }

}
