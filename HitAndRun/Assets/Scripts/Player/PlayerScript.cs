using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rigidbody;
    private List<GenericScript> Behaviours;
    private int CurBehaviours;
    private int DefaultBehaviour;
    private float Horizontal, Vertical;
    private float Falling;
    private bool Grounded;
    private Vector3 colExtents;
    void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidbody = GetComponent<Rigidbody>();
        Behaviours = new List<GenericScript>();
        colExtents = GetComponent<Collider>().bounds.extents;
    }

    //common functions
    public bool IsGrounded()
	{
		Ray ray = new Ray(this.transform.position + Vector3.up * 2 * colExtents.x, Vector3.down);
		return Physics.SphereCast(ray, colExtents.x, colExtents.x + 0.2f);
	}
    public float FallDistance()
    {
        RaycastHit hit;
        if (!Grounded)
        {
            if (Physics.Raycast(this.transform.position, Vector3.down, out hit))
            {
                float x = hit.distance;
                return x;
            }
        }
        return 0;
    }
    
}

public abstract class GenericScript : MonoBehaviour
{
    protected PlayerScript manager;
    protected int HashCode;
    private void Awake()
    {
        manager = GetComponent<PlayerScript>();
        HashCode = this.GetType().GetHashCode();
    }
}