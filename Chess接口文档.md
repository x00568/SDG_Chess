## 接口
AttackInterface 攻击类的接口    
ChessInterface 棋子类的接口             
PiecesInterface 棋子状态类接口

## 类
### AttacksTable 类

方法| 返回类型 |参数类型|功能描述
---|---|---|---
AttacksTable|	无|     数组，bool|  类的构造方法，用于初始化
numAttacking|	int|	Vector2|     将传过来的位置信息参数转化为整数的坐标
numAttacking|	int|	int，int|	计算可攻击的位置数量
isAttacked|	bool|	Vector2|	将传过来的位置信息参数转化为整数的坐标
isAttacked|	bool|	int，int|	判断是否被攻击
generateTable|	void|	side|	可攻击区域生成棋子标识符
generateBishop|	void|	int，int，bool|	主教或者皇后的可攻击区域
generateRook|	void|	int，int，bool|	战车或者皇后的可攻击区域
generateKing|	void|	int，int|	国王的可攻击区域
generateKnight|	void|	int，int|	骑士的可攻击区域
generatePawn|	void|	int，int|	禁卫军的可攻击区域

### Chess类
 定义piece和side两个结构体，用来标识位置
 方法| 返回类型 |参数类型|功能描述
---|---|---|---
ModelChoose|	void|	int|	    游戏模式选择
StartGame|	    void|	null|	开始游戏
newBoard|	    void|	null|	初始化棋盘标识符
changeTurn|	    void|	null|	角色转换
checkCheck|	    bool|	数组，side，AttacksTable|	检测是否可以移动棋子
instantiateBoard|	void|	null|	实例化棋盘，生成棋盘和围栏
moveUser|	    bool|	int，int|	是否移动棋子
move|	        bool|	int，int|	移动棋子
selectUser|	    bool|	int，int|	是否选择棋子
select|	        bool|	int，int|	选择棋子，判断选择的棋子类型
undo|	        void|	int	|        悔棋，接收传入的悔棋次数
undo|	        void|	null|	    悔棋，具体操作
Deselect|	    void|	null|	    让其他棋子恢复原状态
lightPawn|	    void|	int，int|	选择禁卫军时，可移动区域高光显示
lightKnight|	void|	int，int|	选择骑士时，可移动区域高光显示
lightRook|	    void|	int，int|	选择战车时，可移动区域高光显示
lightKing|	    void|	int，int|	选择国王时，可移动区域高光显示
lightBishop|	void|	int，int|	选择主教时，可移动区域高光显示
theEnd|	        void|	null|	游戏结束
Reset|	        void| 	null|	重置游戏

### AIMove类
主要定义棋子的存储起始位置和数值的变量
 方法| 返回类型 |参数类型|功能描述
---|---|---|---
go|	                void|	        数组|	选择电脑时调用
simulateMove|	    ChessSquare|	    AIMove|	主要是拷贝棋子参数
selectCheckBreaker|	AIMove	|        sid|	AI棋子可以移动则调用
selectAttack|	    AIMove|	        side,AttacksTable|	AI棋子选择攻击
selectRandom|	    AIMove|	        side,AttacksTable|	随机一个可移动棋子
pawnMoves|	        List<AIMove>|	int，int|	禁卫军可走区域，并加入列表
knightMoves	 |       List<AIMove>|	int，int|	骑士可走区域，并加入列表
rookMoves	|        List<AIMove>|	int，int|	战车可走区域，并加入列表
kingMoves|	        List<AIMove>|	int，int|	国王可走区域，并加入列表
bishopMoves	|        List<AIMove>|	int，int|	主教可走区域，并加入列表
gimmeMove|	        AIMove	|        int，int，int，int|	对比棋子起始位置的数值
gimmeMoves|	        List<AIMove>|	side|	判断棋子类型，并加入列表
selectMoveAttack|	AIMove|	        List<AIMove>|	棋子选择攻击移动
selectMovesDefensive |   List<AIMove>|	List<AIMove>|棋子选择防御移动，加入列表
selectAttacksDefensive|	List<AIMove>|	List<AIMove>|	对比棋子的价值选择攻击或者防御，加入列表
selectMoveByRisk|	AIMove|	    List<AIMove>|	棋子选择风险移动，函数内部对比数值
gimmeValue|	        int	 |      piece|	给棋子加权重值

### Pieces类
棋子状态类，棋子在不同情况下所表现的不同状态
 方法| 返回类型 |参数类型|功能描述
---|---|---|---
hide|	        void|	null|	隐藏棋子
show|	        void|	null|	显示棋子
translucent| 	void|	null|	棋子半透明
shine|	        void|	null|	棋子高光
### Square类
棋盘状态类，选择棋子时棋盘颜色变化
 方法| 返回类型 |参数类型|功能描述
---|---|---|---
resetColor|	    void|	null|	棋盘恢复原始颜色
attack|	        void|	null|	棋子被攻击棋盘变色
range|	        void|	null|	棋子可走棋盘变色
OnMouseEnter|	void|	null|	鼠标掠过棋子
OnMouseExit	|    void|	null|	鼠标离开棋子
OnMouseDown|	    void|	null|	鼠标选择或者手势选择棋子
### UIManage类
UI管理
方法| 返回类型 |参数类型|功能描述
---|---|---|---
StartGame| void| void | 点击开始按钮触发
ModelChoose| void|int|模式选择