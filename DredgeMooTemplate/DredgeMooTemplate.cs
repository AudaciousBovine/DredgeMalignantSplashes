using UnityEngine;
using Winch.Core;

namespace DredgeMooTemplate
{
	public class DredgeMooTemplate : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(DredgeMooTemplate)} has loaded!");
		}
	}
}
