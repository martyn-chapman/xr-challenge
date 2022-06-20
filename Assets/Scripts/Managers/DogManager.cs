using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : Singleton<DogManager>
{
    [SerializeField] private GameObject dogObject;

    // Start is called before the first frame update
    public void HitResponse()
    {
        dogObject.GetComponent<DogController>().HitResponse();
    }
}
