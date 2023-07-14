using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace BluegravityInterviewTest.Core
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private Vector3 offset, targetPos;
        private void Start()
        {
            if (_target == null) return;
        }

        private void Update()
        {
            if (_target == null) return;
            targetPos = _target.position + offset;
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        }
        public void SetTarget(Transform target)
        {
            _target = target;
            offset = transform.position - _target.position;

        }
    }
}
