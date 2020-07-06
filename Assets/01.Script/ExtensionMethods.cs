using UnityEngine;

public static class ExtensionMethdos{
    public static void Log(this object value){
        Debug.Log(value.ToString());
    }    
}