using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Globalization;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 0.001f;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    float ballsPerGame = 10;

    float standardBlockPoints = 1;
    float bonusBlockPoints = 2;
    float effectBlockPoints = 5;

    float standardBlockProbability = 70;
    float bonusBlockProbability = 20;
    float freezerBlockProbability = 5;
    float speedUpBlockProbability = 5;

    float freezerEffectDuration = 2;
    float speedUpEffectDuration = 2;
    float speedUpEffectFactor = 1.5f;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of balls per game
    /// </summary>
    /// <value>maximum balls per game</value>
    public float BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public float StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }
    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }
    public float EffectBlockPoints
    {
        get { return effectBlockPoints; }
    }

    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }
    public float FreezerBlockProbability
    {
        get { return freezerBlockProbability; }
    }
    public float SpeedupBlockProbability
    {
        get { return speedUpBlockProbability; }
    }
    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }
    public float SpeedUpEffectDuration
    {
        get { return speedUpEffectDuration; }
    }
    public float SpeedUpEffectFactor
    {
        get { return speedUpEffectFactor; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        string fileDir = Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName); 
        StreamReader configFile = null;

        try
        {
            configFile = File.OpenText(fileDir);
            string names = configFile.ReadLine();
            string values = configFile.ReadLine();

            ConfigureData(values);
        } 
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        finally
        {
            if (configFile != null)
            {
                configFile.Close();
            }
        }


    }

    void ConfigureData(string stringValue)
    {
        string[] values = stringValue.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1], CultureInfo.InvariantCulture.NumberFormat);
        ballLifeSeconds = float.Parse(values[2]);

        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);

        ballsPerGame = float.Parse(values[5]);

        standardBlockPoints = float.Parse(values[6]);
        bonusBlockPoints = float.Parse(values[7]);
        effectBlockPoints = float.Parse(values[8]);

        standardBlockProbability = float.Parse(values[9]);
        bonusBlockProbability = float.Parse(values[10]);
        freezerBlockProbability = float.Parse(values[11]);
        speedUpBlockProbability = float.Parse(values[12]);

        freezerEffectDuration = float.Parse(values[13]);
        speedUpEffectDuration = float.Parse(values[14]);
        speedUpEffectFactor = float.Parse(values[15], CultureInfo.InvariantCulture.NumberFormat);
    }

    #endregion
}
