using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int poolAmount;

    public void Initialize()
    {
        CreateObjects(poolAmount);
    }

    void CreateObjects(int amount)
    {
        GameObject tempObject;

        for(int i = 0; i < amount; i++)
        {
            tempObject = Instantiate(objectToPool);
            tempObject.SetActive(false);
            pooledObjects.Add(tempObject);
        }
    }

    public GameObject GetPooledObject(Vector3 startPosition, Vector3 startRotation)
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = startPosition;
                pooledObjects[i].transform.rotation = Quaternion.Euler(startRotation);
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }

        // Create a new object if non are available
        GameObject newObject = Instantiate(objectToPool);
        pooledObjects.Add(newObject);
        return newObject;
    }
}
