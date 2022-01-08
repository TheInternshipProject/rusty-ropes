using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootTableEntryAsset{
    [HideInInspector]public string name;
    public string lootItem;
    public float dropChance=0f;
}
[System.Serializable]
public class ItemPercentageObstacles{
    [HideInInspector]public string name;
}
public class LootTableObstacles : MonoBehaviour{
    [SerializeField]public List<LootTableEntryAsset> itemList;
    private Dictionary<string, float> itemTable;
    [SerializeField] List<float> dropList;
    [SerializeField] ItemPercentageObstacles[] itemsPercentage;
    public float sum;
    
    void OnValidate(){SumUp();}
    private void Update() {
        //if(UpgradeMenu.instance!=null)currentLvl=UpgradeMenu.instance.total_UpgradesLvl;
        //else currentLvl=-4;
        SumUp();
        SumUpAfter();
    }
    public GameObject GetItem(){
        float randomWeight = 0;
        do{//No weight on any number?
            if(sum==0)return null;
            randomWeight=Random.Range(0,sum);
        }while(randomWeight==sum);
        var i=-1;
        foreach(LootTableEntryAsset entry in itemList){
            i++;
            if(randomWeight<dropList[i])return GameAssets.instance.Get(entry.lootItem);
            randomWeight-=dropList[i];
        }
        return null;
    }

    void SumUp(){
        if(dropList.Count<itemList.Count){
        dropList=new List<float>(itemList.Count);
        itemTable=new Dictionary<string,float>();
        var i=-1;
        System.Array.Resize(ref itemsPercentage, itemList.Count);
        foreach(LootTableEntryAsset entry in itemList){
            i++;
            dropList.Add(entry.dropChance);
            //if(!GameRules.instance.levelingOn){entry.levelReq=0;}
            //if(currentLvl<entry.levelReq&&currentLvl!=-4&&GameRules.instance.levelingOn)dropList[i]=0;
            entry.name=entry.lootItem;
            
            itemTable.Add(
                entry.lootItem,
            (float)dropList[i]);
            var value=System.Convert.ToSingle(System.Math.Round((dropList[i]/sum*100),2));
                if(entry!=null&&itemsPercentage!=null&&itemsPercentage[i]!=null){
                    itemsPercentage[i].name=
                    entry.name+
                    " - "+value+"%"+" - "+
                    dropList[i]+"/"+
                    (sum-dropList[i]);
                }
        }
        sum=dropList.Sum();
        System.Array.Resize(ref itemsPercentage, itemList.Count);
        }
    }
    void SumUpAfter(){
        if(dropList.Count<itemList.Count){dropList.Capacity=itemList.Capacity;}
        var i=-1;
        foreach(LootTableEntryAsset entry in itemList){
            i++;
            //if(!GameRules.instance.levelingOn){entry.levelReq=0;}
            //if(currentLvl<entry.levelReq&&GameRules.instance.levelingOn)dropList[i]=0;
            
            var value=System.Convert.ToSingle(System.Math.Round((dropList[i]/sum*100),2));
                if(entry!=null&&itemsPercentage!=null&&itemsPercentage[i]!=null){
                    itemsPercentage[i].name=
                    entry.name+
                    " - "+value+"%"+" - "+
                    dropList[i]+"/"+
                    (sum-dropList[i]);
                }
        }
        sum=dropList.Sum();
    }
}
