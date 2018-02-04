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
    public class Click : StoryboardObjectGenerator
    {
        [Configurable]
        public int FadeTime = 200;  
        [Configurable]
        public double scaleStart = 1;  
        [Configurable]
        public double scaleEnd = 1.5;  
        [Configurable]
        public string SpritePath = "sb/ring.png";
        [ConfigurableAttribute]
        public Color4 color = Color4.White;
        public override void Generate()
        {
            var layer = GetLayer("click");
            var pool = new OsbSpritePool(GetLayer("click"),SpritePath, OsbOrigin.Centre);


            var finalTime = 34793;
            List<double> startTimes = new List<double>(){

            };
            //last level
            List<double> startTimesLong = new List<double>(){
                454,1272,
                2635,3454,
                4817,5635,
                6999,7817,
                9181,9999,
                11363,12181,
                13544,14363,
                15726,16544,

                17884,18702,
                20066,20883,
                22247,23066,
                24429,25247,
                26611,27429,
                28793,29611,
                30975,31793,
                33157,33974,

                87702,88520,
                89884,90702,
                92065,92884,
                94247,95065
                


            }
            ;
            foreach (var hitobject in Beatmap.HitObjects)
            {
                for(int i = 0 ; i < startTimes.Count ; i++){

                    if (startTimes[i] == hitobject.StartTime)
                    {
                        var Cursor = pool.Get(startTimes[i],startTimes[i] + 1 + FadeTime);
                        //var Cursor = GetLayer("").CreateSprite(SpritePath,OsbOrigin.Centre,new Vector2(320,240));
                        Cursor.Color(startTimes[i],color);
                        Cursor.Fade(startTimes[i],1);
                        Cursor.Scale(OsbEasing.OutCubic,startTimes[i],startTimes[i] + FadeTime,scaleStart,scaleEnd);
                        Cursor.Fade(startTimes[i] + 1 , startTimes[i] + 1 + FadeTime, 1 ,0);
                        Cursor.Move(startTimes[i],hitobject.Position);
                    }
                    else{
                        continue;
                    }   
                }
                for(int i = 0 ; i < startTimesLong.Count ; i++){

                    if (startTimesLong[i] < hitobject.StartTime + 2 && startTimesLong[i] > hitobject.StartTime - 2)
                    {
                        var Cursor = pool.Get(startTimesLong[i],startTimesLong[i] + 1 + FadeTime * 2);
                        //var Cursor = GetLayer("").CreateSprite(SpritePath,OsbOrigin.Centre,new Vector2(320,240));
                        Cursor.Color(startTimesLong[i],color);
                        Cursor.Fade(startTimesLong[i],1);
                        Cursor.Scale(OsbEasing.OutCubic,startTimesLong[i],startTimesLong[i] + FadeTime * 2,scaleStart,scaleEnd * 1);
                        Cursor.Fade(startTimesLong[i] + 1 , startTimesLong[i] + 1 + FadeTime * 2, 1 ,0);
                        Cursor.Move(startTimesLong[i],hitobject.Position);
                    }
                    else{
                        continue;
                    }   
                }
                /*
                if(hitobject.StartTime == 17124){
                    var Cursor = GetLayer("").CreateSprite(SpritePath,OsbOrigin.Centre,new Vector2(320,240));
                    Cursor.Color(hitobject.StartTime,color);
                    Cursor.Fade(hitobject.StartTime,1);
                    Cursor.Move(hitobject.StartTime,hitobject.Position);
                    Cursor.Scale(hitobject.StartTime,hitobject.StartTime + FadeTime * 2 ,scaleStart ,scaleEnd * 1.5);
                    Cursor.Fade(hitobject.StartTime + 1 , hitobject.StartTime + FadeTime * 2 + 1, 1 ,0);
                }
                */

            }

        }
    }
}
