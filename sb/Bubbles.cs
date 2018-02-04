using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Bubbles : StoryboardObjectGenerator
    {

        public override void Generate()
        {
            List<Color4> colors = new List<Color4>(){
            };

            colors.Add(new Color4(0,65,130,100));
            colors.Add(new Color4(102,151,253,100));
            colors.Add(new Color4(141,224,245,100));
            colors.Add(new Color4(14,147,154,100));

            var StartScale = 0.5;
            var Origin = OsbOrigin.Centre;
            var Path = "sb/square.png";
            var layer = GetLayer("");
            var pool = new OsbSpritePool(layer,Path, Origin);

            //52793
            //54974
            var offset = 20;
            var duration2 = 800;
            var startTime = 35338;
            for(int time = startTime; time < 52793 ; time = time + offset){


                var endtime = time + duration2 + Random(0,500);
                var sprite = pool.Get(time,endtime);
                if(endtime > 52793 ){
                    sprite.Fade(52793,0);
                    
                }
                else{
                    sprite.Fade(endtime,0);
                }
                sprite.Fade(time,1);
                sprite.Color(time, Color4.White);
                sprite.Scale(time,StartScale + Random(-0.3,0.3));
                sprite.Rotate(time,endtime,0,Random(-5,5));
                var startPositionX = Random(-88,725);
                var startPositionY = 550;
                var endPositionX = startPositionX + Random(-50 , 50);
                var endPositionY = -64;
                sprite.Move((OsbEasing)Random(1, 3),time,endtime,startPositionX,startPositionY,endPositionX,endPositionY);

                
                //459,191
            }

            startTime = 54702;
            for(int time = startTime; time < 69156 ; time = time + offset){


                var endtime = time + duration2 + Random(0,500);
                var sprite = pool.Get(time,endtime);
                sprite.Fade(endtime,0);
                sprite.Fade(time,1);
                var r = Random(0,colors.Count);
                sprite.Color(time,colors[r]);
                sprite.Scale(time,StartScale + Random(-0.3,0.3));
                sprite.Rotate(time,endtime,0,Random(-5,5));
                var startPositionX = Random(-88,725);
                var startPositionY = 550;
                var endPositionX = startPositionX + Random(-50 , 50);
                var endPositionY = -64;
                sprite.Move((OsbEasing)Random(1, 3),time,endtime,startPositionX,startPositionY,endPositionX,endPositionY);

                
                //459,191
            }

            startTime = 70247;
            for(int time = startTime; time < 87702 ; time = time + offset){


                var endtime = time + duration2 + Random(0,500);
                var sprite = pool.Get(time,endtime);
                sprite.Fade(endtime,0);
                sprite.Fade(time,1);
                var r = Random(0,colors.Count);
                sprite.Color(time,colors[r]);
                sprite.Scale(time,StartScale + Random(-0.3,0.3));
                sprite.Rotate(time,endtime,0,Random(-5,5));
                var startPositionX = Random(-88,725);
                var startPositionY = 550;
                var endPositionX = startPositionX + Random(-50 , 50);
                var endPositionY = -64;
                sprite.Move((OsbEasing)Random(1, 3),time,endtime,startPositionX,startPositionY,endPositionX,endPositionY);

                
                //459,191
            }
        }
    }
}
