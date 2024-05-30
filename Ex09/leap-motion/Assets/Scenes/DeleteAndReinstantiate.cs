using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAndReinstantiate : MonoBehaviour
{
    public GameObject[] items;

    private List<GameObject> instantiatedItems;

    // Start is called before the first frame update
    void Start()
    {
        instantiatedItems = new List<GameObject>();
        InstantiateAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateAll()
    {
        instantiatedItems.Clear();

        for(int i = 0; i< items.Length; i++)
        {
            instantiatedItems.Add(GameObject.Instantiate(items[i]));
        }

    }


    void DeleteAll()
    {
        foreach(var item in instantiatedItems)
        {
            Destroy(item);
        }

        instantiatedItems.Clear();

    }

    public void DeleteAndInstantiate()
    {
        DeleteAll();
        InstantiateAll();
    }

    public void Pressed()
    {
        Debug.Log("button ressed");
    }
}
