using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// ���˨t��
    /// ��q�A���˻P���`
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        //1.pubil ���}�G�Ҧ����O�i�H�s��
        //2.private �p�H�G�ȭ������O�i�H�s��
        //3.protected �O�@�G�ȭ������O�P�l���O�i�H�s��
        [SerializeField, Header("��q"), Range(0, 10000)]
        protected float hp = 50;
        //virtual ����: ���\�l���O�ϥ� override �мg������
        /// <summary>
        /// ����ˮ`
        /// </summary>
        ///<param name="damage">���쪺�ˮ`</param>
        public virtual void GetHurt(float damage)
        {
            if (hp <= 0) return;
            hp -= damage;
            print("<color=#887700>����ˮ`:" + damage + "</color>");

            if (hp < 0) Dead();
        }
        /// <summary>
        /// ���`
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            print("<color=#887700>���⦺�`:" + gameObject + "</color>");
        }
    }
}
