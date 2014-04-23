using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
    /*
       Object är huvudklassen både för spelarnas karaktärer ( "Unit" ) och för platformarna ( "Pads" ).
       Innehåller mekanik för att hantera gravitationens verkan på objekt över tid.
   
       AG-Lista - Se Game1 (längst ner)
    */
    class Object
    {
        // Variable(s)
        public bool Alive { protected set; get; }
        public Rectangle HitBox { protected set; get; }
        public Vector2 pos; // objektets position
        protected Vector2 vel; // objektets riktningsvektor både i x- och y-led.
        protected Vector2 acc; // objektets hastighetsökning.
        protected Texture2D tex; // objektets texture
       // protected Rectangle source; 


        // Constructor
        public Object(Vector2 pos, Vector2 vel, Vector2 acc)
        {
            this.pos = pos;
            this.vel = vel;
            this.acc = acc;
            Alive = true;
        }


        // Method(s)
        public virtual void Update(GameTime gT)
        {
            Gravity(gT);
        }

        public virtual void Draw(SpriteBatch sB)
        {
            // Grundläggande ritmetod, endast tillagd för att alla objekt skall ha en sådan. Gör absolut ingenting.
        }

        // Hanterar gravitationens påverkan på objektet över tid.
        protected virtual void Gravity(GameTime gT)
        {
            pos.Y += vel.Y * (float)gT.ElapsedGameTime.TotalSeconds + ((acc.Y * (float)Math.Pow(gT.ElapsedGameTime.TotalSeconds, 2)) / 2); 
            vel.Y += acc.Y * (float)gT.ElapsedGameTime.TotalSeconds;   
        
        }
    }
}
