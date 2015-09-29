﻿#if CHRONOS_PLAYMAKER

using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using HutongGames.PlayMaker.Actions;

namespace Chronos.PlayMaker
{
	[ActionCategory("Chronos")]
	[Tooltip("Sets the time scale on a clock.")]
	[HelpUrl("http://ludiq.io/chronos/documentation#Clock.localTimeScale")]
	public class ScaleClockTime : ChronosComponentAction<Clock>
	{
		[RequiredField]
		[CheckForComponent(typeof(Clock))]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		public FsmFloat timeScale;

		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			timeScale = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoAction();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoAction();
		}

		void DoAction()
		{
			if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject))) return;

			clock.localTimeScale = timeScale.Value;
		}
	}
}

#endif