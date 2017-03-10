using UnityEngine;
using System.Collections;

public class RemoveSelf : MonoBehaviour
{

    public float _DestroyTime;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DestroyTime);
        Destroy(gameObject);
    }
}

