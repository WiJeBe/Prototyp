using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
/* Tänkt att innehålla alla texturer som ska användas i spelet. Fyller egentligen ingen funktion nu eftersom att vi bara har ne fin vit ruta att leka med.*/
	static class Textures
	{
	// Variable(s) - Texturer...
		public static Texture2D Texture_Dummy { set; get; }
        public static Texture2D Texture_Bobble { set; get; }		


	// Constructor - Statiska metoder behöver ingen konstruktor

	// Method()
		public static void LoadTextures( ContentManager Content )
		{
			Texture_Dummy = Content.Load<Texture2D>( @"Textures/WhiteSqr" );
            Texture_Bobble = Content.Load<Texture2D>(@"Textures/Bubble_walk");
			// Fyll på med texturer här vid behov...
		}

	}
}
