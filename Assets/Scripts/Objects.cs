using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;




public class Objects : MonoBehaviour
{
    public Material firstDogMaterial;
    public GameObject firstDogGameObject1;
    public GameObject firstDogGameObject2;

    public Material points;
    public GameObject pointOne1GameObjects;
    public GameObject pointOne2GameObjects;
    public GameObject pointTwo1GameObjects;
    public GameObject pointTwo2GameObjects;



    void CreateAndSetUpPointOne(GameObject gameObject)
    {
        IGB283Vector3[] pointOneVertices = new IGB283Vector3[]
        {
            new IGB283Vector3(10,20,0),
            new IGB283Vector3(5,20,0),
            new IGB283Vector3(10,25,0),
            new IGB283Vector3(5,25,0),
        };


        CreateObjects(gameObject, points, pointOneVertices, new int[] { 3, 2, 1, 2, 0, 1 }, 0.8f, 0.3f, 0.3f);
        
    }

    void CreateAndSetUpDogObject(GameObject gameObject)
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
            }, 0.8f, 0.3f, 0.3f);
      
       

    }


    private void Awake()
    {
        if (firstDogGameObject1 != null)
        {
            CreateAndSetUpDogObject(firstDogGameObject1);
        }
        if (firstDogGameObject2 != null)
        {
            CreateAndSetUpDogObject(firstDogGameObject2);
        }
        if (pointOne1GameObjects != null)
        {
            CreateAndSetUpPointOne(pointOne1GameObjects);
        }
        if (pointTwo1GameObjects != null)
        {
            CreateAndSetUpPointOne(pointTwo1GameObjects);
        }
        if (pointOne2GameObjects != null)
        {
            CreateAndSetUpPointOne(pointOne2GameObjects);
        }
        if (pointTwo2GameObjects != null)
        {
            CreateAndSetUpPointOne(pointTwo2GameObjects);
        }
    }

    void Start()
    {

      


    }


    void CreateObjects(GameObject gameObject, Material material, IGB283Vector3[] vertices, int[] triangles, float r, float b, float g)
    {

        gameObject.AddComponent<MeshCollider>();
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh objectMesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = objectMesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        objectMesh.vertices = vertices.Select(v => (Vector3)v).ToArray();
        objectMesh.triangles = triangles;


        Color[] colours = new Color[vertices.Length];
        Color colourValues = new Color(r, g, b);
        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = colourValues;
        }
        objectMesh.colors = colours;



        objectMesh.RecalculateNormals();
        objectMesh.RecalculateBounds();
    }

    void Update()
    {

      
     
    }

}

