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

        private void Start()
        {
            hp = data.hp;
        }
    }
}
