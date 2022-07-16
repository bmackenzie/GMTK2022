using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRunner: MonoBehaviour
{
    public int numberOfLoots = 3;
    public GameObject lootPrefab;
    public List<GameObject> lootList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDropNumber(int numberLoots)
    {
        numberOfLoots = numberLoots;
        GenerateLoots();
    }

    void GenerateLoots()
    {
        for (int i = 0; i < numberOfLoots; i++)
        {
            this.lootList.Add(Instantiate(lootPrefab));
            // TODO: Set position???
        }
    }

    public void onLootSelected()
    {
        // Highlight loot
        // enable button continue
    }
}
