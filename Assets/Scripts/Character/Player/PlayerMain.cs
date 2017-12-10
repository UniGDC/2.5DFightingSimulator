using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.FightingSimulator.Character.Player
{
    public class PlayerMain : MonoBehaviour
    {
        #region Cached Objects

        private PlayerController PlayerCtrl;

        #endregion // Cached Objects

        #region Unity Functions

        private void Awake()
        {
            this.PlayerCtrl = gameObject.GetComponent<PlayerController>();
            this.PlayerCtrl.Controllable = true;
        }

        private void Update()
        {
            // If the character is not controllable, do nothing
            if (!PlayerCtrl.Controllable)
                return;

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            PlayerCtrl.Move(horizontalInput, verticalInput);
        }

        #endregion // Unity Functions
    }
}
