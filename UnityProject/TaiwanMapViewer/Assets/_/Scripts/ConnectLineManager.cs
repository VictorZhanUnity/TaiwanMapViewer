using System.Collections.Generic;
using UnityEngine;
using VictorDev.Common;

public class ConnectLineManager : MonoBehaviour
{
    public List<Transform> stationList = new List<Transform>();
    public ConnectLine connectLinePrefab;

    private readonly float _offsetY = 0.4f;
    private readonly float _offsetX = 0.015f;

    [ContextMenu("-  SortByCircleCenter")]
    private void SortByCircleCenter()
    {
        stationList = SortHelper.SortByCircleCenter(stationList);
        stationList.ForEach(target => target.SetAsLastSibling());
    }

    [ContextMenu("- CreateConnectLines")]
    private void CreateConnectLines()
    {
        for (int i = 0; i < stationList.Count; i++)
        {
            Transform targetFrom = stationList[i];
            Transform targetTo = stationList[(i + 1) % stationList.Count];
            ConnectLine line1 = Instantiate(connectLinePrefab, transform);
            ConnectLine line2 = Instantiate(connectLinePrefab, transform);
            line1.Connect(targetFrom, targetTo, _offsetY, _offsetX);
            line2.Connect(targetTo, targetFrom, _offsetY, -_offsetX);
        }
    }
}