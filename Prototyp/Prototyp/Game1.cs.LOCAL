using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Prototyp
{
    /*
     Att läsa!
     Hej!
     När du, blir mer välkomnande och personligt när jag säger "du", kollar runt i klasserna kommer du se att det mest bara är oläsligt kladd som står där. 
     Jag ber om ursäkt för det faktumet och lovar att se över formuleringar och tankegångar under dagen imorgon. Har du ändå frågor kan jag nås via min 
     mail (JvAulin@gmail.com), skype (joakim.aulin) eller telefon (0704946874). Telefonen är knasig så om du inte kommer fram på den, skicka ett mess så 
     ringer jag upp. 
 
     Om du promt vill börja på en del imorgon eller inatt så rekomenderar jag platformarna, normal-varianten. När du fått dom att fungera korrekt kan du
     bygga en antingen en manager klass eller metod (metoden i Game1 förslagsvis) som styr intervallet för släpp av nya Pads.
  
     // JvA
 
     */
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sB;

        public static int screenWidth, screenHeight; // Storleken på fönstret

        public static Texture2D PlatformTexture_Dummy { protected set; get; }
        PadManager padManager;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            sB = new SpriteBatch(GraphicsDevice);

            IsMouseVisible = true;

            // Storleken på fönstret sätts
            screenHeight = graphics.PreferredBackBufferHeight = 600;
            screenWidth = graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            // Laddar in platformstexturen
            PlatformTexture_Dummy = Content.Load<Texture2D>(@"WhiteSqr");

            // skapar en padManager variabel
            padManager = new PadManager();
        }


        protected override void UnloadContent()
        { }


        protected override void Update(GameTime gameTime)
        {
            // Esc avslutar spelet...
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //Uppdatera padmanager
            padManager.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sB.Begin();

            // Ritar ut padManager
            padManager.Draw(sB);
                
            sB.End();
            base.Draw(gameTime);
        }
    }
}
