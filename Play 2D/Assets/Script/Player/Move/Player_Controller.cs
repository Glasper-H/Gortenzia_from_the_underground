using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Controller : AUDIO
{
    public static bool Key1 = false;
    public static bool KeyToLVL2 = false;

    [SerializeField]
    private Image _HpBar;
    private float _timer = 0.125f;
    private bool _checkHp = true;
    private float _armor = 100;
    public static float HP;
    public static float maxHP = 40;
    private float _oldHpValue;
    float ScaleHP;
    private bool _doReHp = true;
    private bool _ReDam = false;

    public GameObject DiedCanvas;
    bool OnDied = true;

    [SerializeField]
    private Image _StaminaBar;
    private float _ScaleStam;
    public static float Stam;
    public static float maxStam = 100;
    private bool _regenStamJump = true;
    private bool _regenStamSlide = true;
    private bool _regenStamHit = true;
    private bool _regenStam = false;

    public static float boostregenManaAndStamina = 1;

    [SerializeField]
    private Image _ManaBar;
    private float _ScaleMana;
    public static float Mana;
    public static float maxMana = 100;
    private bool _regenManaHit = true;
    private bool _regenMana = false;

    public static int NumMoney = 0;
    [SerializeField]
    private TMP_Text NumMoneyHud;

    public string sceneName;
    private Player _player;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private Animator _anim;
    public static bool pauseOk = true;
    private Vector3 _pos;
    private Camera _main;
    public static bool StopAction = false;

    private float _jump = 18;
    private float _boostJump = 1;
    [SerializeField]
    private int _amountJump = 1;

    [SerializeField]
    private bool _isGround;
    private float _groundRadius = 0.5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public LayerMask plateMask;
    public static bool OnGround;

    [SerializeField]
    public static float MoveInput;
    private float _upDownMove = 0;
    private bool _moveUp = false;
    private bool _moveDown = false;
    private float _speed = 15;
    private float _boostSpeed = 1;
    public static float SpeedX;
    private float _slideBoost = 1;
    private bool _doSlide = true;
    public static bool wallIn = false;
    private bool _doSlow = false;
    [SerializeField]
    private GameObject collDown;

    public static bool onGrab = false;

    public static bool useOrNot = false;
    public static bool _useOrNot = false;

    private bool _doHit = true;
    public GameObject Slash;


//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public static bool learnedMagicBall = false; //Измените значение на true чтобы использовать навык "Магический шар"
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public static bool learnedMagicSword = false;



    public bool doUp = false;
    public bool checkInt;

    [SerializeField]
    private GameObject _pauseCanvas;
    public static bool OnPause = false;
    [SerializeField]
    private bool _doPause = false;

    private float _maxCoolDownUltra = 40;
    private float _CoolDownUltra;
    [SerializeField]
    private Image UltraBar;
    [SerializeField]
    public Light2D global;

    private Vector2 Aim;
    public static float AimX;
    public static float AimY;
    [SerializeField]
    private Transform _invisibleCurT;
    [SerializeField]
    private GameObject _defInputSystem;
    [SerializeField]
    private GameObject _cur;
    public static bool IsVisCur1 = true;
    [SerializeField]
    private GameObject _visCur1;
    public float offset;
    [SerializeField]
    private GameObject _lineShoot;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shotPoint;
    [SerializeField]
    private bool _mattack = true;
    [SerializeField]
    private GameObject _magicBallLight;
    [SerializeField]
    private bool _onSpawnMagBall = true;

    [SerializeField]
    CinemachineVirtualCamera _camera2_1k;
    [SerializeField]
    private GameObject _c2_1k;
    [SerializeField]
    private GameObject _1kTarget;
    [SerializeField]
    private GameObject Hud;
    [SerializeField]
    private GameObject CursorB;

    private bool go = true;
    [SerializeField]
    private GameObject Player;
    int katStop = 1;
    bool KatBoolStop = false;
    private Vector3 OldPosition;
    public static bool doMove = false;
    private bool g = true;
    private bool h = true;
    [SerializeField]
    private AudioSource _walking;
    private bool _isPlate;
    private bool _speedFall;
    [SerializeField]
    private GameObject FallDam;
    [SerializeField]
    private GameObject RayDown;
    private bool MoveSlow = false;
    public LayerMask Enemy;
    [SerializeField]
    private GameObject UpColl;
    private bool DamTime = false;

    Vector3 lastPos;
    Vector3 currentPos;


    public static float PosX = -389;
    public static float PosY = -131.5f;

    public static float EasyPosX = -389;
    public static float EasyPosY = -131.5f;


    private bool _slideAnim = false;
    private bool _deathAnim = false;
    private bool _finalDeathAnim = false;
    private bool _attackAnim = false;
    private bool _dashAttackAnim = false;
    private bool _useAnim = false;
    private bool _hurtAnim = false;
    private bool _magicAttackAnim = false;
    private bool _StopAnim = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        _player = new Player();
        if (Save.LearnMagicSword == 1)
        {
            learnedMagicSword = true;
        }

        lastPos = Player.transform.position;

        _player.Move.Jump.performed += context => Jump();
        _player.Move.Interaction.performed += context => useOrNot = true;
        _player.Move.Interaction.performed += context => _useOrNot = true;
        _player.Move.Slide.performed += context => Slide();
        _player.Move.Hit.performed += context => Hit();
        _player.Move.SlowMovement.performed += Context => SlowSwitch();
        _player.Move.Up.performed += context => doUp = true;
        _player.Move.Up.canceled += context => doUp = false;
        _player.Move.Pause.performed += context => Pause();
        _player.Move.Ultra.performed += context => UseUltra();
        _player.Move.Shoot.canceled += context => Shoot();
        _player.Move.SpeedFall.canceled += context => SpeedFall();
    }
    private void Start()
    {
        HP = maxHP;
        Stam = maxStam;
        Mana = maxMana;
        NumMoney = 0;
        _CoolDownUltra = _maxCoolDownUltra;
        global.intensity = 0.22f;
        UltraBar.fillAmount = 1;
        global.intensity = 0.22f;
        katStop = 1;
        KatBoolStop = false;

        StopAction = false;
        OnPause = false;
        Vector3 OldPosition = transform.position;

        _main = FindObjectOfType<Camera>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        Slash.SetActive(false);

        collDown.SetActive(true);
        Invoke("StartSave", 0.01f);

        if (Setting.SaveEasyModeOP == 1)
        {
            Player.transform.localPosition = new Vector2(EasyPosX, EasyPosY);
        }
        else if (Setting.SaveEasyModeOP == 0)
        {
            Player.transform.localPosition = new Vector2(PosX, PosY);
        }
    }
    private void Update()
    {
        if (DamTime == true)
        {
            Invoke("DamTimeRe", 0.30f);
        }

        if (GamepadSwitch.GamepadOn == false)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            _lineShoot.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else if (GamepadSwitch.GamepadOn == true)
        {
            Vector3 diff2 = _invisibleCurT.position - transform.position;
            float rotZ2 = Mathf.Atan2(diff2.y, diff2.x) * Mathf.Rad2Deg;
            _lineShoot.transform.rotation = Quaternion.Euler(0f, 0f, rotZ2 + offset);
        }

        if (OldPosition.x != transform.position.x)
        {
            doMove = true;
        }
        else 
        { 
            doMove = false; 
        }
        OldPosition = transform.position;

        if (doMove == true && _isGround == true && _isPlate == false && _doSlide == true && _doSlow == false)
        {
            if (h == true)
            {
                Invoke("HH", 0.01f);
            }
        }
        else if (_isGround == true && _isPlate == true && _doSlide == true && _doSlow == false)
        {
            if (MoveInput != 0)
            {
                if (h == true)
                {
                    Invoke("HH", 0.01f);
                }
            }
        }
        else if (doMove == true && _isGround == true && _isPlate == false && _doSlide == true && _doSlow == true)
        {
            if (h == true)
            {
                Invoke("HH2", 0.01f);
            }
        }
        else if (_isGround == true && _isPlate == true && _doSlide == true && _doSlow == true)
        {
            if (MoveInput != 0)
            {
                if (h == true)
                {
                    Invoke("HH2", 0.01f);
                }
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(RayDown.transform.position, Vector2.down, 0.3f, groundMask);
        if (hit)
        {
            MoveSlow = false;
        }
        else MoveSlow = true;

        if (_speedFall == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -75);
            FallDam.SetActive(true);
        }
        if (_isGround == true)
        {
            _speedFall = false;
            FallDam.SetActive(false);
        }

        if (Player.transform.position.x >= 26 && go == true && Key1 == false)
        {
            _1kTarget.SetActive(true);
            _c2_1k.SetActive(true);
            _camera2_1k.m_Priority = 20;
            katStop = 0;
            KatBoolStop = true;
            Hud.SetActive(false);
            CursorB.SetActive(false);
            go = false;
            _StopAnim = true;
            Invoke("ReKat1", 7f);
        }

        if (IsVisCur1 == true)
        {
            _visCur1.SetActive(true);
            _cur.SetActive(false);
        }
        else if (IsVisCur1 == false)
        {
            _visCur1.SetActive(false);
            _cur.SetActive(true);
        }

        if (GamepadSwitch.GamepadOn == true)
        {
            _cur.transform.localPosition += new Vector3(0, AimY * 16, 0);
            if (AimX > 0)
            {
                _cur.gameObject.transform.localPosition = new Vector2(500, _cur.transform.localPosition.y);
            }
            else if (AimX < 0)
            {
                _cur.gameObject.transform.localPosition = new Vector2(-500, _cur.transform.localPosition.y);
            }
            if (_cur.gameObject.transform.localPosition.y >= 520)
            {
                _cur.gameObject.transform.localPosition = new Vector2(_cur.transform.localPosition.x, 520);
            }
            else if (_cur.gameObject.transform.localPosition.y <= -520)
            {
                _cur.gameObject.transform.localPosition = new Vector2(_cur.transform.localPosition.x, -520);
            }
        }

        {
            Scene currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
            if (sceneName == "LVL1")
            {
                GameManager.NumberLvl = 1;
            }
        }
        {
            InvokeRepeating("CheckHpValue", 0f, 0.2f);
            if (HP < _oldHpValue)
            {
                _hurtAnim = true;
                Invoke("Hurt_play", 0.01f);
                Invoke("StopHurtAnim", 0.25f);
            }
        }

        {
            CheckHP();
            if (HP < maxHP && _checkHp == true && _doReHp == true && StopAction == false)
            {
                Invoke("regenHP", _timer);
                _checkHp = false;
            }
            if (HP <= 0)
            {
                Time.timeScale = 0;
                _defInputSystem.SetActive(false);
                _deathAnim = true;
                Invoke("StopDeathAnim", 0.8f);
                StopAction = true;
                KatBoolStop = true;
                Invoke("TimeStop", 1.75f);
                pauseOk = false;
                katStop = 0;
            }
            else
            {
                pauseOk = true;
                StopAction = false;
            }
        }
        {
            CheckStam();
            if (Stam < 0)
            {
                Stam = 0;
            }
            if (Stam < maxStam && StopAction == false)
            {
                if (_regenStamJump == true && _regenStamSlide == true && _regenStamHit == true && _regenStam == true)
                {
                    Invoke("RegenStam", 0.00762f);
                }
                _regenStam = true;
            }
            if (Stam >= maxStam)
            {
                Stam = maxStam;
                _regenStam = false;
            }
        }
        {
            CheckMana();
            if (Mana < 0)
            {
                Mana = 0;
            }
            if (Mana < maxMana && StopAction == false)
            {
                if (_regenManaHit == true && _regenMana == true)
                {
                    Invoke("RegenMana", 0.00762f);
                }
                _regenMana = true;
            }
            if (Mana >= maxMana)
            {
                Mana = maxMana;
                _regenMana = false;
            }
        }
        {
            if (OnPause == true)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                _pauseCanvas.SetActive(true);
                StopAction = true;
            }
            else if (OnPause == false)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                _pauseCanvas.SetActive(false);
                StopAction = false;
            }
        }
        NumMoneyHud.text = NumMoney.ToString();

        checkInt = useOrNot;
        _isGround = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, groundMask);
        _isPlate = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, plateMask);
        checkGround();
        CheckCoolDown();

        currentPos = Player.transform.position;

        if (lastPos.y > currentPos.y && _isGround == true && doMove == false && _slideAnim == false)
        {
            if (g == true)
            {
                Invoke("GG", 0.001f);
            }
        }

        lastPos = currentPos;
        OnGround = _isGround;

        {
            _anim.SetBool("onGround", _isGround == false && _upDownMove > 0);
            _anim.SetBool("onGroundFall", _isGround == false && _upDownMove < 0);
            _anim.SetBool("OnGrab", onGrab == true);
            _anim.SetBool("HurtDamage", _hurtAnim == true);
            _anim.SetBool("OnAttack", _attackAnim == true);
            _anim.SetBool("OnDashAttack", _dashAttackAnim == true);
            _anim.SetBool("OnDeath", _deathAnim == true);
            _anim.SetBool("OnFinalDeath", _finalDeathAnim == true);
            _anim.SetBool("OnSlideAnim", _slideAnim == true);
            _anim.SetBool("OnBoolMagicAttack", _magicAttackAnim == true);
            _anim.SetBool("OnUse", _useOrNot == true);
            _anim.SetBool("StopAnim", _StopAnim == true);

            _anim.SetFloat("CurSpeed", Mathf.Abs(MoveInput));
        }
    }
    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y >= 0)
        {
            _rigidbody.gravityScale = 6f;
        }
        else if (_rigidbody.velocity.y < 0 && _isGround == false)
        {
            _rigidbody.gravityScale = 9f;
        }

        {
            if (_doSlow == false)
            {
                _boostSpeed = 1;
            }
            else if (_doSlow == true)
            {
                if (MoveSlow == false || _isGround == false)
                {
                    _boostSpeed = 0.25f;
                }
                else if (MoveSlow == true && _isGround == true)
                {
                    _boostSpeed = 0f;
                }
            }
        }

        AimX = _player.Move.AimX.ReadValue<float>();
        AimY = _player.Move.AimY.ReadValue<float>();

        SpeedX = _rigidbody.velocity.x;

        if (_useOrNot == true)
        {
            _useOrNot = false;
        }
        if (useOrNot == true)
        {
            Invoke("StopUse", 0.25f);
        }
        if (_rigidbody.velocity.y > 0 && StopAction == false)
        {
            _moveUp = true;
        }
        else _moveUp = false;
        if (_rigidbody.velocity.y < 0 && StopAction == false)
        {
            _moveDown = true;
        }
        else _moveDown = false;

        Move();
        FlipMouse();
        _pos = _main.WorldToScreenPoint(transform.position);
        _upDownMove = _rigidbody.velocity.y;
        _attackAnim = false;
        _dashAttackAnim = false;
    }
    private void OnEnable()
    {
        _player.Enable();
    }
    private void OnDisable()
    {
        _player.Disable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        {
            if (collision.gameObject.tag == "Money")
            {
                Destroy(collision.gameObject);
                Invoke("MoneyPlus", 0.2f);
            }
            if (collision.gameObject.tag == "MoneySilver")
            {
                Destroy(collision.gameObject);
                Invoke("MoneySilverPlus", 0.2f);
            }
            if (collision.gameObject.tag == "MoneyGold")
            {
                Destroy(collision.gameObject);
                Invoke("MoneyGoldPlus", 0.2f);
            }
        }
        if (collision.gameObject.tag == "DeadLava")
        {
            pauseOk = false;
            StopAction = true;
            HP = -20;
            DamTime = true;
        }
        if (collision.gameObject.tag == "trap")
        {
            HP -= 8.5f;
            DamTime = true;
            _rigidbody.velocity = new Vector2(0, 25);
            _doReHp = false;
            Invoke("ReReHp", 0f);
        }
        if (collision.gameObject.tag == "Ground")
        {
            this.transform.parent = collision.transform;
        }
        return;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision == null) return;
        {
            if (collision.gameObject.tag == "Slime" && _ReDam == false)
            {
                _ReDam = true;
                _doReHp = false;
                Invoke("ReReDam", 1f);
                Invoke("ReReHp", 0f);
                HP -= 19;
                DamTime = true;
                _rigidbody.velocity = new Vector2(0, 17.5f);
            }
            if (collision.gameObject.tag == "BigSlime" && _ReDam == false)
            {
                _ReDam = true;
                _doReHp = false;
                Invoke("ReReDam", 1f);
                Invoke("ReReHp", 0f);
                HP -= 25;
                DamTime = true;
                _rigidbody.velocity = new Vector2(0, 19.5f);
            }
        }
        return;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBuller2Damage" && StopAction == false)
        {
            HP -= 10;
            DamTime = true;
            Destroy(collision.gameObject);
        }
        /*if (collision.gameObject.tag == "EnemyBuller2Damage")
        {
            HP -= 27;
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "le" && doUp == true && StopAction == false)
        {
            _rigidbody.velocity = new Vector2(0, 10);
            onGrab = true;
        }
        else if (collision.gameObject.tag != "le" || doUp == false || StopAction == true)
        {
            onGrab = false;
        }
    }

    private void FlipMouse()
    {
        if (MoveInput > 0 && StopAction == false)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (MoveInput < 0 && StopAction == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (GamepadSwitch.GamepadOn == false)
        {
            if (Input.mousePosition.x < _pos.x && MoveInput == 0 && StopAction == false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.mousePosition.x > _pos.x && MoveInput == 0 && StopAction == false)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (GamepadSwitch.GamepadOn == true)
        {
            if (AimX < 0 && MoveInput == 0 && StopAction == false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (AimX > 0 && MoveInput == 0 && StopAction == false)
            {   
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    void Jump()
    {
        if (_slideAnim == false && _amountJump > 0 && Stam >= 3 && StopAction == false && KatBoolStop == false)
        {
            _amountJump -= 1;
            _rigidbody.AddForce(transform.up * _jump * _boostJump, ForceMode2D.Impulse);
            Stam -= 3;
            _regenStamJump = false;
            Invoke("ReReStamJump", 1.5f);
            Jump_play();
        }
    }
    void Move()
    {
        MoveInput = 0;
        MoveInput = _player.Move.Movement.ReadValue<float>();

        if (_rigidbody.velocity.y > 35 && StopAction == false && onGrab == false)
        {
            _rigidbody.velocity = new Vector2(MoveInput * _speed * katStop * _boostSpeed * _slideBoost, 35);
        }
        else if (_rigidbody.velocity.y <= 35 && StopAction == false && onGrab == false)
        {
            _rigidbody.velocity = new Vector2(MoveInput * _speed * _boostSpeed * katStop * _slideBoost, _rigidbody.velocity.y);
        }
        else if (StopAction == false && onGrab == true)
        {
            _rigidbody.velocity = new Vector2(MoveInput * _speed * _boostSpeed * katStop * _slideBoost * 0.25f , _rigidbody.velocity.y);
        }
        else if (StopAction == true)
        {
            _boostJump = 0;
        }
    }
    void SlowSwitch()
    {
        _doSlow = !_doSlow;
    }
    void checkGround()
    {
        if (_isGround)
        {
            _amountJump = 1;
        }
    }
    void Slide()
    {
        if (MoveInput != 0 && _isGround == true && _doSlide == true && Stam >= 20 && StopAction == false && KatBoolStop == false)
        {
            Invoke("SlideBoost", 0f);
            Invoke("StopSlideBoost", 0.3f);
            Invoke("ReSlide", 0.5f);
            Invoke("ReReStamSlide", 2f);
            Invoke("Slide_play", 0f);
            _slideAnim = true;
           _doSlide = false;
        }
    }
    void SlideBoost()
    {
        collDown.SetActive(false);
        Stam -= 20;
        _slideBoost = 3;
        _regenStamSlide = false;
    }
    void StopSlideBoost()
    {
        _slideBoost = 1;
        _slideAnim = false;
        if (wallIn == false)
        {
            collDown.SetActive(true);
        }
    }
    void ReSlide()
    {
        _doSlide = true;
    }
    void Hit()
    {
        if (onGrab == false && Stam >= 10 && _doHit == true && _isGround == true && Mana >= 30 && StopAction == false && MoveInput == 0 && learnedMagicSword == true)
        {
            Slash.SetActive(true);
            Invoke("StopHit", 0.75f);
            Invoke("ReHit", 0.75f);
            Invoke("ReReStamHit", 2f);
            Invoke("ReReManaHit", 2.5f);
            Stam -= 10;
            Mana -= 30;
            _doHit = false;
            _regenStamHit = false;
            _attackAnim = true;
            Attack1play();
            Invoke("Attack1_1play", 0.40f);
        }
        else if ((_isGround == false || MoveInput != 0) && onGrab == false && Stam >= 15 && _doHit == true && Mana >= 35 && StopAction == false && learnedMagicSword == true)
        {
            Slash.SetActive(true);
            Invoke("StopHit", 0.75f);
            Invoke("ReHit", 0.85f);
            Invoke("ReReStamHit", 2f);
            Invoke("ReReManaHit", 2.5f);
            Stam -= 15;
            Mana -= 35;
            _doHit = false;
            _regenStamHit = false;
            _dashAttackAnim = true;
            Attack2play();
        }
    }
    void StopHit()
    {
        Slash.SetActive(false);
    }
    void ReHit()
    {
        _doHit = true;
    }
    private void CheckHP()
    {
        ScaleHP = (HP / 100 * _armor) / maxHP;
        _HpBar.fillAmount = ScaleHP;
    }
    private void CheckHpValue()
    {
        _oldHpValue = HP;
    }
    private void StopHurtAnim()
    {
        _hurtAnim = false;
    }
    private void regenHP()
    {
        if (HP < maxHP)
        {
            HP += 0.25f;
            _checkHp = true;
        }
    }
    private void ReReHp()
    {
        Invoke("FinalReReHp", 3.75f);
    }
    private void FinalReReHp()
    {
        _doReHp = true;
    }
    void ReReDam()
    {
        _ReDam = false;
    }
    void TimeStop()
    {
        DiedCanvas.SetActive(OnDied);
        Time.timeScale = 0f;
    }
    void StartSave()
    {
        Save.Savel();
    }
    private void CheckStam()
    {
        _ScaleStam = Stam / maxStam;
        _StaminaBar.fillAmount = _ScaleStam;
    }
    private void RegenStam()
    {
        Stam += 0.25f * boostregenManaAndStamina;
    }
    private void ReReStamJump()
    {
        _regenStamJump = true;
    }
    private void ReReStamSlide()
    {
        _regenStamSlide = true;
    }
    private void ReReStamHit()
    {
        _regenStamHit = true;
    }
    private void CheckMana()
    {
        _ScaleMana = Mana / maxMana;
        _ManaBar.fillAmount = _ScaleMana;
    }
    private void RegenMana()
    {
        Mana += 0.25f * boostregenManaAndStamina;
    }
    private void ReReManaHit()
    {
        _regenManaHit = true;
    }
    void MoneyPlus()
    {
        NumMoney += 10;
    }
    void MoneySilverPlus()
    {
        NumMoney += 1;
    }
    void MoneyGoldPlus()
    {
        NumMoney += 5;
    }
    void Pause()
    {
    OnPause = !OnPause;
    }
    private void StopDeathAnim()
    {
        _finalDeathAnim = true;
    }
    void CheckCoolDown()
    {
        if (_CoolDownUltra < _maxCoolDownUltra)
        {
            _CoolDownUltra += Time.deltaTime;
            float Ultrascale = _CoolDownUltra / _maxCoolDownUltra;
            UltraBar.fillAmount = Ultrascale;
        }
    }
    private void UseUltra()
    {
        if (_CoolDownUltra < _maxCoolDownUltra) return;
        _CoolDownUltra = 0;
        HP += 20;
        _boostSpeed = 1.75f;
        _boostJump = 1.75f;
        global.intensity = 0.75f;
        Invoke("StopBaf", 10f);
        Invoke("Ultra_play", 0f);
    }
    void StopBaf()
    {
        _boostSpeed = 1f;
        _boostJump = 1;
        global.intensity = 0.22f;
    }
    private void Shoot()
    {
        if (_onSpawnMagBall == true && onGrab == false && StopAction == false && _isGround == true && _mattack == true && Stam >= 20 && Mana >= 40 && MoveInput == 0 && learnedMagicBall == true)
        {
            _onSpawnMagBall = false;
            Invoke("StopMagicAttackAnim", 0.5f);
            _magicAttackAnim = true;
            _mattack = false;
            Invoke("ReMAttack", 0.55f);
            Stam -= 20;
            Mana -= 40;
            _magicBallLight.SetActive(true);
            Invoke("Spawn", 0.4f);
            Invoke("Shoot_play", 0.01f);
        }
    }
    void Spawn()
    {
        Instantiate(_bullet, _shotPoint.position, _lineShoot.transform.rotation);
    }
    void StopMagicAttackAnim()
    {
        _magicAttackAnim = false;
        _magicBallLight.SetActive(false);
    }
    void ReMAttack()
    {
        _mattack = true;
        _onSpawnMagBall = true;
    }

    private void ReKat1()
    {
        _camera2_1k.m_Priority = 0;
        Hud.SetActive(true);
        CursorB.SetActive(true);
        Invoke("ReKat1_1", 2f);
    }
    private void ReKat1_1()
    {
        KatBoolStop = false;
        katStop = 1;
        _StopAnim = false;
    }
    private void StopUse()
    {
        useOrNot = false;
    }
    private void SpeedFall()
    {
        if (_isGround == false && onGrab == false)
        {
            Invoke("SpeedFall_play", 0.0001f);
            _speedFall = true;
        }
    }
    private void GG()
    {
        g = false;
        Fall_play();
        Invoke("GGG", 0.5f);
    }
    private void GGG()
    {
        g = true;
    }
    private void HH()
    { 
        h = false;
        Invoke("Walking_play", 0.01f);
        Invoke("HHH", 0.33f);
    }
    private void HH2()
    {
        h = false;
        Invoke("Walking_play", 0.01f);
        Invoke("HHH", 0.85f);
    }
    private void HHH()
    {
        h = true;
    }
    private void DamTimeRe()
    {
        DamTime = false;
    }


    void Attack2play()
    {
        PlaySounnd(sounds[0], p1: 0.85f, p2: 1.2f);
    }
    void Attack1play()
    {
        PlaySounnd(sounds[1], p1: 0.85f, p2: 1.2f);
    }
    void Attack1_1play()
    {
        PlaySounnd(sounds[1], p1: 0.85f, p2: 1.2f);
    }
    void Jump_play()
    {
        PlaySounnd(sounds[2], p1: 0.65f, p2: 1f);
    }
    void Fall_play()
    {
        PlaySounnd(sounds[3], p1: 0.95f, p2: 1.1f);
    }
    void Slide_play()
    {
        PlaySounnd(sounds[4], p1: 0.95f, p2: 1.1f);
    }
    void Ultra_play()
    {
        PlaySounnd(sounds[5], p1: 0.95f, p2: 1.1f);
    }
    void Walking_play()
    {
        PlaySounnd(sounds[6], p1: 0.75f, p2: 1.25f);
    }
    void Hurt_play()
    {
        PlaySounnd(sounds[7], p1: 0.75f, p2: 1.25f);
    }
    void Shoot_play()
    {
        PlaySounnd(sounds[8], p1: 0.95f, p2: 1.15f);
    }
    void SpeedFall_play()
    {
        PlaySounnd(sounds[9], p1: 0.95f, p2: 1f);
    }
}