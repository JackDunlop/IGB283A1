using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class IGB283Transform : MonoBehaviour
{
  


    public static void MoveObject(GameObject gameObject, IGB283Vector3 position)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;

        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();

        IGB283Vector3 objectCenter = Movement.GetObjectCenter(gameObject);
        Matrix3x3 translationMatrix = Matrix3x3.Translate(position);

        for (int i = 0; i < vertices.Length; i++)
        {

            vertices[i] = translationMatrix.MultiplyPoint(vertices[i]);
            
        }

        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
    }

    public static void Rotate(GameObject gameObject, float rotationSpeed)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;

        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();

        IGB283Vector3 objectCenter = Movement.GetObjectCenter(gameObject);

        Matrix3x3 translationMatrix = Matrix3x3.Translate(objectCenter);
        Matrix3x3 rotateMatrix = Matrix3x3.Rotate(rotationSpeed * Time.deltaTime);
        Matrix3x3 translationMatrix2 = Matrix3x3.Translate(-objectCenter);

        Matrix3x3 combined = translationMatrix * rotateMatrix * translationMatrix2;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = combined.MultiplyPoint(vertices[i]);
        }


        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
    }

}