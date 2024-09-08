using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameObjectSpeed : MonoBehaviour
{
    public float rotationSpeed;
}


public class Objects : MonoBehaviour
{
    public Material firstDogMaterial;
    private List<GameObject> firstDogGameObjects = new List<GameObject>();

    public Material pointOneMaterial;
    private List<GameObject> pointOneGameObjects = new List<GameObject>();

    public Material pointTwoMaterial;
    private List<GameObject> pointTwoGameObjects = new List<GameObject>();


    public float rotateSpeedOne = 500f;
    public float rotateSpeedTwo = 250;

    void CreateAndSetUpPointOne(string name)
    {
        IGB283Vector3[] pointOneVertices = new IGB283Vector3[]
        {
            new IGB283Vector3(10,20,0),
            new IGB283Vector3(5,20,0),
            new IGB283Vector3(10,25,0),
            new IGB283Vector3(5,25,0),
        };

        GameObject pointOne = CreateObjects(name, pointOneMaterial, pointOneVertices, new int[] { 3, 2, 1, 2, 0, 1 });
        SetInitialPosition(pointOne, 70, 20);
        pointOneGameObjects.Add(pointOne);

    }

    void CreateAndSetUpPointTwo(string name)
    {
        IGB283Vector3[] pointTwoVertices = new IGB283Vector3[]
        {
            new IGB283Vector3(-10,20,0),
            new IGB283Vector3(-5,20,0),
            new IGB283Vector3(-10,25,0),
            new IGB283Vector3(-5,25,0),
        };

        GameObject pointTwo = CreateObjects(name, pointTwoMaterial, pointTwoVertices, new int[] { 3, 2, 1, 2, 0, 1 });
        SetInitialPosition(pointTwo, -70, 20);
        pointTwoGameObjects.Add(pointTwo); 
    }

    void CreateAndSetUpDogObject(string name)
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


        GameObject firstDog = CreateObjects(name, firstDogMaterial, firstDogVertices, new int[] {
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
        GameObjectSpeed speedDog = firstDog.AddComponent<GameObjectSpeed>();
        speedDog.rotationSpeed = rotateSpeedOne; 
        firstDogGameObjects.Add(firstDog);

        foreach (GameObject go in firstDogGameObjects)
        {
            SetInitialPosition(go, 0, 20);
        }
        foreach (GameObject go in firstDogGameObjects)
        {
            go.transform.parent = this.transform;
        }
    }



    void Start()
    {

        switch (gameObject.name)
        {
            case "pointOne1":
                CreateAndSetUpPointOne(gameObject.name);
                break;
            case "pointTwo1":
                CreateAndSetUpPointTwo(gameObject.name);
                break;
            case "firstDog1":
                CreateAndSetUpDogObject(gameObject.name);
                break;

        }

    }

    void SetInitialPosition(GameObject gameObject, float x, float y)
    {
        if (gameObject != null)
        {

            gameObject.transform.position = new IGB283Vector3(x, y, 0);
        }
        else
        {
            Debug.LogError("The GameObject is null.");
        }
    }
    GameObject CreateObjects(string name, Material material, IGB283Vector3[] vertices, int[] triangles)
    {
        GameObject gameObject = new GameObject(name);
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh objectMesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = objectMesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        objectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        objectMesh.triangles = triangles;
        int triangleLength = triangles.Length;
        switch (name)
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
        }


        objectMesh.RecalculateNormals();
        objectMesh.RecalculateBounds();

        return gameObject;
    }

    void Update()
    {
        foreach (GameObject firstDog in firstDogGameObjects)
        {
            if (firstDog != null)
            {
                GameObjectSpeed speedComponent = firstDog.GetComponent<GameObjectSpeed>();
                if (speedComponent != null)
                {
                    IGB283Transform.RotateGameObject(firstDog, speedComponent.rotationSpeed * Time.deltaTime);
                }
            }
        }
    }


}
