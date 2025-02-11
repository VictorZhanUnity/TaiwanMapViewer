using UnityEngine;

public class ConnectLineHandler : MonoBehaviour
{
    public Transform targetFrom, targetTo;
    public float offsetY = 0.4f;
    public float offsetX = 0.015f;

    public ConnectLine connectLinePrefab;

    private void Start()
    {
        ConnectLine line1 = Instantiate(connectLinePrefab, transform);
        ConnectLine line2 = Instantiate(connectLinePrefab, transform);

        line1.Connect(targetFrom, targetTo, offsetY, offsetX);
        line2.Connect(targetTo, targetFrom, offsetY, -offsetX);
    }
}