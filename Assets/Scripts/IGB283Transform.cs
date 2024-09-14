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

        Matrix3x3 translationMatrix = Matrix3x3.Translate(position);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = translationMatrix.MultiplyPoint(vertices[i]);
        }

        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
    }


    public static IGB283Vector3[] TranslateVertices(IGB283Vector3[] originalVertices, IGB283Vector3 position)
    {

        IGB283Vector3[] translatedVertices = originalVertices.Select(v => (IGB283Vector3)v).ToArray();

        Matrix3x3 translationMatrix = Matrix3x3.Translate(position);

        for (int i = 0; i < translatedVertices.Length; i++)
        {
            translatedVertices[i] = translationMatrix.MultiplyPoint(translatedVertices[i]);
        }

        return translatedVertices;
    }





    public static void Scale(GameObject gameObject, IGB283Vector3 scaleVector, IGB283Vector3[] orginalVertices)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;


        IGB283Vector3[] vertices = orginalVertices.Select(v => new IGB283Vector3(v.x, v.y, v.z)).ToArray();

        IGB283Vector3 objectCenter = Movement.GetObjectCenter(gameObject);

        Matrix3x3 translationMatrix = Matrix3x3.Translate(objectCenter);
        Matrix3x3 scaleMatrix = Matrix3x3.Scale(scaleVector);
        Matrix3x3 translationMatrix2 = Matrix3x3.Translate(-objectCenter);

        Matrix3x3 combined = translationMatrix * scaleMatrix * translationMatrix2;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = combined.MultiplyPoint(vertices[i]);
        }

        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
        gameObjectMesh.RecalculateNormals();
    }


    // Was used then switched
    public static IGB283Vector3[] ScaleValue(GameObject gameObject, IGB283Vector3 scaleVector)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;

        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();

        IGB283Vector3 objectCenter = Movement.GetObjectCenter(gameObject);

        Matrix3x3 translationMatrix = Matrix3x3.Translate(objectCenter);
        Matrix3x3 scaleMatrix = Matrix3x3.Scale(scaleVector);
        Matrix3x3 translationMatrix2 = Matrix3x3.Translate(-objectCenter);

        Matrix3x3 combined = translationMatrix * scaleMatrix * translationMatrix2;

        IGB283Vector3[] scaledVertices = new IGB283Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            scaledVertices[i] = combined.MultiplyPoint(vertices[i]);
        }
        return scaledVertices;
    }


    // Was used then switched
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

    public static IGB283Vector3[] RotateVertices(IGB283Vector3[] originalVertices, float rotationSpeed, IGB283Vector3 objectCenter)
    {
        IGB283Vector3[] rotatedVertices = originalVertices.Select(v => new IGB283Vector3(v.x, v.y, v.z)).ToArray();

        Matrix3x3 translationMatrix = Matrix3x3.Translate(objectCenter);
        Matrix3x3 rotateMatrix = Matrix3x3.Rotate(rotationSpeed * Time.deltaTime);
        Matrix3x3 translationMatrix2 = Matrix3x3.Translate(-objectCenter);

        Matrix3x3 combined = translationMatrix * rotateMatrix * translationMatrix2;

        for (int i = 0; i < rotatedVertices.Length; i++)
        {
            rotatedVertices[i] = combined.MultiplyPoint(rotatedVertices[i]);
        }

        return rotatedVertices;
    }



}