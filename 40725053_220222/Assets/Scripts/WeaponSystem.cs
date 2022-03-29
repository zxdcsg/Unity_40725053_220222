using UnityEngine;

namespace Oliya
{
    /// <summary>
    /// �Z���t��:
    /// 1.�]�w���a���o���Z��
    /// 2.�ͦ��Z��
    /// 3.�o�g�Z��
    /// 4.�����O�x�s
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z�����")]
        private DataWeapon detaWeapon;

        //ø�s�ϥܨƥ� ODG
        //�@��:�b�s�边�����U�ΡA�����ɤ����|�X�{
        private void OnDrawGizmos()
        {
            //1. �M�w�ϥ��C��
            //color(���B��B�šB�z����) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2. ø�s�ϥ�
            //�ϥ�.ø�s�y��(�����I�B�b�|)
            //���o�}�C��ƻP�k:�}�C��ƦW��[���ު�]
            Gizmos.DrawSphere(detaWeapon.v3SpawnPoint[0], 0.1f);
        }
    }
}
