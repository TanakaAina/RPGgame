using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    // リストに入れるために生成するプレファブ
    public GameObject ListObject;
    // プレファブを入れるリスト
    public List<GameObject> ObjectList = new List<GameObject>();
    // 生成したプレファブの数
    private int ObjectCount;
    
}
