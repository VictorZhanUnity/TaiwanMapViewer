using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VictorDev.Common;

namespace VictorDev.CameraUtils
{
    public class LandmarkCameraHandler: MonoBehaviour
    {
        [Header("[Event] - 當Landmark被點擊時，Invoke該目標物件")]
        public UnityEvent<Transform> onLandmarkClicked = new UnityEvent<Transform>();
        
        private void OnToggleChangeHandler(bool isOn, Toggle target)
        {
            if (isOn == false) return;
            Transform result = target.transform.parent.GetComponent<PositionTo2DPoint>().target3DObject;
            onLandmarkClicked?.Invoke(result);
        }

        public void CancelLandmarkToggle()
        {
            landmarkToggles.ForEach(target=>target.isOn = false);
        }

        [ContextMenu("- 尋找所有Landmark項目之Toggle")]
        private void FindLandmarkToggles()
        {
            Toggle[] result = FindObjectsOfType<Toggle>();
            landmarkToggles = result.Where(target=>target.name.Equals("Landmark", StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public List<Toggle> landmarkToggles = new List<Toggle>();

        #region  Initialize
        private void OnEnable() => landmarkToggles.ForEach(target=>target.onValueChanged.AddListener((isOn)=>OnToggleChangeHandler(isOn, target)));
        private void OnDisable() => landmarkToggles.ForEach(target=>target.onValueChanged.RemoveListener((isOn)=>OnToggleChangeHandler(isOn, target)));
        #endregion  
    }
}