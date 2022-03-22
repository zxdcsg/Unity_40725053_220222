using UnityEngine;    // �ޥ�UnityEngine �R�W�Ŷ� (API)

//�R�W�Ŷ� �Ŷ��W��
//�h�H�}�o�i�H�ϥΩR�W�Ŷ��Ϲj�t���קK�Ĭ�
namespace Oliya
{
    // ���} ���O  �}���W�� (�P���W���ɮצW�٬ۦP�A�j�p�g�@�ˡA����ϥΪŮ�P�S��r��#@!?)
    //summary �K�n�A�i�H�b���O�B��ơB�ƥ�P��k�W�K�[�T���׽u ///
    //²�u����
    /// <summary>
    /// ���ⱱ��GTop Down ����
    /// </summary>
    public class TopDownController : MonoBehaviour
    {
        #region ���:�O�s�t�λݭn���򥻸�ơA�Ҧp:���ʳt�סB�ʵe�ѼƦW�ٻP���󵥵�
        // ��� field �y�k:
        // �׹��� ������� ���W��(���w ��l��)�F
        // private �p�H�A�Ppublic�ۤ�:���\��L�t�Φs��

        //[] Attribute �ݩʡG���U���O�B��ơB�ƥ�P��k
        //SerializeField �ǦC�e���G���p�H�����ܦb�ݩʭ��O�W
        //Header("���D")���D
        //Range(�̤p�ȡB�̤j��)�d�򭭨�
        [SerializeField,Header("���ʳt��"), Range(0,100)]
        private float speed = 10.5f;
        private string parameterRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;
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
            //print("�ڦb Update �ƥ�~");

           
            //�I�s�y�k�G��k�W��(�����޼�);
            GetInput();
            Move();
        }
        #endregion

        #region ��k:���������\��(���z���B�t��k�ε{���϶�)

        //��k method �y�k�G
        //�׹��� �Ǧ^������� ��k�W��(�Ѽ�){�{���϶�}
        //void �L�^��

        /// <summary>
        /// ���o���a��J���
        /// ���kAD Horizontal
        /// �W�UWS Vertical
        /// </summary>
        private void GetInput()
        {
            //�ϥ��R�A��k���y�k static
            //���O�W��.�R�A��k�W��(�����޼�);
            //float h = ****; - �ϰ쭿�ơG�ȯ�b�ӵ��c(�j�A����)�s��
             h = Input.GetAxis("Horizontal");
             v = Input.GetAxis("Vertical");
            //print("���o�������b�V��" + h);
        }

        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            //�ϥΫD�R�A�ݩ� non-static
            //���W��.�R�A�ݩʦW�� ���w ��
            //����.�[�t�� = �s �G���V�q(�����F����)*�t��
            rig.velocity = new Vector2(h, v)*speed;
            //�ʵe���.�]�w���L��(�ѼƦW�١A���L��)
            //���� ������ �s �Ϊ� ���� ������ �s
            ani.SetBool(parameterRun, h != 0 || v !=0);

            //�T���B��l�y�k
            //�x����: https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/conditional-operator
            //���L�� ? ���L�� ���� true �G ���L�� ���� false
            //���� >=0 ���� 0 �_�h ���� 180
            //�ܧΤ���.�کԨ� = �s �T���V�q(X�AY�AZ)
            transform.eulerAngles = new Vector3(0, h>=0 ? 0 : 180, 0);
        }
        #endregion
    }
}
