using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Prototyp
{
	/* Unit är huvudklass för karaktärer som spelaren/spelarna kan kontrollera.
	   Klassen ska innehålla metoder för löpning (sidled), hopp och kollision, utförandet inte triggandet av.
	  
	   AG-Lista - Se Game1 (längst ner)
	 */	
	abstract class Unit : Object
	{
	// Variable(s)
		public bool OnTerraFirma { protected set; get; }
		protected Direction dir;

	// Constructor
		// konstruktorn är fylld med dummy-värden bara för att få något utritat
		public Unit( Vector2 pos, Vector2 vel, Vector2 acc ) : base ( pos, vel, acc )
		{
			
		}

	// Method(s)
		/*	Metoden är tänkt att triggas när spelaren byter riktning (höger -> vänster eller tvärt om). Genom att multiplicera x-koordinaten med -1 så kommer
			karaktären alltid att vända sig åt rätt håll, förutsatt att vel- och acc-vektorerna ges korrekta värden från början. */
		protected void TurnRight()
		{
			if( dir != Direction.RIGHT )
			{
				acc.X *= -1;
				vel.X = 1;
				dir = Direction.RIGHT;
			}
		}

		protected void TurnLeft()
		{
			if( dir != Direction.LEFT )
			{
				acc.X *= -1;
				vel.X = -1;
				dir = Direction.LEFT;
			}
		}

		/* Rörelse i sidled baserat på Direction och max-hastihghet (vel.X värde ). Om karaktären befinner sig på marken/plattform blir acerelationen högre än om den faller. */
		protected void MoveLeftRight( GameTime gT )
		{
			pos.X += vel.X * (float)( gT.ElapsedGameTime.TotalSeconds );
			
			if( ( dir == Direction.RIGHT && vel.X < 60 ) || ( dir == Direction.LEFT && vel.X > -60 ) )
			{
				if( !OnTerraFirma )
					vel.X += acc.X * (float)gT.ElapsedGameTime.TotalSeconds; 	
				else
					vel.X += ( acc.X * 2 ) * (float)gT.ElapsedGameTime.TotalSeconds;		
			}	
		}
		
		/* Sätter avstampshastigheten för upphopp så att karaktären kan hoppa...*/
		protected void Jump()
		{
			vel.Y = -50;
			OnTerraFirma = false;
		}

		
	}
}
