using Unity.VisualScripting;
using UnityEngine;

public class Tarzan : MonoBehaviour
{
    [SerializeField] GameObject _basket; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<FixedJoint2D>() == null)
            {
                FixedJoint2D _joint = collision.transform.AddComponent<FixedJoint2D>();
                _joint.connectedBody = _basket.GetComponent<Rigidbody2D>();
                _joint.autoConfigureConnectedAnchor = false;
            }
        }
    }
}
