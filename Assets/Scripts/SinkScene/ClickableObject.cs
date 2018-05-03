using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    public Rigidbody2D rb;
    public ObjectSlot pairedSlot;
    public float snapSpeed;
    public SinkManager owner;
    bool link;



    void Update()
    {
        if(link)
        {
            Vector2 toTarget = pairedSlot.transform.position - transform.position;
            if(toTarget.magnitude < snapSpeed * Time.deltaTime)
            {
                transform.position = new Vector3(pairedSlot.transform.position.x, pairedSlot.transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                link = false;
            }
            else
            {
                transform.position += (Vector3)toTarget.normalized * snapSpeed * Time.deltaTime;
            }
        }
    }

    public void PickUp()
    {
        if(pairedSlot != null)
        {
            pairedSlot.occupied = false;
            rb.gravityScale = 1;
            link = false;
            rb.constraints = RigidbodyConstraints2D.None;
            owner.placedObjects--;

        }
    }

    public void PutDown()
    {
        if(pairedSlot != null)
        {
            link = true;
            rb.gravityScale = 0;
            rb.velocity *= 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            owner.placedObjects++;
            if(owner.placedObjects == owner.numObjects && owner.positiveAction)
            {
                owner.EndGame();
            }
        }
        else
        {
            if(owner.obstructions <= 0 && !owner.positiveAction)
            {
                owner.EndGame();
            }
        }
    }

	
}
