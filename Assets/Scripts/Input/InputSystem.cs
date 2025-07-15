using UnityEngine;

namespace SupanthaPaul
{
	public class InputSystem : MonoBehaviour
	{
		// input string caching
		static readonly string HorizontalInput = "Horizontal";
		static readonly string JumpInput = "Jump";
		static readonly string DashInput = "Dash";

		static readonly string AttackInput = "Attack";

		public static float HorizontalRaw()
		{
#if UNITY_ANDROID
			return MobileInput.horizontal;
#else
			return Input.GetAxisRaw(HorizontalInput);
#endif
		}

		public static bool Jump()
		{
#if UNITY_ANDROID
			return MobileInput.jump;
#else
			return Input.GetButtonDown(JumpInput);
#endif
		}

		public static bool Dash()
		{
#if UNITY_ANDROID
			return MobileInput.dash; // Gunakan untuk tombol Hit jika Dash = Attack
#else
			return Input.GetButtonDown(DashInput); // ← ini sudah benar
#endif
		}

		public static bool Melee()
		{
#if UNITY_ANDROID
    return MobileInput.attack; // Pastikan MobileInput.attack ada jika pakai Android
#else
			return Input.GetButtonDown(AttackInput);
#endif
		}


	}
}
