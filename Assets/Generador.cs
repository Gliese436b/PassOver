using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Generador : MonoBehaviour
{
    public Vector3[] vertices;
    public int[] triangles;
    public MeshFilter mf;
    public MeshRenderer mr;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();
    }

    void GenerateTriagle()
    {
        vertices = new Vector3[3];
        triangles = new int[3];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mf.mesh.vertices = vertices;
        mf.mesh.triangles = triangles;
    }
}
