using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGDC.Unevolved.Utility
{
    internal class PositionLogger : MonoBehaviour
    {
        public bool ContinuousLogging = true;

        private void Awake()
        {
            if (this.ContinuousLogging)
                StartCoroutine("LogPositionContinuous");
            else
                LogPosition();
        }

        private IEnumerator LogPositionContinuous()
        {
            while (true)
            {
                LogPosition();
                yield return new WaitForSeconds(1.5f);
            }
        }

        private void LogPosition()
        {
            string position = gameObject.transform.position.x.ToString() + " "
                              + gameObject.transform.position.y.ToString();

            Debug.Log("Position of " + gameObject.name + ": " + position);
        }
    }
}
