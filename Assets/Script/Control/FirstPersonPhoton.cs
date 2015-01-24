using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]


public class FirstPersonPhoton : Photon.MonoBehaviour {

	//Character Config
	public float moveSpeed;
	public float rotateSpeed;
	public float backSpeed;
	public float jumpHeight;

	public bool isControllable;

	//InputControl
	public GameObject VPad_Movement;

	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	public float animSpeed = 1.5f;				// アニメーション再生速度設定

	//Physical Components
	private CapsuleCollider col;
	private Rigidbody rb;

	// Movement
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;

	/*
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int restState = Animator.StringToHash("Base Layer.Rest");
	 */

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		orgColHight = col.height;
		orgVectColCenter = col.center;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (!photonView.isMine) {
			isControllable = true;
						float h = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
						float v = Input.GetAxis ("Vertical");				// 入力デバイスの垂直軸をvで定義

						//for Smartphone
						/*
		float v_ = VPad_Movement.position.y;
		float h_ = VPad_Movement.position.x;
		*/

						anim.SetFloat ("Speed", v);							// Animator側で設定している"Speed"パラメタにvを渡す
						anim.SetFloat ("Direction", h); 						// Animator側で設定している"Direction"パラメタにhを渡す
						anim.speed = animSpeed;								// Animatorのモーション再生速度に animSpeedを設定する
						currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する
						rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

			// 以下、キャラクターの移動処理
			velocity = new Vector3(0, 0, v);		// 上下のキー入力からZ軸方向の移動量を取得
			// キャラクターのローカル空間での方向に変換
			velocity = transform.TransformDirection(velocity);
			//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
			if (v > 0.1) {
				velocity *= moveSpeed;		// 移動速度を掛ける
			} else if (v < -0.1) {
				velocity *= backSpeed;	// 移動速度を掛ける
			}

			/*
			if (Input.GetButtonDown("Jump")) {	// スペースキーを入力したら
				
				//アニメーションのステートがLocomotionの最中のみジャンプできる
				if (currentBaseState.nameHash == locoState){
					//ステート遷移中でなかったらジャンプできる
					if(!anim.IsInTransition(0))
					{
						rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
						anim.SetBool("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
					}
				}
			}
			*/

			// 上下のキー入力でキャラクターを移動させる
			transform.localPosition += velocity * Time.fixedDeltaTime;
			
			// 左右のキー入力でキャラクタをY軸で旋回させる
			transform.Rotate(0, h * rotateSpeed, 0);	

				}
		}
}
