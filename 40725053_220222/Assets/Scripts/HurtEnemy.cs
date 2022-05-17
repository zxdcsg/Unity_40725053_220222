using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// 敵人受傷 ： 彈出受傷數字
    /// </summary>
    //子類別 ： 父類別 - 繼承語法
    public class HurtEnemy : HurtSystem
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("畫布受傷數值")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("經驗值道具")]
        private GameObject goExp;
        private string parameterDead = "觸發死亡";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Start()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        //override 覆寫:覆寫父類別有 virtual 的成員
        //base 指父類別原本成員的內容
        public override void GetHurt(float damage)
        {
            base.GetHurt(damage);

            GameObject temp = Instantiate(goCanvasHurt, transform.position, Quaternion.identity);
            temp.GetComponent<HurtNumberEffect>().UpdateHurtNumber(damage);
        }


        protected override void Dead()
        {
            base.Dead();

            ani.SetTrigger(parameterDead);
            enemySystem.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2);

            DropEXP();
        }

        /// <summary>
        /// 掉落經驗值
        /// </summary>
        private void DropEXP()
        {
            //隨機的值 範圍 0 ~ 1 浮點數
            float randwon = Random.value;

            //如果 隨機值 小於等於 掉落機率
            if (randwon <= data.expDroProbaility)
            {
                //生成 經驗道具
                GameObject tempExp = Instantiate(goExp, transform.position, Quaternion.identity);
                //經驗值.添加元件<元件名稱>().經驗值類型 = 敵人類型.經驗值類型
                tempExp.AddComponent<Exp>().typeExp = data.typeExp;
            }
        }
    }
}
