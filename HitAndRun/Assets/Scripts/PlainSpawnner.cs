using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainSpawnner : MonoBehaviour
{
    public static PlainSpawnner Instance;

    Vector3 pos = new Vector3(0,0,0);
    OnjectPooler onjectPooler;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        onjectPooler = OnjectPooler.Instance;
        
    }
    public void spawn()
    {
        onjectPooler.spawnFormPool("Blue", pos, Quaternion.identity);
    }
    

    public void getNextTransform(Vector3 p)
    {
        pos = p;
    }
}
