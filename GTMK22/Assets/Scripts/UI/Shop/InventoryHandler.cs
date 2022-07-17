using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private List<BonusGoop> inventoryList;
    public List<RenderFaceEffectIcon> inventoryUI;
    public List<RenderFaceEffectIcon> lootList;
    private DieDatabase dieDatabase = new DieDatabase();
    // Start is called before the first frame update
    private void Awake()
    {
        this.inventoryList = FindObjectOfType<Player>().bits;
        for(int i = 0; i < 6; i++)
        {
            if (i < inventoryList.Count)
            {
                inventoryUI[i].UpdateFaceEffect(inventoryList[i]);
            }
            else
            {
                inventoryUI[i].MakeEmpty();
            }
        }
        for(int i = 0; i < lootList.Count; i++)
        {
            lootList[i].UpdateFaceEffect(dieDatabase.GetRandomGoop());
            Debug.Log("got random face goop");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
