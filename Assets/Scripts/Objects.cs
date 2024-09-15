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
            new IGB283Vector3(-36,10,0),
            new IGB283Vector3(-36,-8,0),
            new IGB283Vector3(40,-8,0),
            new IGB283Vector3(40,10,0),
            new IGB283Vector3(-38,10,0),
            new IGB283Vector3(-16,10,0),
            new IGB283Vector3(-16,12,0),
            new IGB283Vector3(-38,12,0),
            new IGB283Vector3(-38,14,0),
            new IGB283Vector3(-18,12,0),
            new IGB283Vector3(-18,14,0),
            new IGB283Vector3(-36,14,0),
            new IGB283Vector3(-20,14,0),
            new IGB283Vector3(-20,16,0),
            new IGB283Vector3(-36,16,0),
            new IGB283Vector3(-22,18,0),
            new IGB283Vector3(-32,16,0),
            new IGB283Vector3(-22,16,0),
            new IGB283Vector3(-38,2,0),
            new IGB283Vector3(-36,-14,0),
            new IGB283Vector3(-38,-14,0),
            new IGB283Vector3(-38,0,0),
            new IGB283Vector3(-38,-10,0),
            new IGB283Vector3(-40,-10,0),
            new IGB283Vector3(-38,-4,0),
            new IGB283Vector3(-40,-4,0),
            new IGB283Vector3(-36,-12,0),
            new IGB283Vector3(-18,-8,0),
            new IGB283Vector3(-18,-12,0),
            new IGB283Vector3(-20,-12,0),
            new IGB283Vector3(-20,-14,0),
            new IGB283Vector3(-36,-16,0),
            new IGB283Vector3(-22,-14,0),
            new IGB283Vector3(-22,-16,0),
            new IGB283Vector3(-32,-16,0),
            new IGB283Vector3(-26,-18,0),
            new IGB283Vector3(-26,-16,0),
            new IGB283Vector3(-32,-18,0),
            new IGB283Vector3(42,10,0),
            new IGB283Vector3(42,12,0),
            new IGB283Vector3(20,10,0),
            new IGB283Vector3(20,12,0),
            new IGB283Vector3(22,14,0),
            new IGB283Vector3(22,12,0),
            new IGB283Vector3(42,14,0),
            new IGB283Vector3(24,14,0),
            new IGB283Vector3(40,16,0),
            new IGB283Vector3(40,14,0),
            new IGB283Vector3(24,16,0),
            new IGB283Vector3(26,18,0),
            new IGB283Vector3(36,16,0),
            new IGB283Vector3(26,16,0),
            new IGB283Vector3(36,18,0),
            new IGB283Vector3(40,2,0),
            new IGB283Vector3(42,2,0),
            new IGB283Vector3(42,0,0),
            new IGB283Vector3(42,-4,0),
            new IGB283Vector3(40,-4,0),
            new IGB283Vector3(40,0,0),
            new IGB283Vector3(44,-10,0),
            new IGB283Vector3(44,-4,0),
            new IGB283Vector3(40,-10,0),
            new IGB283Vector3(22,-10,0),
            new IGB283Vector3(40,-12,0),
            new IGB283Vector3(22,-12,0),
            new IGB283Vector3(40,-14,0),
            new IGB283Vector3(24,-12,0),
            new IGB283Vector3(24,-14,0),
            new IGB283Vector3(26,-14,0),
            new IGB283Vector3(26,-16,0),
            new IGB283Vector3(40,-16,0),
            new IGB283Vector3(36,-18,0),
            new IGB283Vector3(36,-16,0),
            new IGB283Vector3(30,-16,0),
            new IGB283Vector3(42,-10,0),
            new IGB283Vector3(42,-14,0),
            new IGB283Vector3(-32,18,0),
            new IGB283Vector3(-36,0,0),
            new IGB283Vector3(-38,0,0),
            new IGB283Vector3(-36,2,0),
            new IGB283Vector3(22,-8,0),
            new IGB283Vector3(30,-18,0),

        };


        CreateObjects(gameObject, points, pointOneVertices, 
            new int[] {
           0,3,2,
           0,2,1,
           76,15,16,
           15,17,16,
           14,13,11,
           13,12,11,
           8,10,9,
           8,9,7,
           7,6,4,
           4,6,5,
           4,0,18,
           0,79,18,
           78,77,19,
           21,19,20,
           25,24,23,
           24,22,23,
           1,27,26,
           27,28,26,
           26,27,28,
           26,29,30,
           26,30,19,
           19,32,31,
           32,33,31,
           34,36,35,
           34,35,37,
           49,52,50,
           49,50,51,
           48,46,45,
           45,46,47,
           42,44,39,
           41,39,40,
           40,39,38,
           3,38,53,
           38,54,53,
           58,55,57,
           55,56,57,
           57,60,59,
           57,59,61,
           61,74,75,
           51,75,65,
           62,61,63,
           62,63,64,
           66,61,63,
           62,63,64,
           66,63,65,
           66,65,67,
           61,74,75,
           61,75,65,
           42,39,43,
           62,2,61,
           80,2,62,
           68,65,69,
           69,65,70,
           73,72,71,
           73,71,81
        
        }
            
            , 217f, 217f, 217f);
        
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


    void Awake()
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

