using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Valve.VR.InteractionSystem;

public class sliceObject : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LayerMask slacableLayer;
    public VelocityEstimator velocityEstimator;
    public Material crossSection;
    public float cutForce;


    // Update is called once per frame
    void FixedUpdate()
    {
        bool hashit = Physics.Linecast(startPoint.position, endPoint.position, out RaycastHit hit, slacableLayer);

        if (hashit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endPoint.position - startPoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endPoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSection);
            GameObject lowerHull = hull.CreateLowerHull(target, crossSection);

            setUpComponent(upperHull);
            setUpComponent(lowerHull);

            Destroy(target);
        }
    }
    public void setUpComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;

        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
    }
}
