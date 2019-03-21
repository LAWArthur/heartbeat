using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Common
{
    public class Common
    {
        public static Vector3 RandomNavMesh()
        {
            NavMeshTriangulation triangles = NavMesh.CalculateTriangulation();

            int i = Random.Range(0, triangles.indices.Length - 3);

            Vector3 point = Vector3.Lerp(triangles.vertices[triangles.indices[i]], triangles.vertices[triangles.indices[i + 1]], 0.5f);
            point = Vector3.Lerp(point, triangles.vertices[triangles.indices[i + 2]], 0.5f);

            return point;
        } 
    }
}
