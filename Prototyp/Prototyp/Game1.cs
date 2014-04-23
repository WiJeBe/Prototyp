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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sB;

        
		  // Test-grejer
        Unit_Char p1;
        PadManager padManager;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            sB = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
				Textures.LoadTextures(Content);

            

            p1 = new Unit_Char(new Vector2(100, 100), new Vector2(2, 2), new Vector2(40, 9.81f), PlayerID.P1);

            // Storleken på fönstret sätts
            Constants.SCREEN_HEIGHT = graphics.PreferredBackBufferHeight = 600;
            Constants.SCREEN_WIDTH = graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();


            // skapar en padManager variabel och skickar med spelaren
            padManager = new PadManager( /*p1 */ );
        }


        protected override void UnloadContent()
        { }


        protected override void Update(GameTime gT)
        {
            // Esc avslutar spelet...
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            KeyMouse.Update();
            padManager.Update(gT);
            p1.Update(gT);

            

            base.Update(gT);
        }


        protected override void Draw(GameTime gT)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sB.Begin();

            p1.Draw(sB);
            padManager.Draw(sB);

            sB.End();

            base.Draw(gT);
        }
    }
}
/*
 ATT-GÖRA LISTA!
 - = Ej påbörjad
 * = Påbörjad
 V = Klar
Namn	:	Status	:		Uppgift 
		:		-		:	Anpassa acc-variabeln så att karaktären "bromsar in" vid riktningsbyte
		:		-		:	Gör så att acc minskar om spelaren inte håller inne en "sido-styrnings knapp" 
JvA	:		V		:	Implementera metoder för styrningskontroll.
JvA	:		V		:	Koppla ihop styrningskontrollerna med metoderna i Unit så att enheten kan utföra något när kontrollen används.
JvA	:		*		:	Matematiken i "Gravity" metoden behöver ses över av någon som känner sig mer säker på ämnet än jag. //JvA
 
 
 
 */