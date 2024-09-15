using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    private static GameObject currentlyDraggedObject = null; 

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

    private MouseControl mouseControlPointOne1;
    private MouseControl mouseControlPointOne2;
    private MouseControl mouseControlPointTwo1;
    private MouseControl mouseControlPointTwo2;

    private float translationSpeed1 = 100f;
    private float translationSpeed2 = 5f;

    private float rotation1Speed = 0.5f;
    private float rotation2Speed = 1f;

    private float maxRotation = 10f;
    private float minRotation = 0f;
    private float rotationChange = 1f;

    public float FirstDog1Rotation
    {
        get { return rotation1Speed; }
        set { rotation1Speed = Mathf.Clamp(value, minRotation, maxRotation); }
    }
    public float FirstDog2Rotation
    {
        get { return rotation2Speed; }
        set { rotation2Speed = Mathf.Clamp(value, minRotation, maxRotation); }
    }



    private float direction1 = 1f;
    private float direction2 = -1f;

    private float maxSpeed = 200f;
    private float minSpeed = 0f;
    private float speedChange = 10f;

    public float FirstDog1Speed
    {
        get { return translationSpeed1; }
        set { translationSpeed1 = Mathf.Clamp(value, minSpeed, maxSpeed); }
    }
    public float FirstDog2Speed
    {
        get { return translationSpeed2; }
        set { translationSpeed2 = Mathf.Clamp(value, minSpeed, maxSpeed); }
    }


    [SerializeField] private AudioClip dogMunchingSoundClip;
    private AudioSource audioSourceMunching;
    
    [SerializeField] private AudioClip valueMinOrMaxedSoundClip;
    private AudioSource audioSourceValueMinOrMaxe;




    void Start()
    {


        if(gameObject.name == "firstDog1")
        {
            firstDogGameObject1 = GameObject.Find("firstDog1");
            pointOne1GameObject = GameObject.Find("pointOne1");
            pointTwo1GameObject = GameObject.Find("pointTwo1");
            orginalVerticesFirstDogGameObject1 = GetOriginalVertices(firstDogGameObject1);
            IGB283Transform.MoveObject(pointOne1GameObject, new IGB283Vector3(87.5f, 22.5f, 0f));
            IGB283Transform.MoveObject(pointTwo1GameObject, new IGB283Vector3(-87.5f, 22.5f, 0f));
            mouseControlPointOne1 = new MouseControl(GetObjectCenter(pointOne1GameObject));
            mouseControlPointTwo1 = new MouseControl(GetObjectCenter(pointTwo1GameObject));
            IGB283Transform.Scale(pointOne1GameObject, new IGB283Vector3(0.25f,0.25f,0.25f), GetOriginalVertices(pointOne1GameObject));
            IGB283Transform.Scale(pointTwo1GameObject, new IGB283Vector3(0.25f,0.25f,0.25f), GetOriginalVertices(pointTwo1GameObject));
        }
        else
        {
            firstDogGameObject2 = GameObject.Find("firstDog2");
            pointOne2GameObject = GameObject.Find("pointOne2");
            pointTwo2GameObject = GameObject.Find("pointTwo2");
            orginalVerticesFirstDogGameObject2 = GetOriginalVertices(firstDogGameObject2);
            IGB283Transform.MoveObject(pointOne2GameObject, new IGB283Vector3(87.5f, -22.5f, 0f));
            IGB283Transform.MoveObject(pointTwo2GameObject, new IGB283Vector3(-87.5f, -22.5f, 0f));
            mouseControlPointOne2 = new MouseControl(GetObjectCenter(pointOne2GameObject));
            mouseControlPointTwo2 = new MouseControl(GetObjectCenter(pointTwo2GameObject));
            IGB283Transform.Scale(pointOne2GameObject, new IGB283Vector3(0.25f, 0.25f, 0.25f), GetOriginalVertices(pointOne2GameObject));
            IGB283Transform.Scale(pointTwo2GameObject, new IGB283Vector3(0.25f, 0.25f, 0.25f), GetOriginalVertices(pointTwo2GameObject));
        }

        audioSourceMunching = GetComponent<AudioSource>();  
        audioSourceValueMinOrMaxe = GetComponent<AudioSource>();
        



    }

    public static IGB283Vector3[] GetOriginalVertices(GameObject gameObject)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh gameObjectMesh = meshFilter.mesh;
        IGB283Vector3[] vertices = gameObjectMesh.vertices.Select(v => (IGB283Vector3)v).ToArray();
        return vertices; 
    }
    private void pointMovement(GameObject gameObject, MouseControl mouseControl)
    {

        if (currentlyDraggedObject == null || currentlyDraggedObject == gameObject)
        {
            mouseControl.MouseClickAction();

            (IGB283Vector3 mousePos, bool isMoving) = mouseControl.GetModifiedValues();
            IGB283Vector3 gameObjectsCurrentPosition = GetObjectCenter(gameObject);

            if (isMoving && mousePos != null)
            {
                currentlyDraggedObject = gameObject; 

                IGB283Vector3 newYPosition = new IGB283Vector3(gameObjectsCurrentPosition.x, mousePos.y, 0);

                IGB283Transform.MoveObject(gameObject, newYPosition - GetObjectCenter(gameObject));
                mouseControl.UpdateGameObjectPosition(GetObjectCenter(gameObject));
            }
            else if (!isMoving)
            {
                currentlyDraggedObject = null; 
            }
        }
    }

    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FirstDog1Speed += speedChange;
            if(FirstDog1Speed == maxSpeed)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FirstDog1Speed -= speedChange;
            if (FirstDog1Speed == minSpeed)
            {
               
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            FirstDog2Speed += speedChange;
            if (FirstDog2Speed == maxSpeed)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FirstDog2Speed -= speedChange;
            if (FirstDog2Speed == minSpeed)
            {

                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FirstDog1Rotation += rotationChange;
            if (FirstDog1Rotation == maxRotation)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FirstDog1Rotation -= rotationChange;
            if (FirstDog1Rotation == minRotation)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            FirstDog2Rotation += rotationChange;
            if (FirstDog2Rotation == maxRotation)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FirstDog2Rotation -= rotationChange;
            if (FirstDog2Rotation == minRotation)
            {
                audioSourceValueMinOrMaxe.clip = valueMinOrMaxedSoundClip;
                audioSourceValueMinOrMaxe.Play();
            }
        }

        switch (gameObject.name)
        {
            case "firstDog1":

                pointMovement(pointOne1GameObject, mouseControlPointOne1);
                pointMovement(pointTwo1GameObject, mouseControlPointTwo1);
                BounceObjects(GetObjectCenter(pointOne1GameObject), GetObjectCenter(pointTwo1GameObject), firstDogGameObject1, ref direction1, translationSpeed1, rotation1Speed, ref orginalVerticesFirstDogGameObject1);
                break;
            case "firstDog2":

                pointMovement(pointOne2GameObject, mouseControlPointOne2);
                pointMovement(pointTwo2GameObject, mouseControlPointTwo2);
                BounceObjects(GetObjectCenter(pointOne2GameObject), GetObjectCenter(pointTwo2GameObject), firstDogGameObject2, ref direction2, translationSpeed2, rotation2Speed, ref orginalVerticesFirstDogGameObject2);
                break;
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


            audioSourceMunching.clip = dogMunchingSoundClip;
            audioSourceMunching.Play();
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