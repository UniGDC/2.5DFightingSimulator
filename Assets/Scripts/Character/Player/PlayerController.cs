using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniGDC.Unevolved.Character.Player
{
    /// <summary>
    /// Controller for player character.
    /// </summary>
    public sealed class PlayerController : AbstractCharacterController
    {
        #region Internal Parameters

        /// <summary>
        /// True if the player is crouching.
        /// </summary>
        [NonSerialized]
        public bool Crouched;

        #endregion // Internal Parameters

        #region Cached Objects

        private GameObject _mainCamera;

        private GameObject _spriteObject;

        private GameObject _colliderObject;

        private SpriteRenderer _renderer;

        #endregion // Cached Objects

        #region Unity Functions

        protected override void Awake()
        {
            base.Awake();

            this._mainCamera = GameObject.Find("Main Camera");
            this._spriteObject = this.transform.Find("Sprite").gameObject;
            this._colliderObject = this.transform.Find("Collider").gameObject;
        }

        #endregion // Unity Functions

    }
}