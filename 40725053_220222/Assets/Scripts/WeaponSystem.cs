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

        /// <summary>
        /// �p�ɾ�
        /// </summary>
        private float timer;
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

            //for �j��:���ƳB�z�{���϶�
            //(��l��;����;�j�鵲���|����{��)
            for (int i = 0; i < detaWeapon.v3SpawnPoint.Length; i++)
            {
            Gizmos.DrawSphere(transform.position + detaWeapon.v3SpawnPoint[i], 0.1f);
            }
        }

        private void Start()
        {
            // 2D ���z.�����ϼh�I��(�ϼh1,�ϼh2)
            Physics2D.IgnoreLayerCollision(3, 6); // ���a �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 6); // �Z�� �P �Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 7); // �Z�� �P ��� ���I��
        }
        private void Update()
        {
            spawnWeapon();
        }

        /// <summary>
        /// �ͦ��Z��
        /// 1.�p��ɶ�
        /// 2.�ɶ��֭p�춡�j�ɶ�
        /// 3.�ͦ��Z��
        /// 4.���w�ͦ���m�W
        /// 5.�o�g�Z��
        /// 6.�ᤩ�Z�������O
        /// </summary>
        private void spawnWeapon()
        {
            //Time.deltaTime �@�Ӽv�檺�ɶ�
            timer += Time.deltaTime;

            //print("�g�L���ɶ�" + timer);

            //�p�G �p�ɾ� �j�󵥩� ���j�ɶ� �N�ͦ� �Z��

            if (timer >= detaWeapon.interval)
            {
                //print("�ͦ��Z��");
                //�H���� = �H��.�d��(�̤p��,�̤j��) - ��Ƥ��]�t�̤j��
                int random = Random.Range(0, detaWeapon.v3SpawnPoint.Length);
                //�y��
                Vector3 pos = transform.position + detaWeapon.v3SpawnPoint[random];
                //Quaternion�|�줸:�������׸�T����
                //Quaternion.identity �s����(0,0,0)
                //�Ȧs�Z�� = �ͦ�(����,�y��,����)
                GameObject temp = Instantiate(detaWeapon.goWeapon, pos, Quaternion.identity);
                //�Ȧs�Z��.���o����<����>().�K�[���O(��V*�t��)
                temp.GetComponent<Rigidbody2D>().AddForce(detaWeapon.v3Direction * detaWeapon.speed);
                
                timer = 0;
            }
        }
    }
}
