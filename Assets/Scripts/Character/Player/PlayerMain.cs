using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.Unevolved.Character.Player
{
    public class PlayerMain : MonoBehaviour
    {
        #region Cached Objects

        private PlayerController _playerCtrl;

        #endregion // Cached Objects

        #region Unity Functions

        private void Awake()
        {
            this._playerCtrl = gameObject.GetComponent<PlayerController>();
            this._playerCtrl.Controllable = true;
        }

        private void Update()
        {
            // If the character is not controllable, do nothing
            if (!_playerCtrl.Controllable)
                return;

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            _playerCtrl.Move(horizontalInput, verticalInput);
        }

        #endregion // Unity Functions
    }
}
