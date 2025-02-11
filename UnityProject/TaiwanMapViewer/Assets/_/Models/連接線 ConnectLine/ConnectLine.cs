using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ConnectLine : MonoBehaviour
{
    private LineRenderer LineRendererInstance => _lineRenderer ??= GetComponent<LineRenderer>();
    private LineRenderer _lineRenderer;

    public void Connect(Transform targetFrom, Transform targetTo, float offsetY, float offsetX)
    {
        Vector3 startPos = targetFrom.position;
        startPos.x += offsetX;
        startPos.y += offsetY;
        Vector3 endPos = targetTo.position;
        endPos.x += offsetX;
        endPos.y += offsetY;
        
        LineRendererInstance.SetPosition(0, startPos);
        LineRendererInstance.SetPosition(1, endPos);
    }
}
