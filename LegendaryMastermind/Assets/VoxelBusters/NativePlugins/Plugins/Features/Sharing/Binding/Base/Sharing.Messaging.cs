﻿using UnityEngine;
using System.Collections;
using VoxelBusters.Utility;
using VoxelBusters.DebugPRO;

namespace VoxelBusters.NativePlugins
{
	using Internal;

	public partial class Sharing : MonoBehaviour 
	{
		#region Methods

		/// <summary>
		/// Determines whether messaging service is available.
		/// </summary>
		/// <returns><c>true</c> if this messaging service is available; otherwise, <c>false</c>.</returns>
		public virtual bool IsMessagingServiceAvailable ()
		{
			bool _isAvailable	= false;
			Console.Log(Constants.kDebugTag, "[Sharing:Messaging] Is service available=" + _isAvailable);
			
			return _isAvailable;
		}

		protected virtual void ShowMessageShareComposer (MessageShareComposer _composer)
		{
			if (!IsMessagingServiceAvailable())
			{
				MessagingShareFinished(MessagingShareFailedResponse());
				return;
			}
		}

		#endregion

		#region Deprecated Methods

		[System.Obsolete(kSharingFeatureDeprecatedMethodInfo)]
		public virtual void SendTextMessage (string _body, string[] _recipients, SharingCompletion _onCompletion)
		{
			// Pause unity player
			this.PauseUnity();
			
			// Cache callback
			OnSharingFinished	= _onCompletion;
			
			// Messaging service isnt available
			if (!IsMessagingServiceAvailable())
			{
				MessagingShareFinished(MessagingShareFailedResponse());
				return;
			}
		}
		
		#endregion
	}
}