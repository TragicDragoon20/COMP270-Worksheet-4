﻿using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder
{
    private List<Vector3> vertices = new List<Vector3>();
    public List<Vector3> Vertices => vertices;

    private List<Vector3> normals = new List<Vector3>();
    public List<Vector3> Normals => normals;

    private List<Vector2> uvs = new List<Vector2>();
    public List<Vector2> Uvs => uvs;

    private List<int> indicies = new List<int>();

    // Adds the triangles to the list
    public void AddTriangle(int index0, int index1, int index2)
    {
        indicies.Add(index0);
        indicies.Add(index1);
        indicies.Add(index2);
    }

    /// <summary>
    /// Generates the mesh using the all the data that has been provided
    /// </summary>
    /// <returns>The generated mesh</returns>
    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        // Generates the vertices from the list
        mesh.vertices = vertices.ToArray();
        // Generates the triangles from the list
        mesh.triangles = indicies.ToArray();


        // Only generates normals when we have the correct amount
        if (normals.Count == vertices.Count)
        {
            mesh.normals = normals.ToArray();
        }

        // Only generates Uvs when we have the correct amount
        if (uvs.Count == vertices.Count)
        {
            mesh.uv = uvs.ToArray();
        }

        mesh.RecalculateBounds();

        return mesh;
    }
}
