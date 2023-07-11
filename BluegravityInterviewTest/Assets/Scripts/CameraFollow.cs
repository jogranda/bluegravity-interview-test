using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluegravityInterviewTest
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float lerpSpeed = 1.0f;
        private Vector3 offset, targetPos;
        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
