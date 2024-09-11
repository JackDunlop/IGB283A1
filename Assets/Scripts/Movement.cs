using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject firstDogGameObject1;

    
    private IGB283Vector3 pointOnePosition1;
    private IGB283Vector3 pointTwoPosition1;

    private GameObject firstDogGameObject2;


    private IGB283Vector3 pointOnePosition2;
    private IGB283Vector3 pointTwoPosition2;

    private GameObject pointOne1GameObject;
    private GameObject pointOne2GameObject;
    private GameObject pointTwo1GameObject;
    private GameObject pointTwo2GameObject;



    public float translationSpeed1 = 1f;
    public float translationSpeed2 = 10f;
    private float direction1 = 1f;
    private float direction2 = -1f;


    void Start()
    {
        firstDogGameObject1 = GameObject.Find("firstDog1");
        firstDogGameObject2 = GameObject.Find("firstDog2");
        pointOne1GameObject = GameObject.Find("pointOne1");
        pointOne2GameObject = GameObject.Find("pointOne2");
        pointTwo1GameObject = GameObject.Find("pointTwo1");
        pointTwo2GameObject = GameObject.Find("pointTwo2");
    }

    void Update()
    {

        BoxCollider2D pointOne1BoxCollider2D = pointOne1GameObject.GetComponent<BoxCollider2D>();
        IGB283Vector3 pointOne1PostionVector = pointOne1BoxCollider2D.bounds.center;

        BoxCollider2D pointOne2BoxCollider2D = pointOne2GameObject.GetComponent<BoxCollider2D>();
        IGB283Vector3 pointOne2PostionVector = pointOne2BoxCollider2D.bounds.center;

        BoxCollider2D pointTwo1BoxCollider2D = pointTwo1GameObject.GetComponent<BoxCollider2D>();
        IGB283Vector3 pointTwo1PostionVector = pointTwo1BoxCollider2D.bounds.center;

        BoxCollider2D pointTwo2BoxCollider2D = pointTwo2GameObject.GetComponent<BoxCollider2D>();
        IGB283Vector3 pointTwo2PostionVector = pointTwo2BoxCollider2D.bounds.center;


        IGB283Vector3 positionPointOne1 = new IGB283Vector3(67.5f, 22.5f, 0);

        IGB283Vector3 positionPointTwo1 = new IGB283Vector3(-67.5f, 22.5f, 0);

        IGB283Vector3 positionPointOne2 = new IGB283Vector3(67.5f, -22.5f, 0);

        IGB283Vector3 positionPointTwo2 = new IGB283Vector3(-67.5f, -22.5f, 0);



        BounceObjects(pointOne1PostionVector, pointTwo1PostionVector, firstDogGameObject1, ref direction1, translationSpeed1);
        BounceObjects(pointOne2PostionVector, pointTwo2PostionVector, firstDogGameObject2, ref direction2, translationSpeed2);


    }

    Color ColourBasedOnPosition(IGB283Vector3 currentPosition, IGB283Vector3 pointOne, IGB283Vector3 pointTwo)
    {
        float minX = Mathf.Min(pointOne.x, pointTwo.x);
        float maxX = Mathf.Max(pointOne.x, pointTwo.x);
        float t = Mathf.InverseLerp(minX, maxX, currentPosition.x);
        return Color.Lerp(Color.red, Color.blue, t);
    }

    void BounceObjects(IGB283Vector3 pointOne, IGB283Vector3 pointTwo, GameObject gameObject, ref float direction, float speed)
    {
        IGB283Vector3 currentPosition = GetObjectCenter(gameObject);

        IGB283Vector3 targetPosition = direction < 0 ? pointTwo : pointOne;
        //Debug.Log(targetPosition);

        IGB283Vector3 directionVector = (targetPosition - currentPosition).normalized;

        float distanceToMove = speed * Time.deltaTime;
        IGB283Vector3 movementVector = directionVector * distanceToMove;

     
        IGB283Transform.MoveObject(gameObject, movementVector);

        Color newColor = ColourBasedOnPosition(currentPosition, pointOne, pointTwo);
        gameObject.GetComponent<Renderer>().material.color = newColor;

        float distanceToTarget = IGB283Vector3.Distance(currentPosition, targetPosition);
    
        //Debug.Log($"Target Position: {targetPosition}");
        //Debug.Log($"Current Position: {currentPosition}");
        //Debug.Log($"Distance to Target: {distanceToTarget}");

      
        if (distanceToTarget <= 1)
        {
            direction *= -1;
          //  Debug.Log($"Direction changed to: {direction}");
        }
    }

    public IGB283Vector3 GetObjectCenter(GameObject gameObject)
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

