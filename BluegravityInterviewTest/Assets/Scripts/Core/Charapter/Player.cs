using BluegravityInterviewTest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BluegravityInterviewTest.Core.Charapter
{
    public class Player : Charapter
    {
        [SerializeField] private float _velocity;
        private float  _velocityRun;
        private Rigidbody2D _rigidbody2D;
        private GameObject _currentTriggered;
        private bool isHandlered;

        public static PlayerItems PlayerItems { get; private set; }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            PlayerItems = new PlayerItems();
        }
        // Update is called once per frame
        void Update()
        {
            float HMovement = Input.GetAxis("Horizontal");
            float VMovement = Input.GetAxis("Vertical");
            if(HMovement > 0)
            {
                gameObject.transform.localRotation = new Quaternion(0,180f,0,0);
            } else if(HMovement < 0) 
            {
                gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
            Vector2 movement = new Vector2(HMovement, VMovement);
            _rigidbody2D.velocity = movement * (_velocity + _velocityRun) ;

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag.Equals("Door"))
            {
                if(collision.gameObject.transform.parent.TryGetComponent<Build>(out Build build))
                {
                    build.EnterBuild();
                } else
                {
                    if (PlayerItems.CarIds.Count > 0)
                    {
                        ActionBoxes.Instance.Create("No te puedes ir sin pagar", 3);
                        return;
                    }
                    SceneManager.LoadScene(0);
                }
            }
            _currentTriggered = collision.gameObject;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _currentTriggered = null;
        }
        private void FixedUpdate()
        {
            _velocityRun = 0;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _velocityRun = 2;
            }
            if (_currentTriggered != null)
            {
                if (Input.GetKey(KeyCode.Space) && !isHandlered)
                {
                    isHandlered = true;
                    Handler();
                }
            }
            else
            {
                isHandlered = false;
            }
        }

        protected virtual void Handler()
        {
            if(_currentTriggered != null)
            {
                switch (_currentTriggered.tag)
                {
                    case "WardrobeShop":
                        PopUps.Instance.Show("Pickups");
                        break;
                    case "Buyer":
                        PopUps.Instance.Show("ShoppingCalc");
                        break;
                }
            }
            //_currentActionBox.transform.LeanScale(Vector3.one * .8f, .5f).setEaseOutBack().setOnComplete(() => { _currentActionBox.Hide(); });
        }


    }
}
