using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    public static ConfigurationData configurationData;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallLifetime
    {
        get { return configurationData.BallLifeSeconds; }
    }

    public static float MinimumSpawnTime
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    public static float MaximumSpawnTime
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }
    public static float BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }
    public static float StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }
    public static float BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }
    public static float EffectBlockPoints
    {
        get { return configurationData.EffectBlockPoints; }
    }

    public static float StandardBlockProbability
    {
        get { return configurationData.StandardBlockProbability; }
    }
    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability;}
    }
    public static float FreezerBlockProbability
    {
        get { return configurationData.FreezerBlockProbability;}
    }
    public static float SpeedUpBlockProbability
    {
        get { return configurationData.StandardBlockProbability; }
    }
    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }
    public static float SpeedUpEffectDuration
    {
        get { return configurationData.SpeedUpEffectDuration; }
    }
    public static float SpeedUpEffectFactor
    {
        get { return configurationData.SpeedUpEffectFactor; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
