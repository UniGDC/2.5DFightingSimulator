using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.Unevolved.Utility
{
    internal class BackgroundFiller : MonoBehaviour
    {
        #region Unity Functions

        private void Start()
        {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            
            float screenHeight = Camera.main.orthographicSize * 2.0f;
            float screenWidth = screenHeight / Screen.height * Screen.width;

            gameObject.transform.localScale = new Vector3(screenWidth / renderer.sprite.bounds.size.x,
                                                          screenHeight / renderer.sprite.bounds.size.y,
                                                          1);
        }

        #endregion // Unity Functions
    }
}
