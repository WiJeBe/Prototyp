﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
/* 
	Pad är huvudklass för alla platformstyper, men fungerar också som "normal" versionen av platformarna.
	Innehåller en HitBox som används för kollision med "Units". Innehåller variabel för Padens textur.
	
	AG-Lista - Se Game1 (längst ner)
*/
	class Pad : Object
	{
	// Variable(s)
		protected int width, height;
        

	// Constructor(s)
		// Constructor no.1: Används av andra Pad classer för att initialisera variabler uppåt i hierarkin.
		public Pad( Vector2 pos, float accLR = 0 ) : base( pos, new Vector2( 0, 1 ), new Vector2( accLR, 9.81f ) )
		{		}  
		
		// Constructor no.2: Används när "Pad" skall användas som en "Normal"-plattform, dvs en platform som bara faller lodrät och inget annat.
		public Pad( Vector2 pos, Point padWidthHeight ) : base( pos, new Vector2( 0, 0.4f ), new Vector2( 0, 9.81f ) )
		{
			tex = Textures.Texture_Dummy;
			width = padWidthHeight.X;
			height = padWidthHeight.Y;
		}

	// Method(s)
		public override void Update( GameTime gT )
		{
            pos += vel;
            //base.Update( gT ); // kör Objects update metod (gravitationen)
				if( (int)pos.Y >= Constants.SCREEN_HEIGHT + height/2 )
					Alive = false;
					 
				hitBox = new Rectangle( (int)pos.X, (int)pos.Y, width, height ); // Uppdaterar hitbox-rektangelns värden.
		}


		public override void Draw( SpriteBatch sB )
		{
            if (Alive) // Ritar ut endast om det är true
			    sB.Draw( tex, hitBox, Color.Bisque ); // ritar ut paden.
		}
	}
}
