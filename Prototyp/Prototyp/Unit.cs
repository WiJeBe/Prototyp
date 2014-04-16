using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Prototyp
{
	/*
	 * Läs Texten i Game1 innan du börjar!!!!!!!!!
	 Unit är huvudklass för karaktärer som spelaren/spelarna kan kontrollera.
	 Klassen ska innehålla metoder för löpning (sidled), hopp och kollision, utförandet inte triggandet av.
	  
	 AG-Lista:
	 () Ersätt psudokod med riktig syntax
	 () korrigera och testa tills metoderna fungerar.
	 Tip: Kan vara bra att implementera Unit_Control klassen före testning så kan två klasser testas samtidigt. 
	 */	
	class Unit : Object
	{
	// Variable(s)
		


	// Constructor
		// konstruktorn är fylld med dummy-värden bara för att få något utritat
		public Unit( Vector2 pos ) : base ( pos, Vector2.Zero, Vector2.Zero )
		{
			
		}

	// Method(s)
		/*
			Metoden är tänkt att triggas när spelaren byter riktning (höger -> vänster eller tvärt om). Genom att multiplicera riktningsvektorns x-koordinat med -1 så kommer
			karaktären alltid att vända sig åt rätt håll, förutsatt att vel-vektorn ges korrekta värden från början.
		*/
		// protected void Sväng Höger / Vänster
		//		Multiplicera vel-vektorns x-axel med -1
		//			~ vel vektorn ärvs från "Objects" klassen.


		/* 
		 Är osäker på om den här metoden är applicerbar. Tanken är att när spelaren håller nere "<-- knappen" eller "--> knappen" så ska hastigheten öka i dne riktningen som motsvarar pilen.
		 Knappkontrollen görs inte här utan i Unit_Control klassen men den här metoden ska triggas så länge knappkontrollen returnerar godkänt. Sry för den dåliga förklaringen ska försöka speca upp dne bättre 
		 under morgondagen. Försöker bara få upp nått till GitHub just nu.
		*/
		protected void MoveSideways( GameTime gT )
		{
			pos.X += vel.X * (float)gT.ElapsedGameTime.TotalSeconds + ( ( acc.X * (float)Math.Pow( gT.ElapsedGameTime.TotalSeconds, 2) ) / 2 ); 
         vel.X += acc.X * (float)gT.ElapsedGameTime.TotalSeconds;  
		}
	}
}
