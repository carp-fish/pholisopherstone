using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Collider2D[] inExplosionRadius = null;

    [SerializeField] private float explosionForceMulti = 5;
    [SerializeField][Range(0f, 10)] private float explosionRadius = 5;
    [SerializeField][Range(0f, 1)] private float isForwardRange = 0.6f;
    [SerializeField][Range(0f, 1)] private float isUpRange = 0.4f;
    [SerializeField][Range(0f, 1)] private float decayRate = 1;
    [SerializeField] private float forwardXMulti = 1;
    [SerializeField] private float forwardYMulti = 1;
    [SerializeField] private float upXMulti = 1;
    [SerializeField] private float upYMulti = 1;


    public LayerMask MovableObj;
    public Rigidbody2D objRB;

    private void Update() {
         if(Input.GetKeyDown(KeyCode.N)){
            Explode(decayRate);
        }
    }

    protected void Explode(float decayRate)
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position , explosionRadius , MovableObj);

        foreach(Collider2D obj in inExplosionRadius)
        {
            objRB = obj.GetComponent<Rigidbody2D>();

            if(objRB != null)
            {
                Vector2 distanceVector = obj.transform.position - transform.position;

                Debug.Log(distanceVector.normalized);

                if(distanceVector.magnitude > 0)
                {

                    float explosionForce = explosionForceMulti / (distanceVector.magnitude*decayRate);
                    if(Mathf.Pow(distanceVector.normalized.x , 2) >= isForwardRange)
                    {
                        objRB.AddRelativeForce(new Vector2(distanceVector.normalized.x * forwardXMulti , distanceVector.normalized.y * forwardYMulti) * explosionForce , ForceMode2D.Impulse);
                    }
                    else if(Mathf.Pow(distanceVector.normalized.x , 2) <= isUpRange)
                    {
                        objRB.AddRelativeForce(new Vector2(distanceVector.normalized.x * upXMulti , distanceVector.normalized.y * upYMulti) * explosionForce , ForceMode2D.Impulse);
                    }
                    else
                    {
                        objRB.AddRelativeForce(distanceVector.normalized * explosionForce , ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position , explosionRadius);    
    }
    public void OnCollisionExplode()
    {
        Explode(1);
    }
}
