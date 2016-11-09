### MonoBehaviour的可重写函数整理

　　Update

　　当MonoBehaviour启用时，其Update在每一帧被调用。

　　LateUpdate

　　当Behaviour启用时，其LateUpdate在每一帧被调用。

　　FixedUpdate

　　当MonoBehaviour启用时，其 FixedUpdate 在每一帧被调用。

　　Awake

　　当一个脚本实例被载入时Awake被调用。

　　Start

　　Start仅在Update函数第一次被调用前调用。

　　Reset

　　重置为默认值。

　　OnMouseEnter

　　当鼠标进入到GUIElement（GUI元素）或Collider（碰撞体）中时调用OnMouseEnter。

　　OnMouseOver

　　当鼠标悬浮在GUIElement（GUI元素）或Collider（碰撞体）上时调用 OnMouseOver .

　　OnMouseExit

　　当鼠标移出GUIElement（GUI元素）或Collider（碰撞体）上时调用OnMouseExit。

　　OnMouseDown

　　当鼠标在GUIElement（GUI元素）或Collider（碰撞体）上点击时调用OnMouseDown。

　　OnMouseUp

　　当用户释放鼠标按钮时调用OnMouseUp。

　　OnMouseUpAsButton

　　OnMouseUpAsButton只有当鼠标在同一个GUIElement或Collider按下，在释放时调用。

　　OnMouseDrag

　　当用户鼠标拖拽GUIElement（GUI元素）或Collider（碰撞体）时调用 OnMouseDrag 。

　　OnTriggerEnter

　　当Collider（碰撞体）进入trigger（触发器）时调用OnTriggerEnter。

　　OnTriggerExit

　　当Collider（碰撞体）停止触发trigger（触发器）时调用OnTriggerExit。

　　OnTriggerStay

　　当碰撞体接触触发器时，OnTriggerStay将在每一帧被调用。

　　OnCollisionEnter

　　当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionEnter将被调用。

　　OnCollisionExit

　　当此collider/rigidbody停止触发另一个rigidbody/collider时，OnCollisionExit将被调用。

　　OnCollisionStay

　　当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionStay将会在每一帧被调用。

　　OnControllerColliderHit

　　在移动的时，当controller碰撞到collider时OnControllerColliderHit被调用。

　　OnJointBreak

　　当附在同一对象上的关节被断开时调用。

　　OnParticleCollision

　　当粒子碰到collider时被调用。

　　OnBecameVisible

　　当renderer（渲染器）在任何相机上可见时调用OnBecameVisible。

　　OnBecameInvisible

　　当renderer（渲染器）在任何相机上都不可见时调用OnBecameInvisible。

　　OnLevelWasLoaded

　　当一个新关卡被载入时此函数被调用。

　　OnEnable

　　当对象变为可用或激活状态时此函数被调用。

　　OnDisable

　　当对象变为不可用或非激活状态时此函数被调用。

　　OnDestroy

　　当MonoBehaviour将被销毁时，这个函数被调用。

　　OnPreCull

　　在相机消隐场景之前被调用。

　　OnPreRender

　　在相机渲染场景之前被调用。

　　OnPostRender

　　在相机完成场景渲染之后被调用。

　　OnRenderObject

　　在相机场景渲染完成后被调用。

　　OnWillRenderObject

　　如果对象可见每个相机都会调用它。

　　OnGUI

　　渲染和处理GUI事件时调用。

　　OnRenderImage

　　当完成所有渲染图片后被调用，用来渲染图片后期效果。

　　OnDrawGizmosSelected

　　如果你想在物体被选中时绘制gizmos，执行这个函数。

　　OnDrawGizmos

　　如果你想绘制可被点选的gizmos，执行这个函数。

　　OnApplicationPause

　　当玩家暂停时发送到所有的游戏物体。

　　OnApplicationFocus

　　当玩家获得或失去焦点时发送给所有游戏物体。

　　OnApplicationQuit

　　在应用退出之前发送给所有的游戏物体。

　　OnPlayerConnected

　　当一个新玩家成功连接时在服务器上被调用。

　　OnServerInitialized

　　当Network.InitializeServer被调用并完成时，在服务器上调用这个函数。

　　OnConnectedToServer

　　当你成功连接到服务器时，在客户端调用。

　　OnPlayerDisconnected

　　当一个玩家从服务器上断开时在服务器端调用。

　　OnDisconnectedFromServer

　　当失去连接或从服务器端断开时在客户端调用。

　　OnFailedToConnect

　　当一个连接因为某些原因失败时在客户端调用。

　　OnFailedToConnectToMasterServer

　　当报告事件来自主服务器时在客户端或服务器端调用。

　　OnMasterServerEvent

　　当报告事件来自主服务器时在客户端或服务器端调用。

　　OnNetworkInstantiate

　　当一个物体使用Network.Instantiate进行网络初始化时调用。

　　OnSerializeNetworkView

　　在一个网络视图脚本中，用于自定义变量同步。

### MonoBehaviour类下的重要方法

             Update                当MonoBehaviour启用时，每帧调用一次。用于更新场景和状态（物理状态有关的更新应该放在FixedUpdate里）

       Start                       Update函数第一次运行之前调用。用于游戏对象的初始化

       Awake                脚本实例被创建时调用，用于游戏对象的初始化，但执行时间早于Start函数

       FixedUpdate        用于物理状态的更新

       LateUpdate        每帧调用一次，（在Update之后调用）

       事件响应函数

       OnMouseOver        鼠标移入GUI空间或者碰撞体时调用

       OnMouseEnter        鼠标停留在GUI控件或者碰撞体时调用

       OnMouseExit        鼠标移出GUI控件或者碰撞体时调用

       OnMouseDown        鼠标在GUI控件或者碰撞体上按下时调用

       OnMouseUp        鼠标按键释放时调用

       OnTriggerEnter        当其他碰撞体进入触发器时调用

       OnTriggerExit        当其他碰撞体离开触发器时调用

       OnTriggerStay        当其他碰撞体停留在触发器时调用

       OnCollisionEnter当碰撞体与刚体与其他碰撞体或刚体接触时调用

       OnCollisionExit        当碰撞体与刚体与其他碰撞体或刚体停止接触时调用

       OnCollisionStay        当碰撞体与刚体与其他碰撞体或刚体保持接触时调用

       OnControllerColliderHit当控制器移动时与碰撞体发生碰撞时调用

       OnBecomeVisible        当任意一个相机可见时调用

       OnBecomeInvisible        当任意一个相机不可见时调用

       OnEnable        对象启用或者激活时调用

       OnDisable 对象禁用或者取消激活时调用

       OnDestroy脚本销毁时调用

       OnGUI        渲染GUI和处理GUI时调用。

 