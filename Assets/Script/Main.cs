using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddressableUtility.InstantiateAsync("HeroUI",Vector3.zero,Quaternion.identity,null, (instance) =>
        {
            Debug.Log("Load UI Success.");
        });   
    }
}
