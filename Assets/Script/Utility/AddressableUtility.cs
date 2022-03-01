using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableUtility
{
    public static void InstantiateAsync(string keyName,Vector3 position,Quaternion rotation,Transform parent,Action<GameObject> callback)
    {
        var operation = Addressables.InstantiateAsync(keyName,Vector3.zero,Quaternion.identity,parent);
        operation.Completed += (handler) =>
        {
            var instance = handler.Result as GameObject;
            if(callback != null)
                callback.Invoke(instance);
        };
    }

    public static bool UnInstantiate(GameObject instance)
    {
        return Addressables.ReleaseInstance(instance);
    }
}
