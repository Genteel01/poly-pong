using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordPresence;

public class RPController : MonoBehaviour
{
    public string detail;
    //public string state;
    public Settings settings;
    public bool overrideEditor = false;
    // Start is called before the first frame update
    void Start()
    {
        //PresenceManager.UpdatePresence(detail: detail, state: state);
        if(overrideEditor)
        {
            detail = "Playing ";
            if(settings.numberOfPaddles == 8)
            {
                detail += "an ";
            }
            else
            {
                detail += "a ";
            }
            detail += settings.numberOfPaddles + " player game with " + (settings.numberOfPlayers - 1) + " other";
            if (settings.numberOfPlayers == 2)
            {
                detail += " person";
            }
            else
            {
                detail += " people";
            }
        }
        PresenceManager.UpdatePresence(detail: detail);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
