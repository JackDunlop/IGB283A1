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
    private float direction = 1f;
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

        IGB283Vector3 targetPosition1 = (IGB283Vector3)(direction > 0 ? pointTwoPosition1 : pointOnePosition1);
        IGB283Vector3 directionVector1 = (targetPosition1 - firstDogGameObject1.transform.position).normalized;

        firstDogGameObject1.transform.position += directionVector1 * translationSpeed * Time.deltaTime;

        if (IGB283Vector3.Distance(firstDogGameObject1.transform.position, targetPosition1) < 0.5f)
        {
            direction *= -1;
        }

     
        IGB283Vector3 targetPosition2 = (IGB283Vector3)(direction2 > 0 ? pointOnePosition2: pointTwoPosition2);
        IGB283Vector3 directionVector2 = (targetPosition2 - firstDogGameObject2.transform.position).normalized;

        firstDogGameObject2.transform.position += directionVector2 * translationSpeed * Time.deltaTime;

        if (IGB283Vector3.Distance(firstDogGameObject2.transform.position, targetPosition2) < 1f)
        {
            direction2 *= -1;
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


