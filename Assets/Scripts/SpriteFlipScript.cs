using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpriteFlipScript : MonoBehaviour
{   
    //This script essentially just flips the sprite according
    //to which direction the pathfinding is going towards.

    public SpriteRenderer spriteRenderer;
    public AIPath path;

    void FixedUpdate()
    {
        //Enemy moving towards the right
        if (path.desiredVelocity.x >= 0.01f)
        {
            spriteRenderer.flipX = false;
        }

        //Enemy moving towards the left
        else if(path.desiredVelocity.x <= 0.01f)
        {
            spriteRenderer.flipX = true;
        }

    }
}
