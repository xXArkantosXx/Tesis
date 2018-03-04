using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class DefaultTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES

		public GameObject nextbtn;
		public GameObject backbtn;
		public GameObject soundbtn;
		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES

		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			GameObject gameobjectArray = GameObject.FindGameObjectWithTag ("btnNext");
			nextbtn = gameobjectArray;
			GameObject gamenext = GameObject.FindGameObjectWithTag ("btnBack");
			backbtn = gamenext;
			GameObject gamesound = GameObject.FindGameObjectWithTag ("btnSound");
			soundbtn = gamesound;

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		#endregion // PUBLIC_METHODS




		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			nextbtn.SetActive (true);
			backbtn.SetActive (true);
			soundbtn.SetActive (true);
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
	
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}


		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			GameObject gameobjectArray = GameObject.FindGameObjectWithTag ("btnNext");
			if (gameobjectArray != null) {
				gameobjectArray.SetActive (false);
			}
			gameobjectArray = GameObject.FindGameObjectWithTag ("btnBack");
			if (gameobjectArray != null) {
				gameobjectArray.SetActive (false);
			}
			gameobjectArray = GameObject.FindGameObjectWithTag ("btnSound");
			if (gameobjectArray != null) {
				gameobjectArray.SetActive (false);
			}
			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;

				Debug.Log("ES: "+ component.name);
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
				Debug.Log("ES: "+ component.name);
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

	}
}