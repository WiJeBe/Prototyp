using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
/*
	Unit_Animation klassen kommer att vara ett tomt skal just nu. Tanken är att fylla den med kontroller för sprite-animationer för karaktären.
 
	AG-Lista - Se Game1 (längst ner)
*/
	abstract class Unit_Animation : Unit
	{
	// Variable(s)
	//		-
        protected Rectangle source; // Rektangel för att sen vid animation kunna plocka fram rätt frame
        protected int currentFrame; // Vilken frame som syns för tillfället 
        protected int nrOfFrames; // Antalet frames i x resp y led.
        private float timeSinceLastFrame = 0.0f;
        private float timeBetweenFrames = 100.0f;
	// Constructor
		public Unit_Animation( Vector2 pos, Vector2 vel, Vector2 acc ) : base( pos, vel, acc )
		{
            
			// Constructorn lämnas tom eftersom att den här klassen inte kommer behövas förens vi har spritesheets som ska animeras.
		}

        public override void Update(GameTime gT)
        {
            timeSinceLastFrame += (float)gT.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame >= timeBetweenFrames)
            {
                timeSinceLastFrame -= timeBetweenFrames;
                currentFrame++;

                if (currentFrame >= nrOfFrames)
                {
                    currentFrame = 0;
                }
            }
            source.X = currentFrame * tex.Width / nrOfFrames;

            base.Update(gT);
        }

	// Method(s)
	//		-
	}
}
