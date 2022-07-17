using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    private List<BonusGoop>[] shopList;
    public List<RenderFaceEffectIcon> shopUI;
    public List<RenderFaceEffectIcon> shopLootList;
    private DieDatabase dieDatabase = new DieDatabase();
    // Start is called before the first frame update
    private void Awake()
    {
        //for (int i =0; i < 6; i++)
        //{
        //    this.shopList[i] = dieDatabase.GetRandomGoop();
        //    if (i < shopList.Count)
        //    {
        //        shopUI[i].UpdateFaceEffect(shopList[i]);
        //    }
        //    else
        //    {
        //        shopUI[i].MakeEmpty();
        //    }
        //}
        //for (int i = 0; i < shopList.Count; i++)
        //{
        //    shopLootList[i].UpdateFaceEffect(dieDatabase.GetRandomGoop());
        //}
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
