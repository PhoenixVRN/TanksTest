using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reference 
{
    public static Transform ActiveElements => _activeElements != null ? _activeElements : _activeElements = GameObject.FindObjectOfType<TagFolderActiveElements>().transform;
    private static Transform _activeElements;
}
