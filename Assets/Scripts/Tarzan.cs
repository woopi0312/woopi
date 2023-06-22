using Unity.VisualScripting;
using UnityEngine;

public class Tarzan : MonoBehaviour
{
    [SerializeField] GameObject _basket; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if(collision.transform.GetComponent<PlayerMove>() != null)
            {
                collision.transform.GetComponent<PlayerMove>().addFixedJoint(_basket);
            }          
        }
    }
}
