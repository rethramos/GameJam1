using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */
public class EventNames
{
    public class PowerupEvents
    {
        // when the player collides with a freeze powerup game object
        public const string ON_FREEZE_COLLECT = "ON_FREEZE_COLLECT";
        // when the player collides with a jump powerup game object
        public const string ON_JUMP_COLLECT = "ON_JUMP_COLLECT";
        // when the player collides with a hint (show arrows) powerup game object
        public const string ON_HINT_COLLECT = "ON_HINT_COLLECT";

        // when the player uses the freeze powerup
        public const string ON_FREEZE_USE = "ON_FREEZE_USE";
        // when the player uses the jump powerup
        public const string ON_JUMP_USE = "ON_JUMP_USE";
        // when the player uses the hint powerup
        public const string ON_HINT_USE = "ON_HINT_USE";
    }

}







