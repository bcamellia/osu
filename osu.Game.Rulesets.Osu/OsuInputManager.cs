﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Input.States;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Osu
{
    public class OsuInputManager : RulesetInputManager<OsuAction>
    {
        public IEnumerable<OsuAction> PressedActions => KeyBindingContainer.PressedActions;

        public bool AllowUserPresses
        {
            set => ((OsuKeyBindingContainer)KeyBindingContainer).AllowUserPresses = value;
        }

        protected override RulesetKeyBindingContainer CreateKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
            => new OsuKeyBindingContainer(ruleset, variant, unique);

        public OsuInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }

        private class OsuKeyBindingContainer : RulesetKeyBindingContainer
        {
            public bool AllowUserPresses = true;

            public OsuKeyBindingContainer(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique)
                : base(ruleset, variant, unique)
            {
            }

            protected override bool OnKeyDown(KeyDownEvent e) => AllowUserPresses && base.OnKeyDown(e);
            protected override bool OnKeyUp(KeyUpEvent e) => AllowUserPresses && base.OnKeyUp(e);
            protected override bool OnJoystickPress(InputState state, JoystickEventArgs args) => AllowUserPresses && base.OnJoystickPress(args);
            protected override bool OnJoystickRelease(InputState state, JoystickEventArgs args) => AllowUserPresses && base.OnJoystickRelease(args);
            protected override bool OnMouseDown(MouseDownEvent e) => AllowUserPresses && base.OnMouseDown(e);
            protected override bool OnMouseUp(MouseUpEvent e) => AllowUserPresses && base.OnMouseUp(e);
            protected override bool OnScroll(ScrollEvent e) => AllowUserPresses && base.OnScroll(e);
        }
    }

    public enum OsuAction
    {
        [Description("Left Button")]
        LeftButton,

        [Description("Right Button")]
        RightButton
    }
}
