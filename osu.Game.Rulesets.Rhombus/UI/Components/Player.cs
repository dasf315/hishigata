using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Rhombus.Objects.Drawables;

namespace osu.Game.Rulesets.Rhombus.UI.Components
{
    public class PlayerVisual : CompositeDrawable, IKeyBindingHandler<RhombusAction>
    {
        public PlayerVisual()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(100);
            InternalChildren = new Drawable[]{
                new Container{
                    RelativeSizeAxes = Axes.Both,
                    Anchor= Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.White,
                    BorderThickness = 20,
                    Rotation= 45,
                    Children = new Drawable[]{
                        new Box{
                            RelativeSizeAxes = Axes.Both,
                            Alpha= 0,
                            AlwaysPresent = true
                        },
                        new SpriteIcon{
                            Icon = FontAwesome.Solid.ChevronUp,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Size = new Vector2(50),
                            Rotation = -45,
                        }
                    }
                }
            };
        }

        public bool CanBeHit(DrawableRhombusHitObject hitObject) => hitObject.HitObject.Lane == ((int)Rotation / 90);

        public bool OnPressed(RhombusAction action)
        {
            Rotation = 90 * (int)action;
            return true;
        }
        public void OnReleased(RhombusAction action) { }
    }
}
