using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniGDC.Unevolved.Utility;

namespace UniGDC.Unevolved.Stage
{
    public class Props : MonoBehaviour
    {
        #region External Parameters

        /// <summary>
        /// The object's position on ground.
        /// </summary>
        [NonSerialized]
        public float PositionOnGround;

        #endregion // External Parameters

        #region Controllable Parameters

        /// <summary>
        /// The actual width of the prop (in meters)
        /// </summary>
        public float PropWidth;

        #endregion

        #region Cached Objects

        private Camera _mainCamera;

        private Collider2D _collider;

        private SpriteRenderer _renderer;

        private StageSettings _stageSettings;

        #endregion

        #region Unity Functions

        private void Awake()
        {
            this._mainCamera = GameObject.Find("Main Camera")
                                         .GetComponent<Camera>();
            this._collider = gameObject.GetComponent<Collider2D>();
            this._renderer = gameObject.GetComponent<SpriteRenderer>();
            this._stageSettings = GameObject.Find("Stage")
                                            .GetComponent<StageSettings>();

            float positionOnGround = this._mainCamera.orthographicSize
                                     - this._renderer.size.y
                                     + gameObject.transform.position.y;

#if DEBUG
            Debug.Log("Object " + gameObject.name + "'s position: " + positionOnGround);
#endif

            this.PositionOnGround = positionOnGround;

            // Map the position thing to the actual sorting order
            this._renderer.sortingOrder
                = positionOnGround.Map(0, this._stageSettings.StageWidth,   // Original values
                                       -32768, 32767);                      // Target range
        }

        private void Update()
        {
            
        }

        #endregion
    }
}
