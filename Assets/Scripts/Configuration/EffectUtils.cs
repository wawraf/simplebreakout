using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class EffectUtils
{
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    
    public static float TimeLeft
    {
        get { return SpeedupEffectMonitor.TimeLeft; }
    }

    #endregion

}
