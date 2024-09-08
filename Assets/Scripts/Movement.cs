using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{




    private GameObject firstDogGameObject;

    private GameObject pointOneGameObject;
    private GameObject pointTwoGameObject;

    private IGB283Vector3 pointOnePosition;
    private IGB283Vector3 pointTwoPosition;

    public float translationSpeed = 100f;
    private float direction = 1f;
    private IGB283Vector3 currentTranslation;

    void Start()
    {

        firstDogGameObject = GameObject.Find("firstDog1");
        pointOneGameObject = GameObject.Find("pointOne1");
        pointTwoGameObject = GameObject.Find("pointTwo1");

        SetInitialPosition(pointOneGameObject, 70, 20);
        SetInitialPosition(pointTwoGameObject, -70, 20);

        pointOnePosition = pointOneGameObject.transform.position;
        pointTwoPosition = pointTwoGameObject.transform.position;


      

    }

    void Update()
    {
        IGB283Vector3 targetPosition = (IGB283Vector3)(direction > 0 ? pointTwoPosition : pointOnePosition);
        IGB283Vector3 directionVector = (targetPosition - firstDogGameObject.transform.position).normalized;

        firstDogGameObject.transform.position += directionVector * translationSpeed * Time.deltaTime;

        if (IGB283Vector3.Distance(firstDogGameObject.transform.position, targetPosition) < 0.1f)
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


