using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    /// <summary>
    /// Script describing block behaviouor
    /// </summary>

    override protected void Start()
    {
        base.Start();

        Points = ConfigurationUtils.BonusBlockPoints;
    }
}
