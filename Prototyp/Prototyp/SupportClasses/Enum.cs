using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototyp
{
/* Enum hjälper till att göra koden tydligare efterom att de tillåter en att använda text istället för tex. 1 och 2. 
	Enums måste placeras i namespace delen för att kunna nå hela koden (alla klasser som delar samma namespace) */

// Enum Lista
	public enum PlayerID{ P1, P2 } // ID som berättar vilken spelare som äger karaktären. Behövs för att tilldela korrekta styrknappar
	
	public enum Direction{ LEFT, RIGHT } // kontroll för vilket håll karaktären rör sig år just nu.
	
	// fyll på med fler enums vd behov.
	
	
	
// Ignorera klassen! För den fyller inget syfte just nu.	 
	abstract class Enum
	{	}
}
