using UnityEngine;
    
namespace Oliya
{
    /// <summary>
    ///�Z�����
    ///1.����t�� float
    ///2.�����O float
    ///3.�_�l�ƶq int
    ///4.�̤j�ƶq int
    ///5.����ɶ� float
    ///6.�ͦ���m
    ///7.�Z���w�m��
    ///8.�����V
    ///</summary>
    //ScriptableObject �}���ƪ��� 
    //�@��:�N�}��������ܦ������x�s�� Project��(�X�R�P���@�ʨ�)
    //CreateAssetMenu�PScriptableObject�f�t�ϥ�
    //�@��:�bProject�إߦ��}���ƪ��󪺿��P�ɮצW��
    //menuName ���W�� fileName �ɮצW��
    [CreateAssetMenu(menuName = "Oliya/Data Weapon", fileName = "Data Weapon")]
    public class DataWeapon : ScriptableObject
    {
        [Header("����t��"), Range(0, 5000)]
        public float speed = 500;
        [Header("�����O"), Range(0, 100)]
        public float attack = 10;
        [Header("�_�l�ƶq"), Range(1, 10)]
        public int countstart = 1;
        [Header("�̤j�ƶq"), Range(1, 20)]
        public int countMax = 3;
        [Header("����ɶ�"), Range(0, 5)]
        public float interval = 3.5f;

        //�������[] �}�C - ��Ƶ��c
        //�@��:�x�s�h���ۦP���������
        [Header("�ͦ���m")]
        public  Vector3[] v3SpawnPoint;
        [Header("�Z���w�m��")]
        public GameObject goWeapon;
        [Header("�����V")]
        public Vector3 v3Direction;
    }
}
