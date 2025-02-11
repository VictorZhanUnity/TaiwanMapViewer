using UnityEngine;

namespace VictorDev.Advanced
{
    /// 物體旋轉
    public class AutoRotate : MonoBehaviour
    {
        public bool isActivated = true;
        public Vector3 direction = new Vector3(0, 1, 0);
        public float rotationSpeed = 50f;

        void Update()
        {
            if(isActivated) transform.Rotate(direction * rotationSpeed* Time.deltaTime);
        }
    }
}