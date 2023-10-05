using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TS.GazeInteraction;
using TS.GazeInteraction.Demo;
using System.Diagnostics;
using OVR;
using UnityEngine.Events;

public class VRSpawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public float spawnRadius = 3.0f;
    // private TargetHandler targetHandler;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private GameObject currentTarget;
    GazeInteractableDemo gazeDemo;
    public GameObject targetObject;
    public float sphereRadius = 8f;
    private bool isMoving = false;
    public bool lockTarget = false;
    //public UnityEvent onActivateShouldMove;
    //public GameObject groundObject;
    public bool isLocked = false;


    //public void LockTargetOn()
    //{
    //    lockTarget = true;
    //}
    //public void LockTargetOff()
    //{
    //    lockTarget = false;
    //}
    void Start()
    {
        gazeDemo = targetObject.GetComponent<GazeInteractableDemo>();
        //   targetHandler = GetComponent<TargetHandler>();
        SpawnObjects();
        MarkRandomTarget();
    }

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.One) && isLocked)
        {
            // MarkRandomTarget();
            MarkRandomTarget();
            //isLocked = false;
        }
    }

    //public void StartMove(bool shouldMove)
    //{
    //    if (shouldMove && !isMoving)
    //    {
    //        StartCoroutine(MoveToNewPosition());
    //    }
    //}

    public void MoveToNewPositionInstantly()
    {
        //lockTarget = false;
        isMoving = true;
        targetObject.SetActive(false);
        gazeDemo.Reset();
        Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * sphereRadius;
        randomPosition.y = Mathf.Max(0, randomPosition.y);  // Ensure Y is never below 0
        targetObject.transform.position = randomPosition;
        targetObject.SetActive(true);
        isMoving = false;
    }



    void MarkRandomTarget()
    {
        targetObject.SetActive(false);
        Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * sphereRadius;
        randomPosition.y = Mathf.Max(0, randomPosition.y);  // Ensure Y is never below 0
        targetObject.transform.position = randomPosition;
        targetObject.SetActive(true);
        isLocked = false;
    }

    void SpawnObjects()
    {
        spawnedObjects.Clear();
        for (int i = 0; i < 25; i++)
        {
            Vector3 randomPos = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
            if (randomPos.y < 0) { randomPos.y = 0; }
            GameObject objectToSpawn = UnityEngine.Random.Range(0, 2) == 0 ? spherePrefab : cubePrefab;
            GameObject spawned = Instantiate(objectToSpawn, randomPos, Quaternion.identity);
            spawnedObjects.Add(spawned);
        }
    }


}
