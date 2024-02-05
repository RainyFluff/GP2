using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFlow : MonoBehaviour
{
    [SerializeField] private float strength = 5;
    void OnTriggerStay(Collider other) {
        other.GetComponent<Rigidbody>().AddForce(transform.forward * strength, ForceMode.Force);        
    }
}
