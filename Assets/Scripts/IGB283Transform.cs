using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class IGB283Transform : MonoBehaviour
{
    // Translation


    public static IGB283Vector3 IGBTranslate(IGB283Vector3 point, IGB283Vector3 translation)
    {
        return new IGB283Vector3(point.x + translation.x, point.y + translation.y, point.z + translation.z);
    }


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




    public static void RotateGameObject(GameObject gameObject, IGB283Vector3 position, float speed)
    {

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;


        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();


        Matrix3x3 rotationMatrix = Matrix3x3.Rotate(speed * Time.deltaTime);
        Matrix3x3 translationMatrix = Matrix3x3.Translate(position);

        Matrix3x3 combideMatrix = rotationMatrix * translationMatrix;


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = combideMatrix.MultiplyPoint(vertices[i]);
        }


        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
    }





}