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
    public class Lazer : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var pool = new OsbSpritePool(GetLayer(""),"sb/Lhighlight.png", OsbOrigin.Centre);

            var startTime = 69702;
            var endTime = 87702;
            var duration = 500;
            //final level
            List<double> times = new List<double>(){
                72157,74338,74884,76520,77065,78702,80884,83066,83611,85248,85793,87429,

                72156,80883,83065,85247,85792,

                76519,77066,78701,87428
            }
            ;


            var offset = 20;
            bool w = true;
            foreach (var currentHitobject in Beatmap.HitObjects){
                if(currentHitobject.StartTime >= startTime && currentHitobject.StartTime <= endTime){
                    var end = currentHitobject.StartTime + duration;
                    var start = currentHitobject.StartTime;
                    var cursor = pool.Get(start, end);
                    cursor.Fade(0,0);
                    cursor.ScaleVec(start,2,4);
                    cursor.Fade(start,end,1, 0);
                    cursor.MoveY(start,currentHitobject.Position.Y);
                    cursor.Rotate(start,1.5708);

                    if(times.Contains(start)){
                        for(int i = 0 ; i < 10 ; i++){
                            var startExtra = start + i*offset;
                            var extra = pool.Get(startExtra,end);
                            extra.Fade(0,0);
                            extra.Fade(startExtra,end,1 - i*0.1,0);
                            extra.ScaleVec(startExtra,2,4);
                            extra.Rotate(startExtra,1.5708);
                            if(w == true){
                                extra.MoveY(startExtra,currentHitobject.Position.Y - 4 * i);
                                w= false;
                            }
                            else{
                                extra.MoveY(startExtra,currentHitobject.Position.Y + 4 * i);
                                w = true;
                            }
                            

                        }
                    }

                }
            }
            
        }
    }
}
