using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniGDC.Unevolved.Stage;

namespace UniGDC.Unevolved.Character
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

        #endregion // External Parameters

        #region Internal Parameters

        /// <summary>
        /// Horizontal speed of the character. This value changes continuously
        /// throughout the game.
        /// </summary>
        private float _horizontalSpeed = 0.0f;

        /// <summary>
        /// Vertical speed of the character. This value changes continuously
        /// throughout the game.
        /// </summary>
        private float _verticalSpeed = 0.0f;

        /// <summary>
        /// Height of the character.
        /// </summary>
        private float _height;

        #endregion // Internal Parameters

        #region Controllable Parameters

        /// <summary>
        /// Speed of the character in relation to their default speed.
        /// </summary>
        [SerializeField]
        protected float SpeedMultiplier = 1;

        #endregion // Controllable Parameters

        #region Cached Objects

        [NonSerialized]
        protected Animator Animator;

        [NonSerialized]
        protected Rigidbody2D Rigidbody;

        [NonSerialized]
        protected StageSettings StageVariables;

        [NonSerialized]
        protected Transform SpriteTransform;

        #endregion // Cached Objects

        #region Unity Functions

        protected virtual void Awake()
        {
            this.Animator = gameObject.GetComponent<Animator>();
            this.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            this.StageVariables = GameObject.Find("Stage").GetComponent<StageSettings>();
            this.SpriteTransform = this.transform.Find("Sprite");
        }
        
        protected virtual void Start()
        {
            // Implemented by children classes
        }

        protected virtual void Update()
        {
            Face(this._horizontalSpeed);
        }

        protected virtual void FixedUpdate()
        {
            if (!this.Controllable)
                return;

            Vector2 target = Vector2.right * this._horizontalSpeed
                             + this.StageVariables.VerticalDirection * this._verticalSpeed;
            this.Rigidbody.velocity = target;
        }

        #endregion // Unity Functions

        #region Other Functions

        /// <summary>
        /// Moves the character with given parameter.
        /// </summary>
        /// <param name="horizontal">Left-right movement of the character</param>
        /// <param name="vertical">Forward-backward movement of the character (up and down movement on screen)</param>
        public virtual void Move(float horizontal, float vertical)
        {
            this._horizontalSpeed = horizontal
                                    * this.StageVariables.CharacterSpeed
                                    * this.SpeedMultiplier;
            this._verticalSpeed = vertical
                                  * this.StageVariables.CharacterSpeed
                                  * this.SpeedMultiplier;
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

        public virtual void Face(float horizontal)
        {
            Vector3 scale = this.SpriteTransform.localScale;

            if (horizontal != 0.0f)
                if (horizontal < 0.0f)
                    scale.x = -1.0f;
                else
                    scale.x = 1.0f;
        }

        #endregion // Other Functions
    }
}
