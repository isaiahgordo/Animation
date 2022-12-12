using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D brownT, creamT, greyT, orangeT,introT;
        Rectangle introR;        
        MouseState  mouseState;
        Srceen srceen;
        List<Tribble> tribbes;
        Tribble trible,tribble,tri,ble;
        Random r;
        int gPH, gPW;
        float seconds,startTime;
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
            _graphics.PreferredBackBufferHeight = 500;
            gPH=_graphics.PreferredBackBufferHeight;
            gPW=_graphics.PreferredBackBufferWidth;
            introR = new Rectangle(0, 0, 800, 500);
            _graphics.ApplyChanges();
            r=new Random();
            tribbes = new List<Tribble>(7) ;
            base.Initialize();
            trible = new Tribble(brownT, new Rectangle(300, 10, 100, 100), new Vector2(0, 2), Color.White);
            tribble = new Tribble(creamT, new Rectangle(10, 300, 100, 100), new Vector2(2, 2), Color.White);
            tri = new Tribble(greyT, new Rectangle(150, 150, 100, 100), new Vector2(2, 0), Color.White);
            ble = new Tribble(orangeT, new Rectangle(50, 50, 100, 100), new Vector2(5, 3), Color.White);
            tribbes.Add(trible);
            tribbes.Add(tribble);
            tribbes.Add(tri);
            tribbes.Add(ble);
            tribbes.Add(new Tribble(tribble.texture,tribble.bounds,tribble.speed,Color.Pink));
            tribbes.Add(new Tribble(tribble.texture, tribble.bounds, tribble.speed, Color.LightBlue));
            tribbes.Add(new Tribble(tribble.texture, tribble.bounds, tribble.speed, Color.Yellow));
            tribbes[4].bounds = new Rectangle(r.Next(gPW - 100), r.Next(gPH - 100), 100, 100);
            tribbes[5].bounds = new Rectangle(r.Next(gPW - 100), r.Next(gPH - 100), 100, 100);
            tribbes[6].bounds = new Rectangle(r.Next(gPW - 100), r.Next(gPH - 100), 100, 100);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);            
            // TODO: use this.Content to load your game content here
            brownT =Content.Load<Texture2D>("tribbleBrown");
            creamT = Content.Load<Texture2D>("tribbleCream");
            greyT = Content.Load<Texture2D>("tribbleGrey");
            orangeT = Content.Load<Texture2D>("tribbleOrange");            
            introT = Content.Load<Texture2D>("intoScreen");            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds=(float)gameTime.TotalGameTime.TotalSeconds-startTime;
            // TODO: Add your update logic here
            mouseState=Mouse.GetState();
            if (srceen == Srceen.Intro)
                if (mouseState.LeftButton == ButtonState.Pressed)
                { 
                    srceen = Srceen.TribleYard;
                    startTime = (float)gameTime.TotalGameTime.TotalSeconds;
                }
            if (srceen == Srceen.TribleYard)
            {
                foreach (var tibble in tribbes)
                    tibble.Move(_graphics);
                if (seconds > 15)
                    this.Exit();
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
              foreach(var tibble in tribbes)  
                tibble.Draw(_spriteBatch);
              
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}