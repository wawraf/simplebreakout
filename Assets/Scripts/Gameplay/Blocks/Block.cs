using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    /// <summary>
    /// Script describing block behaviouor
    /// </summary>

    private float points;

    AddPointsEvent addPointsEvent = new AddPointsEvent();

    protected float Points
    {
        get { return points; }
        set { points = value; }
    }

    virtual protected void Start()
    {
        EventManager.AddPointsInvoker(this);
    }

    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        addPointsEvent.Invoke(Points);
        Destroy(gameObject);
    }

    public void AddPointsListener(UnityAction<float> listener)
    {
        addPointsEvent.AddListener(listener);
    }
}
