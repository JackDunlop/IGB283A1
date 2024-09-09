using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameObjectSpeed : MonoBehaviour
{
    public float rotationSpeed;
}


public class Objects : MonoBehaviour
{
    public Material firstDogMaterial;
    public GameObject firstDogGameObject1;
    public GameObject firstDogGameObject2;



    public Material pointOneMaterial;
    public GameObject pointOneGameObject1;
    public GameObject pointOneGameObject2;
    

    public Material pointTwoMaterial;
    public GameObject pointTwoGameObject1;
    public GameObject pointTwoGameObject2;
 


    void CreateAndSetUpPointOne(GameObject gameObject,float initialX, float initialY)
    {
        IGB283Vector3[] pointOneVertices = new IGB283Vector3[]
        {
            new IGB283Vector3(10,20,0),
            new IGB283Vector3(5,20,0),
            new IGB283Vector3(10,25,0),
            new IGB283Vector3(5,25,0),
        };

        
        CreateObjects(gameObject, pointOneMaterial, pointOneVertices, new int[] { 3, 2, 1, 2, 0, 1 });
        SetInitialPosition(gameObject, initialX, initialY);



    }

    void CreateAndSetUpPointTwo(GameObject gameObject, float initialX, float initialY)
    {
        IGB283Vector3[] pointTwoVertices = new IGB283Vector3[]
        {
            new IGB283Vector3(10,20,0),
            new IGB283Vector3(5,20,0),
            new IGB283Vector3(10,25,0),
            new IGB283Vector3(5,25,0),
        };

        CreateObjects(gameObject, pointTwoMaterial, pointTwoVertices, new int[] { 3, 2, 1, 2, 0, 1 });
        SetInitialPosition(gameObject, initialX, initialY);

    }

    void CreateAndSetUpDogObject(GameObject gameObject,float rotationSpeed, float initialX, float initialY)
    {
        IGB283Vector3[] firstDogVertices = new IGB283Vector3[] {
                new IGB283Vector3(0,0,0),
                new IGB283Vector3(-1,-8,0),
                new IGB283Vector3(4,-8,0),
                new IGB283Vector3(4,1,0),
                new IGB283Vector3(7,-2,0),
                new IGB283Vector3(8,-7,0),
                new IGB283Vector3(4.5f,-7,0),
                new IGB283Vector3(0,-9,0),
                new IGB283Vector3(-7,-8,0),
                new IGB283Vector3(-9,-3,0),
                new IGB283Vector3(-10,-7,0),
                new IGB283Vector3(-13,-6,0),
                new IGB283Vector3(-12,-9,0),
                new IGB283Vector3(-7,-9,0),
                new IGB283Vector3(-12,1,0),
                new IGB283Vector3(-10,3,0),
                new IGB283Vector3(-10,5,0),
                new IGB283Vector3(-12,4,0),
                new IGB283Vector3(-9,9,0),
                new IGB283Vector3(0,4,0),
                new IGB283Vector3(-6,1,0),
                new IGB283Vector3(6,3,0),
                new IGB283Vector3(3,11,0),
                new IGB283Vector3(6,7,0),
                new IGB283Vector3(4,11,0),
                new IGB283Vector3(5,10.5f,0),
                new IGB283Vector3(4,13,0),
                new IGB283Vector3(5,13,0),
                new IGB283Vector3(8,9,0),
                new IGB283Vector3(8,4,0),
                new IGB283Vector3(9,7,0),
                new IGB283Vector3(10,9,0),
                new IGB283Vector3(11,3,0),
                new IGB283Vector3(10,7,0),
                new IGB283Vector3(9.5f,8,0),
                new IGB283Vector3(6,10,0),
                new IGB283Vector3(6,10.5f,0),
                new IGB283Vector3(7,10.25f,0)
                 };

        CreateObjects(gameObject, firstDogMaterial, firstDogVertices, new int[] {
                0,1,2,
                0,1,8,
                0,9,8,
                0,9,20,
                15,20,9,
                15,9,14,
                16,15,14,
                16,14,17,
                18,16,17,
                15,19,20,
                19,0,20,
                14,9,11,
                9,8,10,
                9,10,11,
                11,8,12,
                8,13,12,
                1,2,7,
                0,3,2,
                3,4,2,
                4,5,6,
                6,5,2,
                21,4,3,
                19,21,3,
                19,3,0,
                22,21,19,
                22,23,21,
                24,23,22,
                26,24,22,
                27,25,24,
                25,23,24,
                25,36,35,
                36,37,35,
                25,28,23,
                28,29,23,
                28,30,29,
                28,31,30,
                34,33,30,
                33,32,30,
                30,32,29
            });
        GameObjectSpeed speedDog = gameObject.AddComponent<GameObjectSpeed>();
        speedDog.rotationSpeed = rotationSpeed;
        SetInitialPosition(gameObject, initialX, initialY);



    }



