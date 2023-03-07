using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PublicEvents
{
    private static PublicEvents instance = null;
    public static PublicEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PublicEvents();
            }
            return instance;
        }
    }

    public UnityEvent WinEvent
    { 
        get 
        {
            if(winEvent == null)
            {
                winEvent = new UnityEvent();
            }
            return winEvent;
        } 
    }
    public UnityEvent LoseEvent
    {
        get
        {
            if (loseEvent == null)
            {
                loseEvent = new UnityEvent();
            }
            return loseEvent;
        }
    }
    public UnityEvent ReplayEvent
    {
        get
        {
            if (replayEvent == null)
            {
                replayEvent = new UnityEvent();
            }
            return replayEvent;
        }
    }
    private UnityEvent winEvent;
    private UnityEvent loseEvent;
    private UnityEvent replayEvent;
}
