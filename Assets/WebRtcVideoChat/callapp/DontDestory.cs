using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
        
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
}
