using UnityEngine;

namespace VictorDev.Advanced
{
    /// 跟隨鼠標處理
    /// + UI物件的Pivot需設為
    public class MouseCursorFollwer : MonoBehaviour
    {
        private RectTransform RectTrans => _rectTrans ??= GetComponent<RectTransform>();
        private RectTransform _rectTrans;
        
        public Vector2 offsetPos = new Vector2(10, -5);

        void Update()
        {
            // 取得鼠標位置
            Vector2 mousePosition = Input.mousePosition;

            // 如果 Canvas 為 Screen Space - Overlay，直接使用 mousePosition
            RectTrans.position = mousePosition + offsetPos;

            // 如果 Canvas 為 Screen Space - Camera 或 World，需要轉換座標
            /*
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent as RectTransform, mousePosition, Camera.main, out Vector2 localPoint);
            rectTransform.localPosition = localPoint;
            */
        }
    }
}