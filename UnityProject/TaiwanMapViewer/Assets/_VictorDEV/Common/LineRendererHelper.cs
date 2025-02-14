using System;
using UnityEngine;

namespace VictorDev.Advanced
{
    public class LineRendererHelper : MonoBehaviour
    {
        public LineRenderer targetLineRenderer;

        private void CheckTarget()
        {
            if (targetLineRenderer == null)
            {
                if (TryGetComponent(out targetLineRenderer))
                {
                    Debug.Log(">>> 自身沒有LineRenderer組件");
                }
            }
        }

        [ContextMenu("- Position位置順序顛倒")]
        private void ReverseLine()
        {
            CheckTarget();
            if (targetLineRenderer.positionCount < 2) return;

            int count = targetLineRenderer.positionCount;
            Vector3[] positions = new Vector3[count];
            targetLineRenderer.GetPositions(positions);

            // 反轉陣列
            Array.Reverse(positions);

            // 設置反轉後的新座標
            targetLineRenderer.SetPositions(positions);
            Debug.Log($"[{name}] >>> Position位置順序顛倒 --- OK!!");
        }
    }
}