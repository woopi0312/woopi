using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDuck : MonoBehaviour
{
    [SerializeField] GameObject _normalObj;
    [SerializeField] GameObject _duckObj;
    void Update()
    {
        if(Input.GetKey("c"))
        {
            ChangeObject();
        }
        if(Input.GetKeyUp("c"))
        {
            idle();
        }
    }

    void ChangeObject()
    {
        //CopyToRagdoll(_normalObj.transform, _duckObj.transform);
        _duckObj.SetActive(true);
        _normalObj.SetActive(false);
        //_duckObj.transform.position = _normalObj.transform.position; 
    }

    void idle()
    {
        _normalObj.SetActive(true);
        _duckObj.SetActive(false);
        _normalObj.transform.position = _duckObj.transform.position;
    }

    void CopyToRagdoll(Transform origin, Transform ragdoll)
    {
        for (int i = 0; i < origin.childCount; i++)
        {
            if (origin.childCount != 0)
            {
                CopyToRagdoll(origin.GetChild(i), ragdoll.GetChild(i));
            }
            ragdoll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            ragdoll.GetChild(i).localRotation = origin.GetChild(i).localRotation;
        }
    }
}
