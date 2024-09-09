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

    public float translationSpeed = 5f;
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

        pointOnePosition1 = pointOneGameObject1.transform.position;
        pointTwoPosition1 = pointTwoGameObject1.transform.position;

        pointOnePosition2 = pointOneGameObject2.transform.position;
        pointTwoPosition2 = pointTwoGameObject2.transform.position;

        BounceObjects(pointOnePosition1, pointTwoPosition1, firstDogGameObject1, ref direction1);
        BounceObjects(pointOnePosition2, pointTwoPosition2, firstDogGameObject2, ref direction2);

     
    }

    void BounceObjects(IGB283Vector3 pointOne, IGB283Vector3 pointTwo, GameObject gameObject, ref float direction)
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

        targetPosition = new IGB283Vector3(targetPosition.x + 10, targetPosition.y + 20, targetPosition.z);
       
        IGB283Vector3 currentPosition = gameObject.transform.position;
        IGB283Vector3 directionVector = (targetPosition - currentPosition).normalized;

        gameObject.transform.position += directionVector * translationSpeed * Time.deltaTime;

        float distanceToTarget = IGB283Vector3.Distance(gameObject.transform.position, targetPosition);
        if (distanceToTarget < 0.3f)
        {
            direction *= -1;
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
}