    void Start()
    {


        if (firstDogGameObject1 != null)
        {
            CreateAndSetUpDogObject(firstDogGameObject1, 500f, 0f, 0f);
        }
        if (firstDogGameObject2 != null)
        {
            CreateAndSetUpDogObject(firstDogGameObject2, 250f, 0f, 0f);
        }
        if (pointOneGameObject1 != null)
        {
            CreateAndSetUpPointOne(pointOneGameObject1 ,70f, 20f);
        }
        if (pointOneGameObject2 != null)
        {
            CreateAndSetUpPointOne(pointOneGameObject2, -70f, -20f);
        }
        if (pointTwoGameObject1 != null)
        {
            CreateAndSetUpPointTwo(pointTwoGameObject1, -70f, 20f);
        }
        if (pointTwoGameObject2 != null)
        {
            CreateAndSetUpPointTwo(pointTwoGameObject2, 70f, -20f);
        }

    }
   
    void SetInitialPosition(GameObject gameObject, float x, float y)
    {
        if (gameObject != null)
        {
            Rigidbody gameObjectRB = gameObject.GetComponent<Rigidbody>();
            gameObjectRB.MovePosition(new IGB283Vector3(x, y, 0));
        }
        else
        {
            Debug.LogError("The GameObject is null.");
        }
    }
    void CreateObjects(GameObject gameObject, Material material, IGB283Vector3[] vertices, int[] triangles)
    {

        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh objectMesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = objectMesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        objectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        objectMesh.triangles = triangles;
        int triangleLength = triangles.Length;
        switch (gameObject.name)
        {
            case "firstDog1":
                Color[] firstDogColours = new Color[vertices.Length]; 
                Color firstDogColourValue = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < firstDogColours.Length; i++)
                {
                    firstDogColours[i] = firstDogColourValue;
                }
                objectMesh.colors = firstDogColours;
                break;
            case "pointOne1":
                Color[] pointOneColours = new Color[vertices.Length];
                Color pointOneColourValue = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < pointOneColours.Length; i++)
                {
                    pointOneColours[i] = pointOneColourValue;
                }
                objectMesh.colors = pointOneColours;
                break;
            case "pointTwo1":
                Color[] pointTwoColours = new Color[vertices.Length];
                Color pointTwoColourValue = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < pointTwoColours.Length; i++)
                {
                    pointTwoColours[i] = pointTwoColourValue;
                }
                objectMesh.colors = pointTwoColours;
                break;
            case "firstDog2":
                Color[] firstDogColours2 = new Color[vertices.Length];
                Color firstDogColourValue2 = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < firstDogColours2.Length; i++)
                {
                    firstDogColours2[i] = firstDogColourValue2;
                }
                objectMesh.colors = firstDogColours2;
                break;
            case "pointOne2":
                Color[] pointOneColours2 = new Color[vertices.Length];
                Color pointOneColourValue2 = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < pointOneColours2.Length; i++)
                {
                    pointOneColours2[i] = pointOneColourValue2;
                }
                objectMesh.colors = pointOneColours2;
                break;
            case "pointTwo2":
                Color[] pointTwoColours2 = new Color[vertices.Length];
                Color pointTwoColourValue2 = new Color(0.8f, 0.3f, 0.3f, 1.0f);
                for (int i = 0; i < pointTwoColours2.Length; i++)
                {
                    pointTwoColours2[i] = pointTwoColourValue2;
                }
                objectMesh.colors = pointTwoColours2;
                break;
        }


        objectMesh.RecalculateNormals();
        objectMesh.RecalculateBounds();
    }

    void Update()
    {

        if (firstDogGameObject1 != null)
        {
            ObjectRotater(firstDogGameObject1);
           
        }
        if (firstDogGameObject2 != null)
        {
            ObjectRotater(firstDogGameObject2);
        }


    }

    void ObjectRotater(GameObject gameObject)
    {
        GameObjectSpeed speedComponent = gameObject.GetComponent<GameObjectSpeed>();
        if (speedComponent != null)
        {
            IGB283Transform.RotateGameObject(gameObject, speedComponent.rotationSpeed * Time.deltaTime);
        }
    }
}



