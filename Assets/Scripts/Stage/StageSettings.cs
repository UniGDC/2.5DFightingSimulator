using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.Unevolved.Stage
{
    /// <summary>
    /// This class holds some useful information about the stage.
    /// </summary>
    public class StageSettings : MonoBehaviour
    {
        #region External Parameters

        /// <summary>
        /// Normalized directional vector for <see cref="this.VerticalAngle"/>
        /// parameter. Probably 
        /// </summary>
        [NonSerialized]
        public Vector2 VerticalDirection;

        #endregion // External Parameters

        #region Controllable Parameters

        /// <summary>
        /// Bearing of character's vertical movement in Degrees.
        /// </summary>
        /// <remarks>
        /// This "bearing" stuff starts from the North direction;
        /// therefore, this value must be within the range on 0~90.
        /// </remarks>
        [Range(0, 90)]
        public float VerticalAngle;

        /// <summary>
        /// Speed of all characters.
        /// </summary>
        public float CharacterSpeed;

        /// <summary>
        /// Width (forward-backward distance) of the stage.
        /// </summary>
        public float StageWidth;

        /// <summary>
        /// Projected height of the ground 
        /// </summary>
        public float GroundUpperLimit;

        #endregion // Controllable Parameters

        #region Unity Functions

        private void Awake()
        {
            float rad = (90 - this.VerticalAngle) * Mathf.Deg2Rad;
            this.VerticalDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }

        #endregion // Unity Functions
    }
}
