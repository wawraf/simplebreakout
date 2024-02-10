using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    /// <summary>
    /// Script describing standard block behaviouor
    /// </summary>
    override protected void Start()
    {
        base.Start();

        Points = ConfigurationUtils.StandardBlockPoints;

        //Color[] colors = { Color.red, Color.blue, Color.green };
        //int select = Random.Range(0, colors.Length);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.color = colors[select];
        spriteRenderer.color = Color.green;
    }
}
