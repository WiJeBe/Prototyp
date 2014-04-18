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
     Att l�sa!
     Hej!
     N�r du, blir mer v�lkomnande och personligt n�r jag s�ger "du", kollar runt i klasserna kommer du se att det mest bara �r ol�sligt kladd som st�r d�r. 
     Jag ber om urs�kt f�r det faktumet och lovar att se �ver formuleringar och tankeg�ngar under dagen imorgon. Har du �nd� fr�gor kan jag n�s via min 
     mail (JvAulin@gmail.com), skype (joakim.aulin) eller telefon (0704946874). Telefonen �r knasig s� om du inte kommer fram p� den, skicka ett mess s� 
     ringer jag upp. 
     Om du promt vill b�rja p� en del imorgon eller inatt s� rekomenderar jag platformarna, normal-varianten. N�r du f�tt dom att fungera korrekt kan du
     bygga en antingen en manager klass eller metod (metoden i Game1 f�rslagsvis) som styr intervallet f�r sl�pp av nya Pads.
     // JvA
     */
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sB;

        public static int screenWidth, screenHeight; // Storleken p� f�nstret

        Unit_Char p1;
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
            Textures.LoadTextures(Content);

            IsMouseVisible = true;

            p1 = new Unit_Char(new Vector2(100, 100), new Vector2(2, 2), new Vector2(40, 9.81f), PlayerID.P1);

            // Storleken p� f�nstret s�tts
            screenHeight = graphics.PreferredBackBufferHeight = 600;
            screenWidth = graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();


            // skapar en padManager variabel och skickar med spelaren
            padManager = new PadManager(p1);
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
 ATT-G�RA LISTA!
 - = Ej p�b�rjad
 * = P�b�rjad
 V = Klar
Namn	:	Status	:		Uppgift 
		:		-		:	Anpassa acc-variabeln s� att karakt�ren "bromsar in" vid riktningsbyte
		:		-		:	G�r s� att acc minskar om spelaren inte h�ller inne en "sido-styrnings knapp" 
JvA	:		V		:	Implementera metoder f�r styrningskontroll.
JvA	:		V		:	Koppla ihop styrningskontrollerna med metoderna i Unit s� att enheten kan utf�ra n�got n�r kontrollen anv�nds.
JvA	:		*		:	Matematiken i "Gravity" metoden beh�ver ses �ver av n�gon som k�nner sig mer s�ker p� �mnet �n jag. //JvA
 
 
 
 */