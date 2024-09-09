using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject firstDogGameObject1;

    private GameObject pointOneGameObject1;
    private GameObject pointTwoGameObject1;

    private IGB283Vector3 pointOnePosition1;
    private IGB283Vector3 pointTwoPosition1;



    private GameObject firstDogGameObject2;

    private GameObject pointOneGameObject2;
    private GameObject pointTwoGameObject2;

    private IGB283Vector3 pointOnePosition2;
    private IGB283Vector3 pointTwoPosition2;

    public float translationSpeed1 = 100f;
    public float translationSpeed2 = 10f;
    private float direction1 = 1f;
    private float direction2 = -1f;

    void Start()
    {

        firstDogGameObject1 = GameObject.Find("firstDog1");
        pointOneGameObject1 = GameObject.Find("pointOne1");
        pointTwoGameObject1 = GameObject.Find("pointTwo1");


        firstDogGameObject2 = GameObject.Find("firstDog2");
        pointOneGameObject2 = GameObject.Find("pointOne2");
        pointTwoGameObject2 = GameObject.Find("pointTwo2");

      



    }

    void Update()
    {


        Rigidbody rigidBodyFirstDog1 = firstDogGameObject1.GetComponent<Rigidbody>();
        IGB283Vector3 positionFirstDog1 = rigidBodyFirstDog1.position;


        Rigidbody rigidBodyFirstDog2 = firstDogGameObject2.GetComponent<Rigidbody>();
        IGB283Vector3 positionFirstDog2 = rigidBodyFirstDog2.position;

        Rigidbody rigidBodyPointOne1 = pointOneGameObject1.GetComponent<Rigidbody>();
        IGB283Vector3 positionPointOne1 = rigidBodyPointOne1.position;

        Rigidbody rigidBodyPointTwo1 = pointTwoGameObject1.GetComponent<Rigidbody>();
        IGB283Vector3 positionPointTwo1 = rigidBodyPointTwo1.position;

        Rigidbody rigidBodyPointOne2 = pointOneGameObject2.GetComponent<Rigidbody>();
        IGB283Vector3 positionPointOne2 = rigidBodyPointOne2.position;

        Rigidbody rigidBodyPointTwo2 = pointTwoGameObject2.GetComponent<Rigidbody>();
        IGB283Vector3 positionPointTwo2 = rigidBodyPointTwo2.position;

        BounceObjects(positionPointOne1, positionPointTwo1, firstDogGameObject1, ref direction1, translationSpeed1);
        BounceObjects(positionPointOne2, positionPointTwo2, firstDogGameObject2, ref direction2, translationSpeed2);

     
    }

    void BounceObjects(IGB283Vector3 pointOne, IGB283Vector3 pointTwo, GameObject gameObject, ref float direction, float speed)
    {
        IGB283Vector3 targetPosition;
        if (gameObject == firstDogGameObject1)
        {
            targetPosition = direction < 0 ? pointTwo : pointOne;
        }
        else
        {
            targetPosition = direction > 0 ? pointTwo : pointOne;
        }

        targetPosition = new IGB283Vector3(targetPosition.x + 10, targetPosition.y + 20, 0);

        Rigidbody gameObjectRB = gameObject.GetComponent<Rigidbody>();
       

        IGB283Vector3 currentPosition = gameObjectRB.position;
        IGB283Vector3 directionVector = (targetPosition - currentPosition).normalized;

        gameObjectRB.MovePosition(currentPosition + directionVector * speed * Time.deltaTime);

        float distanceToTarget = IGB283Vector3.Distance(currentPosition, targetPosition);
        if (distanceToTarget < 1f)
        {
            direction *= -1;
        }
    }

}
