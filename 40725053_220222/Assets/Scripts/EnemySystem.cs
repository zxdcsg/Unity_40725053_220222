using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "刺客";

        private Transform traPlayer;
        /// <summary>
        /// 攻擊計時器
        /// </summary>
        private float timerAttack;
        private Animator ani;
        private string parameterAttack = "觸發攻擊";
        
        private void Awake()
        {
            ani = GetComponent<Animator>();

            //玩家變形 = 遊戲物件.尋找(物件名稱) 的 變形
            traPlayer = GameObject.Find(namePlayer).transform;

           /** //數學.插值(A,B,百分比)
            float result = Mathf.Lerp(0, 100, 0.5f);
            print("0 與 100 的 0.5 插值結果:" + result);
           */
        }

        private void Update()
        {
            /** 測試插值
            a = Mathf.Lerp(a, b, 0.5f);
            print("測試結果:" + a);
            */

            MoveToPlayer();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, data.stopDistance);
        }
       
        /// <summary>
        /// 移動到玩家位置
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;     //A點:敵人座標
            Vector3 posPlayer = traPlayer.position;    //B點:玩家座標

            //距離 = 三維向量.距離(A點，B點)
            float dis = Vector3.Distance(posEnemy, posPlayer);
            //print("<color=yellow>距離:" + dis + "</color>");

            //如果 距離 小於 停止距離 就處理
            if (dis < data.stopDistance)
            {
                Attack();
            }
            
            //否則 距離 大於 停止距離 就處理 追蹤
            else
            {         
                //敵人座標 = 插值(敵人座標,玩家座標,百分比*速度*一禎的時間)
                transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

                // y = 敵人 X 大於 玩家 X ? 180 : 0 - 如果敵人 X 大於玩家 X 角度設定為 180 否則 0
                float y = transform.position.x > traPlayer.position.x ? 180 : 0;
                transform.eulerAngles = new Vector3(0, y, 0);
            }
        }

        private void Attack()
        {
            if (timerAttack < data.cd)
            {
                timerAttack += Time.deltaTime;
                //print("<color=red>攻擊計時器:" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}

