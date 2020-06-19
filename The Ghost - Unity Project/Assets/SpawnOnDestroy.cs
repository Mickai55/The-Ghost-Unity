using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{

    [SerializeField] GameObject finalThing;
    private void OnDestroy()
    {
        Instantiate(finalThing);
    }

}
