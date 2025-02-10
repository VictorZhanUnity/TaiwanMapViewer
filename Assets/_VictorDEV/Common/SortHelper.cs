using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace VictorDev.Common
{
    public static class SortHelper
    {
        private static Vector3 _center;

        /// 依照圓心中心點進行排序
        public static List<Transform> SortByCircleCenter(List<Transform> targetList)
        {
            if (targetList == null || targetList.Count == 0) return null;

            // 計算圓心 (使用所有物件的平均位置)
            // 使用 LINQ 計算圓心
            _center = targetList.Select(obj => obj.position).Aggregate(Vector3.zero, (sum, pos) => sum + pos) /
                      targetList.Count;


            // 按照角度排序
            targetList = targetList.OrderBy(obj => GetAngle(obj.position)).ToList();

            // 測試輸出排序結果
            foreach (var obj in targetList)
            {
                Debug.Log(obj.name + " - Angle: " + GetAngle(obj.position));
            }

            return targetList;
        }

        // 計算物件相對於圓心的角度
        private static float GetAngle(Vector3 position)
        {
            Vector3 dir = position - _center; // 取得方向向量
            return Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg; // 計算角度 (XY 平面可改為 Atan2(dir.y, dir.x))
        }
    }
}