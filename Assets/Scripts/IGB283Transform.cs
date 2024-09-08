using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IGB283Transform : MonoBehaviour
{
    // Translation


    public static IGB283Vector3 IGBTranslate(IGB283Vector3 point, IGB283Vector3 translation)
    {
        return new IGB283Vector3(point.x + translation.x, point.y + translation.y, point.z + translation.z);
    }

    public static void RotateGameObject(GameObject gameObject, float speed)
    {

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;


        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();


        Matrix3x3 rotationMatrix = Matrix3x3.Rotate(speed * Time.deltaTime);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = rotationMatrix.MultiplyPoint(vertices[i]);
        }


        gameObjectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        gameObjectMesh.RecalculateBounds();
    }



    // Scaling
    public static IGB283Vector3 IGBScale(IGB283Vector3 point, float scaleX, float scaleY)
    {
        return new IGB283Vector3(point.x * scaleX, point.y * scaleY, point.z);
    }


    public static IGB283Vector3 GetGameObjectPosition(GameObject gameObject)
    {
        return new IGB283Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }


    public static void SetGameObjectPosition(GameObject gameObject, IGB283Vector3 position)
    {
        gameObject.transform.position = new IGB283Vector3(position.x, position.y, position.z);
    }
}
