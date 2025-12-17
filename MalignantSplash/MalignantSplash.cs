using UnityEngine;
using Winch.Core;

namespace MalignantSplash
{
	public class MalignantSplash : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(MalignantSplash)} has loaded!");
		}
	}
}
