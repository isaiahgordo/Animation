using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D brownT, creamT, greyT, orangeT,whiteT,introT;
        Rectangle brownR, creamR, greyR, orangeR,whiteR,introR;
        Vector2 brownV, creamV,greyV,orangeV, mouseR;
        MouseCursor no,now;
        MouseState mS, mouseState;
        Srceen srceen;
        enum Srceen 
        { 
            Intro,
            TribleYard
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            brownR = new Rectangle(300, 10, 100, 100);
            creamR = brownR;
            creamR.X = 10;
            creamR.Y = 300;greyR = brownR;
            orangeR = brownR;
            greyR.X = 150;
            greyR.Y = 150;
            orangeR.X = 50;
            orangeR.Y = 50;
            brownV = new Vector2(0, 2);
            creamV = new Vector2(2, 2);
            greyV=new Vector2(2, 0);
            orangeV=new Vector2(5, 3);
            now = MouseCursor.Arrow;
            no=MouseCursor.No;
            whiteR = new Rectangle(-10, -10, 50, 50);
            _graphics.PreferredBackBufferHeight = 500;
            introR = new Rectangle(0, 0, 800, 500);
            _graphics.ApplyChanges();
            //people
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //dads home
            // TODO: use this.Content to load your game content here
            brownT=Content.Load<Texture2D>("tribbleBrown");
            creamT = Content.Load<Texture2D>("tribbleCream");
            greyT = Content.Load<Texture2D>("tribbleGrey");
            orangeT = Content.Load<Texture2D>("tribbleOrange");
            whiteT = Content.Load<Texture2D>("white");
            introT = Content.Load<Texture2D>("introScreen");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseR = Mouse.GetState().Position.ToVector2();
            KeyboardState kstate=Keyboard.GetState();
            // TODO: Add your update logic here
            mouseState=Mouse.GetState();
            if (srceen == Srceen.Intro)
                if (mouseState.LeftButton == ButtonState.Pressed)
                    srceen = Srceen.TribleYard;
                else;
            else if (srceen == Srceen.TribleYard)
            {
                if (kstate.IsKeyDown(Keys.A))
                { whiteR.X = (int)mouseR.X; whiteR.Y = (int)mouseR.Y; }
                if (greyR.Right > 800 || greyR.Left < 0)
                    greyV.X *= -1;
                greyR.X += (int)greyV.X;
                if (brownR.Top < 0 || brownR.Bottom > 500)
                    brownV.Y *= -1;
                brownR.Y += (int)brownV.Y;
                if (creamR.Top < 0 || creamR.Bottom > 500)
                    creamV.Y *= -1;
                else if (creamR.Right > 800 || creamR.Left < 0)
                    creamV.X *= -1;
                creamR.Y += (int)creamV.Y;
                creamR.X += (int)creamV.X;
                if (orangeR.Top < 0 || orangeR.Bottom > 500)
                    orangeV.Y *= -1;
                else if (orangeR.Right > 800 || orangeR.Left < 0)
                    orangeV.X *= -1;
                orangeR.X += (int)orangeV.X;
                orangeR.Y -= (int)orangeV.Y;
                if (brownR.Contains(mouseR) && no != now)
                {
                    now = MouseCursor.No;
                    brownR.Height += 10;
                    brownR.Width += 10;
                }
                else if (brownR.Contains(whiteR))
                {
                    brownR.Height += 10;
                    brownR.Width += 10;
                    whiteR.X = -10;
                    whiteR.Y = -10;
                }
                if (brownR.Width > Window.ClientBounds.Width && brownR.Height > Window.ClientBounds.Height)
                    base.Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (srceen == Srceen.Intro)
                _spriteBatch.Draw(introT, introR, Color.White);
            else if(srceen==Srceen.TribleYard)
            { 
            _spriteBatch.Draw(brownT, brownR, Color.White);
            _spriteBatch.Draw(creamT, creamR, Color.White);
            _spriteBatch.Draw(greyT, greyR, Color.White);
            _spriteBatch.Draw(orangeT, orangeR, Color.White);
            _spriteBatch.Draw(whiteT, whiteR, Color.White); }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}