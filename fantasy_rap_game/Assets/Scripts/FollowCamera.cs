/*
 * Name: Jackson Miller
 * Date: 9/27/23
 * Desc: Camera that follows the target gameobject
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Following camera basics
    [Tooltip("Set this to the object to follow in the inspector.")]
    public GameObject target;
    [Tooltip("Value between 0 and 1 for how snappy the camera is. (1 is no Lerp)")]
    [Range(0f, 1f)]
    public float smoothVal = 0.5f;
    // Screen shake variables
    private float shakeDuration = 0.0f;
    private float shakeDurationStart = 0.0f;
    private float shakeMag = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void StartShake(float duration, float magnitude)
    {
        if(duration > shakeDuration)
        {
            shakeDurationStart = duration;
            shakeDuration = duration;
        }
        if(magnitude > shakeMag)
        {
            shakeMag = magnitude;
        }
    }
    // Update is called once per physics frame
    void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 targetPos;
            if (Input.GetKey(KeyCode.Space))
            {
                targetPos = (target.transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition)) / 2;
            }
            else
            {
                targetPos = (target.transform.position);
            }
            targetPos.z = transform.position.z;
            // Handle screen shake
            if(shakeDuration > 0.0f)
            {
                shakeDuration -= Time.fixedDeltaTime;
                Vector3 randShake = Random.insideUnitCircle * Mathf.Lerp(shakeMag, 0, 1 - (shakeDuration/shakeDurationStart));
                targetPos += randShake;
            }
            else
            {
                shakeMag = 0;
            }

            // Lerp the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothVal);
        }
    }
}
