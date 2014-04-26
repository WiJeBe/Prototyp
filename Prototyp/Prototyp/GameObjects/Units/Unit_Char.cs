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
			tex = Textures.Texture_Bobble;
            currentFrame = 0;
            nrOfFrames = 8;
            source = new Rectangle(currentFrame * tex.Width / nrOfFrames, 0, tex.Width / nrOfFrames, tex.Height);
			//OnTerraFirma = true;
            // Sätter hitboxen så att den endast hamnar vid benen på gubben, som gör att inte hela texturen kolliderar med plattform
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, source.Width, source.Height - 24);
            hitBox.Y = hitBox.Y + 25;
		}

	//Method(s)
		public override void Update( GameTime gT )
		{
			// Om karaktären befinner sig på marken så uppdateras inte gravitationen
            //if( !OnTerraFirma )
				base.Update( gT );

			// Om antingen vänster-knappen eller höger-knappen hålls inne så förflyttar sig karaktären i gällande riktning
			if( KeyMouse.KeyHeld( controlKeys[ 1 ] ) || KeyMouse.KeyHeld( controlKeys[ 3 ] ) )
				MoveLeftRight( gT );

            // Uppdaterar hitbox-rektangelns värden.
            hitBox.X = (int)(pos.X >= 0 ? pos.X + 0.5f : pos.X - 0.5f);
            hitBox.Y = (int)(pos.Y >= 0 ? pos.Y + 0.5f : pos.Y - 0.5f);
            hitBox.Y = hitBox.Y + 25; 

           
		}


     
//Hanterar kollision med plattformarna. Skickar med plattformen man hoppar till.
        public void HandleCollision(Object o)
        {
            //if (!OnTerraFirma)
            //{
                hitBox.Y = o.hitBox.Y - source.Height + 1;

                pos.Y = hitBox.Y;
                pos.X = hitBox.X;
                OnTerraFirma = true;
                hitBox.Y = hitBox.Y + 25;
            //}
        }

        

		public override void Draw( SpriteBatch sB )
		{
			sB.Draw( tex, pos, source, Color.White );
            //sB.Draw(tex, hitBox, Color.Red);
		}


	}
}
