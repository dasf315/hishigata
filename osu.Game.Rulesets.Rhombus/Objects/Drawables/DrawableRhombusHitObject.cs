﻿
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics.Containers;
using System;

namespace osu.Game.Rulesets.Rhombus.Objects.Drawables
{
    public class DrawableRhombusHitObject : DrawableHitObject<RhombusHitObject>
    {
        protected override double InitialLifetimeOffset => HitObject.TimePreempt;
        public DrawableRhombusHitObject(RhombusHitObject hitObject)
            : base(hitObject)
        {
            Position = new Vector2(0, -300);
            Size = new Vector2(40);
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            AddInternal(new SpriteIcon
            {
                RelativeSizeAxes = Axes.Both,
                Icon = FontAwesome.Solid.ChevronDown,
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre
            });
        }

        public Func<DrawableRhombusHitObject, bool> CanBeHit;

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
            {
                if (CanBeHit?.Invoke(this) ?? false)
                    ApplyResult(r => r.Type = HitResult.Perfect);
                else
                    ApplyResult(r => r.Type = HitResult.Miss);
            }
        }

        protected override void UpdateInitialTransforms()
        {
            base.UpdateInitialTransforms();
            this.MoveTo(new Vector2(0, -80), HitObject.TimePreempt);
        }


        protected override void UpdateStateTransforms(ArmedState state)
        {
            const double duration = 300;

            switch (state)
            {
                case ArmedState.Hit:
                    this.FadeOut().Expire();
                    break;

                case ArmedState.Miss:

                    this.FadeColour(Color4.Red, duration);
                    this.FadeOut(duration, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
