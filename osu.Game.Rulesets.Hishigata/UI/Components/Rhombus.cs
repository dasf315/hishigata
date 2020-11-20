using osu.Framework.Audio.Track;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Utils;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osuTK;
using osuTK.Graphics;
using System;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class Rhombus : BeatSyncedContainer
    {
        public Rhombus()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.None;
            Size = new Vector2(450);
            Rotation = 45;
            Masking = true;
            BorderColour = Color4.Gray;
            BorderThickness = 10;
            Child = new Box
            {
                Colour = Color4.Black,
                RelativeSizeAxes = Axes.Both,
                Alpha = .8f
            };
        }

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            if (amplitudes.Maximum <= .01f) return;
            FinishTransforms();
            this.ResizeTo(effectPoint.KiaiMode ? 459f : 454.5f, 100).Then().ResizeTo(450, 50);
        }
    }
}