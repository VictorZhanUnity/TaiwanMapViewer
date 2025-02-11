using UnityEngine;
using UnityEngine.Events;

namespace _VictorDEV.Advanced
{
    /// 偵測與MainCamera之間的距離
    public class DistanceFromCameraHandler : MonoBehaviour
    {
        private void Update()
        {
            float distance = Vector3.Distance(MainCamera.transform.position, transform.position);
            distanceFromCamera?.Invoke(distance);
            isInDistance?.Invoke(distanceThreshold > distance);
        }

        #region Components

        [Header("[Event] - 是否在指定距離範圍值內")] public UnityEvent<bool> isInDistance = new UnityEvent<bool>();
        [Header("[Event] - 與MainCamera之間的距離")] public UnityEvent<float> distanceFromCamera = new UnityEvent<float>();

        [Header(">>> MainCamera之間的偵測距離範圍Threshold值")] [SerializeField]
        private float distanceThreshold = 2f;

        private Camera MainCamera => _mainCamera ??= Camera.main;
        private Camera _mainCamera;

        #endregion
    }
}