using UnityEngine;

namespace Client.Core
{
    // Игрок.
    public interface IPlayer
    {
        Rigidbody2D Rigidbody
        {
            get;
        }

        bool Running
        {
            get;
            set;
        }

        float RunningVelocityRatio
        {
            get;
            set;
        }

        bool Jumping
        {
            get;
            set;
        }

        float JumpingVelocityRatio
        {
            get;
            set;
        }
    }
}
