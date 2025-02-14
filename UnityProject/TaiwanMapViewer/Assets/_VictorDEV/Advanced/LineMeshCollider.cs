using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class LineMeshCollider : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private MeshCollider _meshCollider;

    public float thickness = 0.2f; // 碰撞體厚度

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
        UpdateCollider();
    }

    [ContextMenu("- UpdateCollider")]
    void UpdateCollider()
    {
        Mesh mesh = new Mesh();
        Vector3[] positions = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(positions);

        if (positions.Length < 2) return;

        Vector3[] vertices = new Vector3[positions.Length * 4]; // 每個點 4 個頂點（立方體結構）
        int[] triangles = new int[(positions.Length - 1) * 24]; // 每條線段 24 個三角形索引（立方體）

        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 forward = Vector3.zero;

            if (i > 0) forward += (positions[i] - positions[i - 1]).normalized;
            if (i < positions.Length - 1) forward += (positions[i + 1] - positions[i]).normalized;

            forward.Normalize();

            // 計算厚度方向
            Vector3 right = Vector3.Cross(forward, Vector3.up).normalized * thickness;
            Vector3 up = Vector3.Cross(forward, right).normalized * thickness;

            // 建立 4 個頂點（矩形）
            vertices[i * 4] = positions[i] + right + up;
            vertices[i * 4 + 1] = positions[i] + right - up;
            vertices[i * 4 + 2] = positions[i] - right + up;
            vertices[i * 4 + 3] = positions[i] - right - up;
        }

        // 產生立方體面的三角形索引
        for (int i = 0; i < positions.Length - 1; i++)
        {
            int index = i * 24;
            int vIndex = i * 4;

            // 正面
            triangles[index] = vIndex;
            triangles[index + 1] = vIndex + 4;
            triangles[index + 2] = vIndex + 1;

            triangles[index + 3] = vIndex + 1;
            triangles[index + 4] = vIndex + 4;
            triangles[index + 5] = vIndex + 5;

            // 背面
            triangles[index + 6] = vIndex + 2;
            triangles[index + 7] = vIndex + 3;
            triangles[index + 8] = vIndex + 6;

            triangles[index + 9] = vIndex + 3;
            triangles[index + 10] = vIndex + 7;
            triangles[index + 11] = vIndex + 6;

            // 左側
            triangles[index + 12] = vIndex;
            triangles[index + 13] = vIndex + 2;
            triangles[index + 14] = vIndex + 4;

            triangles[index + 15] = vIndex + 2;
            triangles[index + 16] = vIndex + 6;
            triangles[index + 17] = vIndex + 4;

            // 右側
            triangles[index + 18] = vIndex + 1;
            triangles[index + 19] = vIndex + 5;
            triangles[index + 20] = vIndex + 3;

            triangles[index + 21] = vIndex + 3;
            triangles[index + 22] = vIndex + 5;
            triangles[index + 23] = vIndex + 7;
        }

        // 套用 Mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        _meshCollider.sharedMesh = null;
        _meshCollider.sharedMesh = mesh;
    }
}
