using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] PoolObject[] poolObjects;

    List<GameObject> pool = new List<GameObject>();
    int next;

    private void Awake()
    {
        next = 0;
        Populate();
        DisableAll();
        Shuffle();
    }

    // Fill the pool with instances
    void Populate ()
    {
        foreach (PoolObject poolObject in poolObjects)
        {
            for (int i = 0; i < poolObject.frequency; i++)
            {
                pool.Add(Instantiate(poolObject.prefab, transform));
            }
        }
    }

    public void DisableAll ()
    {
        foreach (GameObject gameObject in pool)
        {
            gameObject.SetActive(false);
        }
    }

    // Shuffle the pool
    public void Shuffle ()
    {
        for (int i = pool.Count - 1; i >=1; i--)
        {
            int j = Random.Range(0, i);
            GameObject temp = pool[j];
            pool[j] = pool[i];
            pool[i] = temp;
        }
    }

    // Return the next object in line
    public GameObject GetNext ()
    {
        GameObject gameObject = pool[next];
        next++;
        if (next >= pool.Count)
            next = 0;
        return gameObject;
    }

   
}
