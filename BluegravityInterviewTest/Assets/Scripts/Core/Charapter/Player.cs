using BluegravityInterviewTest.UI;
using BluegravityInterviewTest.UI.Items;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BluegravityInterviewTest.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _upperClothing, _bottomClothing;
        [SerializeField] private float _movementVelocity, _scalingVelocity;
        private float _velocityRun;
        private Rigidbody2D _rigidbody2D;
        private GameObject _currentTriggered;
        private bool _isHandlered, _inRoom, _isMoving;
        private Vector2 onLoadScenePosition;
        public static bool InstructionsShowed { get; set; }

        public static PlayerData PlayerData { get; private set; }
        private Vector3 initialScale;
        private Vector3 targetScale;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _rigidbody2D = GetComponent<Rigidbody2D>();
            PlayerData = new PlayerData();
            Camera.main.GetComponent<MainCamera>().SetTarget(transform);
            SceneManager.sceneLoaded += OnSceneLoaded;
            initialScale = transform.localScale;
            targetScale = transform.localScale;
        }
        void Update()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            _isMoving = false;
            if (horizontalMovement != 0 || verticalMovement != 0)
            {
                _isMoving = true;
                if (horizontalMovement > 0)
                    gameObject.transform.localRotation = new Quaternion(0, 180f, 0, 0);
                else if (horizontalMovement < 0)
                    gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }

            if (_isMoving)
            {
                float scaleOffset = Mathf.Sin(Time.time * _scalingVelocity) * 0.1f;
                targetScale = initialScale + new Vector3(0, scaleOffset, 0);
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * _scalingVelocity);
            }
            Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
            _rigidbody2D.velocity = movement * (_movementVelocity + _velocityRun);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _currentTriggered = collision.gameObject;
            switch (_currentTriggered.tag)
            {
                case "Door":
                    if (_currentTriggered.gameObject.transform.parent.TryGetComponent(out Building build))
                    {
                        if (_inRoom)
                            ActionBoxes.Instance.Create(build.name + " (press space to exit)", 1.5f);
                        else
                            ActionBoxes.Instance.Create(build.name + " (press space to enter)", 1.5f);
                        if (PlayerData.CarIds.Count > 0)
                        {
                            ActionBoxes.Instance.Create("Pay before leave", 3);
                            return;
                        }
                    }
                    break;
                default:
                    _inRoom = true;
                    break;
            }
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
                if (Input.GetKey(KeyCode.Space) && !_isHandlered)
                {
                    _isHandlered = true;
                    Handler();
                }
                else
                    _isHandlered = false;
            _upperClothing.color = ClothingList.GetClotingList().FirstOrDefault(clothing => clothing.Id.Equals(PlayerData.UpperClothingId)).Color;
            if (PlayerData.BottomClothingId != null)
                _bottomClothing.color = ClothingList.GetClotingList().FirstOrDefault(clothing => clothing.Id.Equals(PlayerData.BottomClothingId)).Color;
        }

        protected virtual void Handler()
        {
            if (_currentTriggered != null)
            {
                switch (_currentTriggered.tag)
                {
                    case "WardrobeShop":
                        PopUps.Instance.Show("Pickups");
                        break;
                    case "WardrobeMine":
                        PopUps.Instance.Show("InventoryClothes");
                        break;
                    case "Buyer":
                        PopUps.Instance.Show("ShoppingCalc");
                        break;
                    case "Door":
                        if (PlayerData.CarIds.Count > 0) return;
                        _currentTriggered.gameObject.transform.parent.TryGetComponent(out Building build);
                        if (_inRoom)
                        {
                            onLoadScenePosition = build.LevingPosition;
                            _inRoom = false;
                            SceneManager.LoadScene(0);
                        }
                        else
                        {
                            onLoadScenePosition = build.EnteringPosition;
                            _inRoom = true;
                            Village.Instance.EnterBuild(build);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Camera.main.GetComponent<MainCamera>().SetTarget(transform);
            SetPosition(onLoadScenePosition);
            Items.Instance.UpdateItems();
        }
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}
