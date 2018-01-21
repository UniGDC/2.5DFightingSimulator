using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UniGDC.Unevolved.Utility
{
    internal class SizeLogger : MonoBehaviour
    {
        public bool ContinuousLogging = true;

        private SpriteRenderer _targetSprite;

        private void Awake()
        {
            this._targetSprite = gameObject.GetComponent<SpriteRenderer>();
            if (this.ContinuousLogging)
                StartCoroutine("LogSizeContinuous");
            else
                LogSize();
        }

        private IEnumerator LogSizeContinuous()
        {
            while (true)
            {
                LogSize();
                yield return new WaitForSeconds(1.5f);
            }
        }

        private void LogSize()
        {
            string size = this._targetSprite.bounds.size.x.ToString() + " "
              + this._targetSprite.bounds.size.y.ToString();

            Debug.Log("Size of " + gameObject.name + ": " + size);
        }
    }
}
