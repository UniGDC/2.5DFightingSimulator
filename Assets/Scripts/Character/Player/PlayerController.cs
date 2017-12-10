using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniGDC.FightingSimulator.Character.Player
{
    /// <summary>
    /// Controller for player character.
    /// </summary>
    public sealed class PlayerController : AbstractCharacterController
    {
        #region Internal Parameters

        /// <summary>
        /// True if the character is jumping.
        /// </summary>
        [NonSerialized]
        public bool Jumped;

        /// <summary>
        /// Amount of time that has passed since the player started jumping.
        /// </summary>
        [NonSerialized]
        public float JumpTime;

        #endregion // Internal Parameters

        #region Cached Objects

        private GameObject Textbox;

        #endregion // Cached Objects

        #region Unity Functions

        protected override void Awake()
        {
            base.Awake();

            this.Textbox = GameObject.Find("Text");
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            this.Textbox.GetComponent<Text>().text = "FootX: " + this.FootLocation.transform.position.x + "\nFootY: " + this.FootLocation.transform.position.y
                + "\nBodyX: " + gameObject.transform.position.x + "\nBodyY: " + gameObject.transform.position.y + "\nYDiff: " + (gameObject.transform.position.y - this.FootLocation.transform.position.y);

            Vector3 clamped = new Vector3(Mathf.Clamp(gameObject.transform.position.x, -9.0f, 9.0f),
                                          Mathf.Clamp(this.FootLocation.transform.position.y, -5.0f, 1.8f) + 1.5f);
            gameObject.transform.position = clamped;
        }

        #endregion // Unity Functions

    }
}