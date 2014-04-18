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


	// Constructor
		public Unit_Animation( Vector2 pos, Vector2 vel, Vector2 acc ) : base( pos, vel, acc )
		{
			// Constructorn lämnas tom eftersom att den här klassen inte kommer behövas förens vi har spritesheets som ska animeras.
		}


	// Method(s)
	//		-
	}
}
