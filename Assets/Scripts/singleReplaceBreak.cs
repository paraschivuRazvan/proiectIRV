using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleReplaceBreak : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform brokenObject;
    public float collisionMagnitudeSR;
    public float radiusSR;
    public float powerSR;
    public float upwardsSR;

    private void OnCollisionEnter(Collision collision)
    {
        // verificare magnitudine coliziune
        if (collision.relativeVelocity.magnitude > collisionMagnitudeSR)
        {
            AudioManager.PlaySFX(AudioResources.Instance.target_break);

            // distruge obiectul actual si instantiaza obiectul din bucati
            Destroy(gameObject);
            Instantiate(brokenObject, transform.position, transform.rotation);

            // obtinere punct de contact
            ContactPoint contact = collision.contacts[0];
            Vector3 explosionPos = contact.point;

            //adaugare rotatie
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);

            // salvare coliziuni intre componente intr-o raza fata de punctul de contact
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radiusSR);

            // adaugare forta de explosie pentru fiecare coliziune in raza punctului de contact
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(powerSR * collision.relativeVelocity.magnitude, explosionPos, radiusSR, upwardsSR);
                }
            }
        }
    }
}
