using UnityEngine;
using UnityEngine.Events;

namespace VictorDev.Advanced
{
    /// 3D模型鼠標物件之處理
    /// + 需有Collider組件才有效用
    public class MouseEventHandler : MonoBehaviour
    {
        [Header("[Event] - 鼠標移動事件 >>> True: Enter, False: Exit")]
        public UnityEvent<bool> onMouseEnterAndExit = new UnityEvent<bool>();
        public UnityEvent onMouseEnter = new UnityEvent();
        public UnityEvent onMouseExit = new UnityEvent();

        [Header("[Event] - 鼠標點擊事件 >>> True: Down, False: Up")]
        public UnityEvent<bool> onMouseDownAndUp = new UnityEvent<bool>();
        public UnityEvent onMouseDown = new UnityEvent();
        public UnityEvent onMouseUp = new UnityEvent();

        [Header("[Event] - 鼠標點擊Click事件")] public UnityEvent onMousClicked = new UnityEvent();

        private void OnMouseEnter()
        {
            onMouseEnter?.Invoke();
            onMouseEnterAndExit?.Invoke(true);
        }

        private void OnMouseExit()
        {
            _isMouseDown = false;
            onMouseExit?.Invoke();
            onMouseEnterAndExit?.Invoke(false);
        }

        private void OnMouseDown()
        {
            _isMouseDown = true;
            onMouseDown?.Invoke();
            onMouseDownAndUp?.Invoke(true);
        }

        private void OnMouseUp()
        {
            if (_isMouseDown) onMousClicked?.Invoke();
            _isMouseDown = false;
            onMouseUp?.Invoke();
            onMouseDownAndUp?.Invoke(false);
        }
        
        #region Variables

        private bool _isMouseDown = false;

        #endregion
    }
}