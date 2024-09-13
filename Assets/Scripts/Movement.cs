using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject firstDogGameObject1;
    private IGB283Vector3[] orginalVerticesFirstDogGameObject1;


    private IGB283Vector3 pointOnePosition1;
    private IGB283Vector3 pointTwoPosition1;

    private GameObject firstDogGameObject2;
    private IGB283Vector3[] orginalVerticesFirstDogGameObject2;


    private IGB283Vector3 pointOnePosition2;
    private IGB283Vector3 pointTwoPosition2;

    private GameObject pointOne1GameObject;
    private GameObject pointOne2GameObject;
    private GameObject pointTwo1GameObject;
    private GameObject pointTwo2GameObject;



    public float translationSpeed1 = 100f;
    public float translationSpeed2 = 5f;

    public float rotation1Speed = 0.5f;
    public float rotation2Speed = 1f;

    private float direction1 = 1f;
    private float direction2 = -1f;


    void Start()
    {

        if(gameObject.name == "firstDog1")
        {
            firstDogGameObject1 = GameObject.Find("firstDog1");
            pointOne1GameObject = GameObject.Find("pointOne1");
            pointTwo1GameObject = GameObject.Find("pointTwo1");
       

            orginalVerticesFirstDogGameObject1 = GetOriginalVertices(firstDogGameObject1);
            IGB283Transform.MoveObject(pointOne1GameObject, new IGB283Vector3(67.5f, 22.5f, 0f));
            IGB283Transform.MoveObject(pointTwo1GameObject, new IGB283Vector3(-67.5f, 22.5f, 0f));
          
            
        }
        else
        {
            firstDogGameObject2 = GameObject.Find("firstDog2");
            pointOne2GameObject = GameObject.Find("pointOne2");
            pointTwo2GameObject = GameObject.Find("pointTwo2");
            orginalVerticesFirstDogGameObject2 = GetOriginalVertices(firstDogGameObject2);
            IGB283Transform.MoveObject(pointOne2GameObject, new IGB283Vector3(67.5f, -22.5f, 0f));
            IGB283Transform.MoveObject(pointTwo2GameObject, new IGB283Vector3(-67.5f, -22.5f, 0f));
        }





    }

    public static IGB283Vector3[] GetOriginalVertices(GameObject gameObject)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;
        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();
        return vertices; 
    }


    void Update()
    {


        if (gameObject.name == "firstDog1")
        {
       

            
            BounceObjects(GetObjectCenter(pointOne1GameObject), GetObjectCenter(pointTwo1GameObject), firstDogGameObject1, ref direction1, translationSpeed1, rotation1Speed, ref orginalVerticesFirstDogGameObject1);
          
        }
        else
        {


            BounceObjects(GetObjectCenter(pointOne2GameObject), GetObjectCenter(pointTwo2GameObject), firstDogGameObject2, ref direction2, translationSpeed2, rotation2Speed, ref orginalVerticesFirstDogGameObject2);
        }


     

      

      

  

        
        
    
    } 

   public IGB283Vector3 ScaleBasedOnPosition(IGB283Vector3 pointOne, IGB283Vector3 pointTwo, GameObject gameObject)
{
    IGB283Vector3 objectCenter = GetObjectCenter(gameObject);
    
    float minX = Mathf.Min(pointOne.x, pointTwo.x);
    float maxX = Mathf.Max(pointOne.x, pointTwo.x);


    float midpoint = (minX + maxX) / 2f;

    float t;
    if (objectCenter.x <= midpoint)
    {
        t = Mathf.InverseLerp(minX, midpoint, objectCenter.x);
        return IGB283Vector3.Lerp(new IGB283Vector3(0.5f, 0.5f, 0.5f), new IGB283Vector3(1f, 1f, 1f), t);
    }
    else
    {
        t = Mathf.InverseLerp(midpoint, maxX, objectCenter.x);
        return IGB283Vector3.Lerp(new IGB283Vector3(1f, 1f, 1f), new IGB283Vector3(2f, 2f, 2f), t);
    }
}



    Color ColourBasedOnPosition(IGB283Vector3 currentPosition, IGB283Vector3 pointOne, IGB283Vector3 pointTwo)
    {
        float minX = Mathf.Min(pointOne.x, pointTwo.x);
        float maxX = Mathf.Max(pointOne.x, pointTwo.x);
        float t = Mathf.InverseLerp(minX, maxX, currentPosition.x);
        return Color.Lerp(Color.red, Color.blue, t);
    }




    void BounceObjects(IGB283Vector3 pointOne, IGB283Vector3 pointTwo, GameObject gameObject, ref float direction, float translatingSpeed, float rotatingSpeed, ref IGB283Vector3[] orginalVertices)
    {
        IGB283Vector3 currentPosition = GetObjectCenter(gameObject);

        IGB283Vector3 targetPosition = direction < 0 ? pointTwo : pointOne;
        IGB283Vector3 directionVector = (targetPosition - currentPosition).normalized;
        float distanceToMove = translatingSpeed * Time.deltaTime;
        IGB283Vector3 movementVector = directionVector * distanceToMove;

        orginalVertices = IGB283Transform.TranslateVertices(orginalVertices, movementVector);
  
        orginalVertices = IGB283Transform.RotateVertices(orginalVertices, rotatingSpeed, GetObjectCenter(gameObject));

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh.vertices = orginalVertices.Select(v => (Vector3)v).ToArray();

        IGB283Vector3 scale = ScaleBasedOnPosition(pointOne, pointTwo, gameObject);
        IGB283Transform.Scale(gameObject, scale, orginalVertices);

        Color newColor = ColourBasedOnPosition(currentPosition, pointOne, pointTwo);
        gameObject.GetComponent<Renderer>().material.color = newColor;

        float distanceToTarget = IGB283Vector3.Distance(currentPosition, targetPosition);
        if (distanceToTarget <= 1)
        {
            direction *= -1;
        }
    }






    public static IGB283Vector3 GetObjectCenter(GameObject gameObject)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;
        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();
        IGB283Vector3 center = new IGB283Vector3(0, 0, 0);
        foreach (IGB283Vector3 vertex in vertices)
        {
            center += vertex;
        }
        center /= vertices.Length;
        return center;
    }



}