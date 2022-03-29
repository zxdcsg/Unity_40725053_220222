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

        //繪製圖示事件 ODG
        //作用:在編輯器內輔助用，執行檔內不會出現
        private void OnDrawGizmos()
        {
            //1. 決定圖示顏色
            //color(紅、綠、藍、透明度) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2. 繪製圖示
            //圖示.繪製球體(中心點、半徑)
            //取得陣列資料與法:陣列資料名稱[索引直]
            Gizmos.DrawSphere(detaWeapon.v3SpawnPoint[0], 0.1f);
        }
    }
}
