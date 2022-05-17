using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// �ĤH���� �G �u�X���˼Ʀr
    /// </summary>
    //�l���O �G �����O - �~�ӻy�k
    public class HurtEnemy : HurtSystem
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("�e�����˼ƭ�")]
        private GameObject goCanvasHurt;
        [SerializeField, Header("�g��ȹD��")]
        private GameObject goExp;
        private string parameterDead = "Ĳ�o���`";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Start()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = data.hp;
        }

        //override �мg:�мg�����O�� virtual ������
        //base �������O�쥻���������e
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
        /// �����g���
        /// </summary>
        private void DropEXP()
        {
            //�H������ �d�� 0 ~ 1 �B�I��
            float randwon = Random.value;

            //�p�G �H���� �p�󵥩� �������v
            if (randwon <= data.expDroProbaility)
            {
                //�ͦ� �g��D��
                GameObject tempExp = Instantiate(goExp, transform.position, Quaternion.identity);
                //�g���.�K�[����<����W��>().�g������� = �ĤH����.�g�������
                tempExp.AddComponent<Exp>().typeExp = data.typeExp;
            }
        }
    }
}
