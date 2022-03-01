using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnBtn_ShowScrollView()
    {
        AddressableUtility.InstantiateAsync("HeroUI",Vector3.zero,Quaternion.identity,null, (instance) =>
        {
            Debug.Log("Load UI Success.");
        });   
    }
}
