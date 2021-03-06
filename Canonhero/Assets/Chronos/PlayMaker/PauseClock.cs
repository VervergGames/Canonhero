﻿#if CHRONOS_PLAYMAKER

using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using HutongGames.PlayMaker.Actions;

namespace Chronos.PlayMaker
{
	[ActionCategory("Chronos")]
	[Tooltip("Pauses or unpauses a clock.")]
	[HelpUrl("http://ludiq.io/chronos/documentation#Clock.paused")]
	public class PauseClock : ChronosComponentAction<Clock>
	{
		[RequiredField]
		[CheckForComponent(typeof(Clock))]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		public FsmBool paused;

		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			paused = null;
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

			clock.paused = paused.Value;
		}
	}
}

#endif