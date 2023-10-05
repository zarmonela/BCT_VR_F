#region Includes
using UnityEngine;
#endregion

namespace TS.GazeInteraction.Demo
{

    public class GazeInteractableDemo : MonoBehaviour
    {
        #region Variables

        [Header("Configuration")]
        public float _speed;
        public float _radius;

        public VRSpawner objectSpawner;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;

        #endregion

        private void Start()
        {
            _initialPosition = transform.position;

            Reset();
        }
        private void Update()
        {
            //transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
            //if(transform.position == _targetPosition)
            //{
            //    _targetPosition = _initialPosition + Random.insideUnitSphere * _radius;
            //}
        }

        public void Enable()
        {
            enabled = true;
            objectSpawner.isLocked = true;
        }
        public void Reset()
        {
            // transform.position = _initialPosition;
            //    _targetPosition = _initialPosition;
            objectSpawner.isLocked = false;
            enabled = false;
        }
    }
}