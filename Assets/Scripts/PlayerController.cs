using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : PlatformerCharacter2D {

    public bool canMove = true;

    public new void Move(float move, bool crouch, bool jump)
    {
        if (canMove == false)
            move = 0f;

        base.Move(move, crouch, jump);
    }
}
