using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
/*
	Nedersta ledet i Unit-hierarkin. "Char" är den karaktär som kommer att ritas ut på spelplanen. Om vi bestämmer oss för att göra många olika så gör vi dessa som unika chars med egna specialförmågor etc.
  Så ser tankemodellen ut i alla fall.
 
  AG-Lista - Se Game1 (längst ner)
 */
	class Unit_Char : Unit_Controls
	{
	// Variable(s)
        

	// Constructor
		public Unit_Char( Vector2 pos, Vector2 vel, Vector2 acc, PlayerID pID ) : base( pos, vel, acc, pID )
		{
			tex = Textures.Texture_Dummy;
			//OnTerraFirma = true;
            HitBox = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
		}

	//Method(s)
		public override void Update( GameTime gT )
		{
			// Om karaktären befinner sig på marken så uppdateras inte gravitationen
			if( !OnTerraFirma )
				base.Update( gT );

			// Om antingen vänster-knappen eller höger-knappen hålls inne så förflyttar sig karaktären i gällande riktning
			if( KeyMouse.KeyHeld( controlKeys[ 1 ] ) || KeyMouse.KeyHeld( controlKeys[ 3 ] ) )
				MoveLeftRight( gT );

            HitBox = new Rectangle((int)pos.X, (int)pos.Y, 50, 50); // Uppdaterar hitbox-rektangelns värden.
		}

        

		public override void Draw( SpriteBatch sB )
		{
			sB.Draw( tex, HitBox, Color.Red );
		}


	}
}
