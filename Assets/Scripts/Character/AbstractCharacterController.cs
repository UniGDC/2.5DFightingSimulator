using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.FightingSimulator.Character
{
    /// <summary>
    /// Base class for all character controllers.
    /// </summary>
    public abstract class AbstractCharacterController : MonoBehaviour
    {
        #region External Parameters

        /// <summary>
        /// Current hit point of the character.
        /// </summary>
        [NonSerialized]
        public float HP;
        
        /// <summary>
        /// Maximum hit point of the character.
        /// </summary>
        [NonSerialized]
        public float MaxHP;

        /// <summary>
        /// True if the character is crouching.
        /// </summary>
        [NonSerialized]
        public bool Crouched;

        /// <summary>
        /// True if the character is in controllable state.
        /// </summary>
        [NonSerialized]
        public bool Controllable;

        /// <summary>
        /// Simulated Z-position of the character.
        /// </summary>
        /// <remarks>
        /// This value changes dynamically throughout the game.
        /// The sorting order depends on this value, to make the game
        /// a bit more visually appealing.
        /// </remarks>
        [NonSerialized]
        public float ZPosition;

        /// <summary>
        /// The direction that the character is facing.
        /// </summary>
        [NonSerialized]
        public Constants.Direction FacingDirection;

        #endregion // External Parameters

        #region Internal Parameters

        private float HorizontalSpeed = 0.0f;

        private float VerticalSpeed = 0.0f;

        #endregion // Internal Parameters

        #region Controllable Parameters

        [SerializeField]
        protected float MaximumVelocity;

        #endregion // Controllable Parameters

        #region Cached Objects

        [NonSerialized]
        protected Animator Animator;

        [NonSerialized]
        protected Rigidbody2D Rigidbody;

        [NonSerialized]
        protected Constants StaticVariables;

        [NonSerialized]
        protected GameObject FootLocation;

        #endregion // Cached Objects

        #region Unity Functions

        protected virtual void Awake()
        {
            this.Animator = gameObject.GetComponent<Animator>();
            this.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            this.StaticVariables = GameObject.Find("Static Variables").GetComponent<Constants>();
            this.FacingDirection = Constants.Direction.Right;
            this.FootLocation = GameObject.Find("Foot Position");
        }
        
        protected virtual void Start()
        {
            // Implemented by children classes
        }

        protected virtual void Update()
        {
            // Implemented by children classes
        }

        protected virtual void FixedUpdate()
        {
            if (!this.Controllable)
                return;

            this.Rigidbody.velocity = new Vector2(this.HorizontalSpeed, 0) + this.StaticVariables.Forward * this.VerticalSpeed;

            Vector3 foot = this.FootLocation.transform.position;
        }

        #endregion // Unity Functions

        #region Other Functions

        /// <summary>
        /// Moves the character with given parameter.
        /// </summary>
        /// <param name="horizontal">Left-right movement of the character</param>
        /// <param name="vertical">Forward-backward movement of the character (on screen up and down movement)</param>
        public virtual void Move(float horizontal, float vertical)
        {
            if (horizontal != 0.0f)
                this.FacingDirection = (horizontal < 0.0f) ? Constants.Direction.Left : Constants.Direction.Right;

            if (vertical != 0.0f)
                this.FacingDirection |= (vertical < 0.0f) ? Constants.Direction.Up : Constants.Direction.Down;

            this.HorizontalSpeed = Mathf.Clamp(this.StaticVariables.DefaultCharacterSpeed
                                               * horizontal,
                                               -this.MaximumVelocity,
                                               this.MaximumVelocity);
            this.VerticalSpeed = Mathf.Clamp(this.StaticVariables.DefaultCharacterSpeed
                                             * this.StaticVariables.VerticalSpeedMultiplier
                                             * vertical,
                                             -this.MaximumVelocity,
                                             this.MaximumVelocity);
        }

        /// <summary>
        /// Kills the character
        /// </summary>
        /// <param name="over">True if game is over</param>
        public virtual void Die(bool over)
        {
            // TODO: Implement death function. This function may be different for different type of characters.
        }

        /// <summary>
        /// Sets the new HP and Maximum HP of a character.
        /// </summary>
        /// <param name="newHP">New current HP of the character</param>
        /// <param name="newMaxHP">New maximum HP of the character</param>
        public virtual void SetHP(float newHP, float newMaxHP = default(float))
        {
            this.HP = newHP;
            
            if (newMaxHP == default(float))
                this.MaxHP = newMaxHP;
        }

        #endregion // Other Functions
    }
}
