using UnityEngine;    // �ޥ�Unity �R�W�Ŷ� (API)

//�R�W�Ŷ� �Ŷ��W��
//�h�H�}�o�i�H�ϥΩR�W�Ŷ��Ϲj�t���קK�Ĭ�
namespace Oliya
{
    // ���} ���O  �}���W�� (�P���W���ɮצW�٬ۦP�A�j�p�g�@�ˡA����ϥΪŮ�P�S��r��#@!?)
    public class TopDownController : MonoBehaviour
    {
        #region ���:�O�s�t�λݭn���򥻸�ơA�Ҧp:���ʳt�סB�ʵe�ѼƦW�ٻP���󵥵�
        // ��� field �y�k:�׹��� ������� ���W��(���w ��l��)�F
        // private �p�H�A�Ppublic�ۤ�:���\��L�t�Φs��
        private float speed = 10.5f;
        private string parameterRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region �ƥ�:�{���J�f(Unity)�A���Ѷ}�o�X�ʨt�Ϊ����f
        //����ƥ�:����C������@���A�B�z��l�ơA�B�z��l�ơA���o��ơA��ƪ�l��
        private void Awake()
        {
            //��X(�T��)�A�N�T����X��Unity Console(�����O) Ctrl + Shift + c
            //print("�ڬO����ƥ�~");

            //��� ���w�� ���o����<����W��>()
            //<����>�x��:���ܥ�������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        //��s�ƥ�:����C���H�C��60������A60FPS(Framo Per Second)
        //�B�z:����ʦ欰-���ʡB����B����A���a��J-�ƹ�-��L�BĲ���B�n��
        private void Update()
        {
            print("�ڦb Update �ƥ�~");
        }
        #endregion

        #region ��k:���������\��(���z���B�t��k�ε{���϶�)
        #endregion
    }
}
