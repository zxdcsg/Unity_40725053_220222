using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// 武器系統:
    /// 1.設定玩家取得的武器
    /// 2.生成武器
    /// 3.發射武器
    /// 4.攻擊力儲存
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon detaWeapon;
        [SerializeField, Header("武器刪除時間"), Range(0, 10)]
        private float destoryWeaponTime = 3.5f;
        /// <summary>
        /// 計時器
        /// </summary>
        private float timer;
        private float timer_atk;
        private float timer_atk_speed;
        //繪製圖示事件 ODG
        //作用:在編輯器內輔助用，執行檔內不會出現
        //旗子(判斷式)
        public int Flag = 0;
        private void OnDrawGizmos()
        {
            //1. 決定圖示顏色
            //color(紅、綠、藍、透明度) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2. 繪製圖示
            //圖示.繪製球體(中心點、半徑)
            //取得陣列資料與法:陣列資料名稱[索引直]

            //for 迴圈:重複處理程式區塊
            //(初始值;條件;迴圈結束會執行程式)
            for (int i = 0; i < detaWeapon.v3SpawnPoint.Length; i++)
            {
            Gizmos.DrawSphere(transform.position + detaWeapon.v3SpawnPoint[i], 0.1f);
            }
        }

        private void Start()
        {
            // 2D 物理.忽略圖層碰撞(圖層1,圖層2)
            Physics2D.IgnoreLayerCollision(3, 6); // 玩家 與 武器 不碰撞
            Physics2D.IgnoreLayerCollision(6, 6); // 武器 與 武器 不碰撞
            Physics2D.IgnoreLayerCollision(6, 7); // 武器 與 牆壁 不碰撞
            timer_atk_speed = 0.1f;
        }
        private void Update()
        {
            spawnWeapon();
            //print(Flag+"旗標");
            //print(Flag_2 + "旗標_2");
            //print(timer_atk + "攻擊時間");
            //print(timer + "時間");
        }

        /// <summary>
        /// 生成武器
        /// 1.計算時間
        /// 2.時間累計到間隔時間
        /// 3.生成武器
        /// 4.指定生成位置上
        /// 5.發射武器
        /// 6.賦予武器攻擊力
        /// </summary>
        private void spawnWeapon()
        {
            //Time.deltaTime 一個影格的時間
            timer += Time.deltaTime;
            //print("經過的時間" + timer);
            //如果 計時器 大於等於 間隔時間 就生成 武器

            if (timer >= detaWeapon.interval)
            {
                //print("生成武器");
                //隨機值 = 隨機.範圍(最小值,最大值) - 整數不包含最大值
                int random = Random.Range(0, detaWeapon.v3SpawnPoint.Length);
                //座標
                Vector3 pos = transform.position + detaWeapon.v3SpawnPoint[random];
                //Quaternion四位元:紀錄角度資訊類型
                //Quaternion.identity 零角度(0,0,0)
                //暫存武器 = 生成(物件,座標,角度)
                GameObject temp = Instantiate(detaWeapon.goWeapon, pos, Quaternion.identity);
                //暫存武器.取得元件<鋼體>().添加推力(方向*速度)
                temp.GetComponent<Rigidbody2D>().AddForce(detaWeapon.v3Direction * detaWeapon.speed);
                timer = 0;
                Flag = 1;
                //刪除物件(要刪除的物件,延遲刪除時間)
                Destroy(temp, destoryWeaponTime);
                //取得武器.攻擊力 = 武器資料.攻擊力
                temp.GetComponent<Weapon>().attack = detaWeapon.attack;
            }

            if (Flag == 1)
            {
                timer_atk += Time.deltaTime;
                if (timer_atk >= timer_atk_speed)
                {
                 Flag = 0;
                 timer_atk = 0;
                }
            }
        }
    }
}
