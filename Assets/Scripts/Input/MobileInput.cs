using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupanthaPaul
{
    public class MobileInput : MonoBehaviour
    {
        public static float horizontal;
        public static bool jump;
        public static bool dash;
        public static bool attack;

        public void OnLeftButtonDown() => horizontal = -1;
        public void OnRightButtonDown() => horizontal = 1;
        public void OnLeftButtonUp() => horizontal = 0;
        public void OnRightButtonUp() => horizontal = 0;

        public void OnJumpButtonDown() => jump = true;
        public void OnJumpButtonUp() => jump = false;

        public void OnDashButtonDown() => dash = true;
        public void OnDashButtonUp() => dash = false;

        public void OnAttackButtonDown() => attack = true;
        public void OnAttackButtonUp() => attack = false;
    }
}
