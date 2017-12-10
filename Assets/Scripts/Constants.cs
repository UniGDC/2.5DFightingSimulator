using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.FightingSimulator
{
    
    public class Constants : MonoBehaviour
    {
        private bool NotDestroyable = false;

        #region Resource Controllers



        #endregion // Resource Controllers

        #region Gameplay Related Variables

        /// <summary>
        /// Normalized vector that represents the character's forward and backward movement.
        /// </summary>
        public Vector2 Forward = (new Vector2(1.0f, 1.0f)).normalized;

        /// <summary>
        /// Default Facing Directon of all characters.
        /// </summary>
        public Direction DefaultFacingDirection = Direction.Right;

        /// <summary>
        /// Default speed of all characters.
        /// </summary>
        /// <remarks>
        /// This value is used in <see cref="UniGDC.FightingSimulator.Character.AbstractCharacterController"/> class.
        /// </remarks>
        public float DefaultCharacterSpeed = 6.0f;

        /// <summary>
        /// Multiplier that is applied to the vertical movement of character.
        /// </summary>
        public float VerticalSpeedMultiplier = 0.9f;

        /// <summary>
        /// Location where the ground ends.
        /// </summary>
        public float GroundUpperLimit;

        /// <summary>
        /// Enumeration that indicates the in-game directions.
        /// </summary>
        /// <remarks>
        /// This direction is based on the player's view. For example, <see cref="Direction.Up"/> means
        /// "up" on the screen, which is represented as "backwards" in the game.
        /// </remarks>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        #endregion // Gameplay Related Variables

        /// <summary>
        /// Initializes the constant container class.
        /// </summary>
        private void Awake()
        {
            if (!this.NotDestroyable)
            {
                DontDestroyOnLoad(this);
                this.NotDestroyable = true;
            }
        }
    }
}
