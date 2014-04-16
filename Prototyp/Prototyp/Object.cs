﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
 /*
	Object är huvudklassen både för spelarnas karaktärer ( "Unit" ) och för platformarna ( "Pads" ).
	Innehåller mekanik för att hantera gravitationens verkan på objekt över tid.
   
	AG-Lista:
	() Matematiken i "Gravity" metoden behöver ses över av någon som känner sig mer säker på ämnet än jag. 
 */
	class Object
	{
	// Variable(s)
		protected Vector2 pos; // objektets nuvarande position på spelplanen
		protected Vector2 vel; // objektets riktningsvektor både i x- och y-led.
		protected Vector2 acc; // objektets hastighetsökning.
		public bool Alive { protected set; get; }

	// Constructor
		public Object( Vector2 pos, Vector2 vel, Vector2 acc )
		{
			this.pos = pos;
			this.vel = vel;
			this.acc = acc;
			Alive = true;
		}


	// Method(s)
		public virtual void Update( GameTime gT )
		{
			Gravity( gT );
		}

		public virtual void Draw( SpriteBatch sB )
		{
			// Grundläggande ritmetod, endast tillagd för att alla objekt skall ha en sådan. Gör absolut ingenting.
		}

		// Hanterar gravitationens påverkan på objektet över tid.
		protected void Gravity( GameTime gT )
		{
			pos.Y += vel.Y * (float)gT.ElapsedGameTime.TotalSeconds + ( ( acc.Y * (float)Math.Pow( gT.ElapsedGameTime.TotalSeconds, 2) ) / 2 ); // Förändrar positionsvektorn med hastigheten multiplicerat med totala tiden.
         vel.Y += acc.Y * (float)gT.ElapsedGameTime.TotalSeconds; // Förändrar hastighetsvektorn med acc-vektorn multiplicerat med den totala tiden.  
		}
	}
}