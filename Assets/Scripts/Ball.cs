using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float startSpeed = 1f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    public bool isBallMoving = false;


    Transform arrow;

    void Start()
    {
        Application.targetFrameRate = 60;
        arrow = GameObject.FindGameObjectWithTag("Arrow").transform;
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;

    }

    public IEnumerator Shoot()
    {
        rb.constraints = RigidbodyConstraints.None;
        isBallMoving = true;
        arrow.gameObject.SetActive(false);
        rb.isKinematic = false;

        Vector3 forceVector = arrow.forward * (startSpeed * arrow.transform.localScale.z);

        Vector3 forcePos = transform.position + (transform.right * 0.5f);

        rb.AddForceAtPosition(forceVector, forcePos, ForceMode.Impulse);

        yield return new WaitForSecondsRealtime(5f);

        isBallMoving = false;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        arrow.gameObject.SetActive(true);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
