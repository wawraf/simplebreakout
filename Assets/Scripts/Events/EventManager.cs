using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// Event manager for handling events around whole app
/// </summary>
public static class EventManager
{
    #region Ball Died
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }
    
    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }
    
    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }
    #endregion

    #region Ball Lost

    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners = new List<UnityAction>();

    public static void AddBallLostInvoker(Ball invoker)
    {   
        ballLostInvokers.Add(invoker);
        {
            foreach (UnityAction listener in ballLostListeners)
            {
                invoker.AddBallLostListener(listener);
            }
        }

    }

    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListeners.Add(listener);
        foreach (Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }
    
    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }


    #endregion

    #region Points

    static Block pointsInvoker;
    static UnityAction<float> pointsListener;

    public static void AddPointsInvoker(Block invoker)
    {
        pointsInvoker = invoker;
        if (pointsListener != null)
        {
            pointsInvoker.AddPointsListener(pointsListener);
        }
    }

    public static void AddPointsListener(UnityAction<float> listener)
    {
        pointsListener = listener;
        if (pointsInvoker != null)
        {
            pointsInvoker.AddPointsListener(pointsListener);
        }
    }

    #endregion

    #region Freezer Effect

    static List<EffectBlock> freezerInvokers = new List<EffectBlock>();
    static List<UnityAction<float>> freezerListeners = new List<UnityAction<float>>();

    public static void AddFreezerInvoker(EffectBlock invoker)
    {
        freezerInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    public static void AddFreezerListener(UnityAction<float> listener)
    {
        freezerListeners.Add(listener);
        foreach (EffectBlock invoker in freezerInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    public static void RemoveFreezeInvoker(EffectBlock invoker)
    {
        freezerInvokers.Remove(invoker);
    }
    #endregion

    #region SpeedUp Effect

    static List<EffectBlock> speedUpInvokers = new List<EffectBlock>();
    static List<UnityAction<float, float>> speedUpListeners = new List<UnityAction<float, float>>();

    public static void AddSpeedUpInvoker(EffectBlock invoker)
    {
        speedUpInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedUpListeners)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }
    public static void AddSpeedUpListener(UnityAction<float, float> listener)
    {
        speedUpListeners.Add(listener);
        foreach (EffectBlock invoker in speedUpInvokers)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }
    public static void RemoveSpeedUpInvoker(EffectBlock invoker)
    {
        speedUpInvokers.Remove(invoker);
    }
    #endregion
}
