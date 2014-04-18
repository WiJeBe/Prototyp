using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Prototyp
{
/* Tänkt att innehålla metoder för avläsning av Mus och Tangentbord. Se Olles "Key-Mouse-Reader" kod på IL om du behöver något som inte implementerats ännu. */
	static class KeyMouse
	{
	// Variable(s)
		public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
		//public static MouseState mouseState, oldMouseState = Mouse.GetState();
		private static List<Keys> keyWatch = AddKeysToWatchList();

		
	// Constructor
	//		-


	// Method(s)
		// Uppdaterar statusen för key och mouse states.
		public static void Update()
		{
			oldKeyState = keyState;
			keyState = Keyboard.GetState();
			//oldMouseState = mouseState;
			//mouseState = Mouse.GetState();
			NewKeyPress_Check();
		}

		/* kontrollerar om någon av de övervakade knapparna nyligen blivit nedtryckt */
		private static void NewKeyPress_Check()
		{
			for( int i = 0; i < keyWatch.Count; ++i )
				if( KeyPressed( keyWatch[i] ) )
					Event.Start_KeyPressed( keyWatch[ i ] ); 
		}

		/* kollar om en specifik knapp nyligen blivit nedtryckt */
		public static bool KeyPressed( Keys key )
		{
			return keyState.IsKeyDown( key ) && oldKeyState.IsKeyUp( key );
		}

		/* kontrollerar om en specifik knapp hållits nere sen senaste uppdateringen */
		public static bool KeyHeld( Keys key )
		{
			return keyState.IsKeyDown( key ) && oldKeyState.IsKeyDown( key );
		}





		/* Kontrollerar det medskickade PlayerID, från Unit_Control klassen...
			...och returnerar korrekt key-array baserat på "värdet" på PlayerID. */
		public static Keys[] Get_PlayerControlKeys( PlayerID pID )
		{
			if( pID == PlayerID.P1 )
			{
				Keys[] k = { Keys.Up, Keys.Right, Keys.Down, Keys.Left };
				return k;
			}
			else
			{
				Keys[] k = { Keys.W, Keys.D, Keys.S, Keys.A };
				return k;	
			}
		}

		/* Lägger till samtliga knappar som systemet behöver kontrollera i en kontrollista så att förändringar för dessa kan lyssnas efter */
		private static List<Keys> AddKeysToWatchList()
		{
			Keys[] i = Get_PlayerControlKeys( PlayerID.P1 );
			Keys[] j = Get_PlayerControlKeys( PlayerID.P2 );
			List<Keys> k = new List<Keys>();
			foreach( Keys key in i )
				k.Add( key ); 
			foreach( Keys key in j )
				k.Add( key ); 
			return k;
		}



	}
}
