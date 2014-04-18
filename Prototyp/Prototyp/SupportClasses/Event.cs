using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Prototyp
{
	// Delegate(s) - En lista med delegater, fungerar ungefär som en klass (dvs den kan deklareras, anropas etc), med unika namn och inparametrar.
	public delegate void KeyEvent( Keys k );




	static class Event
	{
	// Event(s) - Eventen, som påminner om deklarationen av en klass (dvs när klassen används i koden och blir ett object), skapas med hjälp av delegates.
	public static event KeyEvent KeyPressed;





	// Trigger(s) - Trigger är en metod som används när eventet "rings upp", dvs för att starta ett event anropas trigger-metoden i någon klass. Varje event har en egen trigger. 
	//					 De metoder som anslutits till eventet kommer att starta när själva eventet anropas från triggern. Lite luddigt men bästa förklaringen jag kan ge.
	public static void Start_KeyPressed( Keys k )
	{
		if( KeyPressed != null ) // kontrollerar så att någon klass kopplat upp metoder till eventet
			KeyPressed( k ); // anropar eventet.
	}






	}
}
