using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
    /* 
     PadManager sköter allt som rör plattformarna. 
     */

    class PadManager
    {
		// Variable(s)
        public List<Pad> pads; // Lista med plattformar
			// Unit_Char p1; // Håller reda på kollision med spelare
			//	Point padSize;
			//	Random random;
			// float startPosPadsY = 100f; // Var plattformarna startar i Y-led
			//  int column = 150; // Skärmen är indelad i kolumner och detta är bredden på kolumnen

		  private double counter; // Räknare för intervallet mellan spawn-omgångar av pads.



		// Constructor
        public PadManager( /*Unit_Char p1 */ )
        {
            //this.p1 = p1;
            pads = new List<Pad>(); // skapar listan
				//random = new Random();

				//padSize = new Point(100, 10);

				//StartingPads();
				PadsSetup(); // Räknar ut antal och placering av startpadsen på skärmen
            
				counter = 0;
        }

		// Method(s)
			private void PadsSetup()
			{
				for( int i = 0; i < 5; ++i )
					AddNewPad_Normal( 100 * (i+1) );
			}




		  //// Stamdard mall för plattformarna vid start av spel
		  //private void StartingPads()
		  //{
		  //    pads.Add(new Pad(new Vector2(column * 0, 500), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 1, 300), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 2, 100), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 3, 200), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 4, 500), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 5, 400), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 1, 200), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 2, 200), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 2, 100), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 5, 300), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 4, 200), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 3, 300), padSize));
		  //    pads.Add(new Pad(new Vector2(column * 1, 500), padSize));

		  //}

		  ///// <summary>
		  ///// Skapar en plattform. Jag har delat in skrämen i 5 delar och slumpar ut vart de ska dyka upp.
		  ///// </summary>
		  ///// <param name="pos">Positionen på plattformen</param>
		  ///// <param name="size">Width och height på plattformen</param>
		  //public void CreateAPad(Vector2 prevPos, Point size)
		  //{
		  //    Vector2 pos = new Vector2();

		  //    int randomNr = random.Next(1, 6);


		  //    random.Next(1, 6);
		  //    if (randomNr == 1)
		  //    {
		  //        pos = new Vector2(column * 1, startPosPadsY);
		  //    }
		  //    else if (randomNr == 2)
		  //    {
		  //        pos = new Vector2(column * 2, startPosPadsY);
		  //    }
		  //    else if (randomNr == 3)
		  //    {
		  //        pos = new Vector2(column * 3, startPosPadsY);
		  //    }
		  //    else if (randomNr == 4)
		  //    {
		  //        pos = new Vector2(column * 4, startPosPadsY);
		  //    }
		  //    else if (randomNr == 5)
		  //    {
		  //        pos = new Vector2(column * 5, startPosPadsY);
		  //    }

		  //    pads.Add(new Pad(pos, size));
		  //}

        public void Update(GameTime gT)
        {
				// Intervall för spawning av nya pads
				if( counter <= 0 )
				{
					AddNewPad_Normal( -Constants.PAD_HEIGHT );// spawna ny omgång pads
					counter = Constants.rand.Next( 4500, 5501 );
				}
				else
					counter -= gT.ElapsedGameTime.TotalMilliseconds;

				// Uppdatera spelarlistan
				//			ej implementerad

				// Uppdaterar padslistan
				foreach( Pad p in pads )
					p.Update( gT );			
				
				// Tar bort döda pads
				for( int i = 0; i < pads.Count; ++i )
					if( !pads[i].Alive )
					{
						pads.RemoveAt(i);
						--i;
					}				
#region
				// Kontrollerar kollision med spelare
				//		ej implementerad atm...


            // Uppdaterar listan med plattformar
				//foreach (Pad p in pads)
				//{
				//    p.Update(gameTime);

				//    if (p.pos.Y > Constants.SCREEN_HEIGHT)
				//    {
				//        CreateAPad(p.pos, padSize);
				//        pads.Remove(p);
				//        break;
				//    }
				//}
#endregion;
        }

		  private void AddNewPad_Normal( float yPos )
		  {
				// slumpar fram hur många pads som ska spawnas denna omgång.
				int nbrOfPads = Constants.rand.Next( 1, 6 ); 
				
				// delar in skärmen i nbrOfPads antal kolumner. 
				int spawnzone = Constants.SCREEN_WIDTH / nbrOfPads; 

				// För varje kolumn spawnas 1 st pad tills alla kolumner fått en pad..
				for( int i = 0; i < nbrOfPads; ++i )
				{
					// modifierar bredden på padden
					int padModWidth = Constants.PAD_WIDTH * Constants.rand.Next( 1, Constants.PAD_SIZEMOD - nbrOfPads +1 ); 
					
					// Räknar ut spawnpositionen för padden genom att (för nuvarande kollumn) först ta bort 10 px på varje sida. Sen tas även paddens (den pad
					// som ska läggas till i kolumnen) bredd bort från kollumnens storlek. Sen slumpas ett värde fram i det intervall som återstår av kollumnens
					//	bredd.
					Vector2 pos = new Vector2( Constants.rand.Next( spawnzone * i +10, (spawnzone * (i + 1) -9) - padModWidth ), yPos ); 
					
					// Lägger till den nya padden i pad-listan.
					pads.Add( new Pad( pos , new Point( padModWidth, Constants.PAD_HEIGHT ) ) );
				}
				// NOTE! 
				//		Kolumnerna är fiktiva och finns ej som variabler eller liknande. Det är bara ett sätt för att se till att padsen inte spawnar ovanpå varandra
				//		eller alldeles för nära i bredd. 	
		  }

        public void Draw(SpriteBatch sB)
        {
            // ritar ut plattformarna
            foreach (Pad p in pads)
            {
                p.Draw(sB);
            }
        }
    }
}
