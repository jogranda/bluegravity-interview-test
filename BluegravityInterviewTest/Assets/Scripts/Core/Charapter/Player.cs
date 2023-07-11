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
        private Rigidbody2D _rigidbody2D;

        public static PlayerItems PlayerItems { get; private set; }

        private void Awake()
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
            _rigidbody2D.velocity = (movement * _velocity) * transform.localScale.x;
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
                    if (PlayerItems.Car.Count > 0)
                    {
                        ActionBoxes.Instance.Create("No te puedes ir sin pagar", 3);
                        return;
                    }
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
