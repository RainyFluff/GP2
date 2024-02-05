using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour, IKayakEntity
{
    [Header("Paddle")]
    [SerializeField] private float paddleStrength = 10f;
    [SerializeField] private float rotationStrength = 5f;
    [SerializeField] private float lateralStrength = 2f;    
    
    [Header("Speed")]
    [SerializeField] private float maxHorizontalVelocity = 5;

    public bool leftPaddleActive = false;
    public bool rightPaddleActive = false;

    private Kayak kayak;
    
    void Start() {
        Initialize(null);        
    }

    void Update() {
        if (GetComponent<Kayak>() == null) {
            OnUpdate(Time.deltaTime);
        }
    }

    void FixedUpdate() {
        if (GetComponent<Kayak>() == null) {
            OnFixedUpdate(Time.fixedDeltaTime);
        }
    }

    public void Initialize(Kayak kayak)
    {
        if (kayak != null) {
            this.kayak = kayak as Kayak;
        } else {
            var rb = GetComponent<Rigidbody>();
        }        
    }

    public void OnUpdate(float dt)
    {
        // Check for key presses
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J))
        {
            leftPaddleActive = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L))
        {
            rightPaddleActive = true;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.J)) {
            leftPaddleActive = false;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.L))
        {
            rightPaddleActive = false;
        }        
    }

    public void OnFixedUpdate(float dt)
    {
        // Apply forces based on paddle input
        if (leftPaddleActive)
        {
            ApplyPaddleForce(transform.forward * paddleStrength + transform.right * lateralStrength, -rotationStrength);
            // leftPaddleActive = false;
        }
        if (rightPaddleActive)
        {
            ApplyPaddleForce(transform.forward * paddleStrength - transform.right * lateralStrength, rotationStrength);
            // rightPaddleActive = false;
        }
    }

    private void ApplyPaddleForce(Vector3 force, float rotation)
    {
        if (kayak != null) {
            if (kayak.rb.velocity.magnitude < maxHorizontalVelocity) {
                kayak.rb.AddForce(force, ForceMode.Force);                
            }
            kayak.rb.AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Force);
        } else {
            if (GetComponent<Rigidbody>().velocity.magnitude < maxHorizontalVelocity) {
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
            }            
            GetComponent<Rigidbody>().AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Force);
        }
    }     

    #if UNITY_EDITOR
    void OnGUI() {

    }
    #endif
}
