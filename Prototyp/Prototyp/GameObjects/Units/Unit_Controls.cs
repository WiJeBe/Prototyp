using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Prototyp
{
/*
	Unit_Controls klassen ska, som namnet antyder, hantera spelarens knapptryckningar och få systemet att reagera korrekt på dessa.
	Se "Bubble-bobble" för exempel på styrfunktioner i plattformsspel
 
	AG-Lista - Se Game1 (längst ner)
*/
	class Unit_Controls : Unit_Animation
	{
	// Variable(s)
		protected PlayerID pID; // Spelar ID, håller kolla på vilken spelaren som charne e skapad för.
		protected Keys[] controlKeys; // [0] = upp (hopp), [1] = höger, [2] = ner (slag/spark), [3] = vänster 
		


	// Constructor
		public Unit_Controls( Vector2 pos, Vector2 vel, Vector2 acc, PlayerID pID ) : base( pos, vel, acc )
		{
			this.pID = pID; // Spelar ID, håller kolla på vilken spelaren som charne e skapad för.
			controlKeys = KeyMouse.Get_PlayerControlKeys( pID ); // Hämtar korrekta styrknappar baserat på spelar ID.
			if( pID == PlayerID.P1 )
				dir = Direction.RIGHT;
			else
				dir = Direction.LEFT;

			Event.KeyPressed += KeyPressed_Check; // Ansluter "KeyPressed_Check" metoden mot "KeyPressed" eventets subscribe-lista (dvs den "lista" med metoder som körs när eventet triggas).
		}


	// Method(s)
		//	Metod för kontroll av höger-pil, vänster-pil, spark/slag-knapp samt hoppknapp. Startas automatiskt när event triggar metoden.
		protected void KeyPressed_Check( Keys k )
		{
			if( k == controlKeys[ 0 ] )
				if( OnTerraFirma )
					Jump();
			
			if( k == controlKeys[ 1 ] )
				TurnRight();
			
			// Om( k == controlKeys[ 2 ] )
			// Starta attack-metoden...
			
			if( k == controlKeys[ 3 ] )
				TurnLeft();
		}

	}
}
