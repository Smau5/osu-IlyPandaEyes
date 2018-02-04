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
    public class Background : StoryboardObjectGenerator
    {

        public override void Generate()
        {
            var BackgroundPath = Beatmap.BackgroundPath;
            var bitmap = GetMapsetBitmap(BackgroundPath);
            var bgBlur1 = GetLayer("BGBlur").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bgBlur1.Scale(17883, 480.0f / bitmap.Height);
            bgBlur1.Move(17883,34792,new Vector2(318,240),new Vector2(320,240));
            bgBlur1.Fade(17883, 34792, 0, 0.3);
            bgBlur1.Fade(34793,0);

            var mask = GetLayer("mask").CreateSprite("sb/MaskHighlight.png", OsbOrigin.Centre);
            var bitmapMask = GetMapsetBitmap("sb/MaskHighlight.png");
            mask.Scale(70247,480.0f / bitmapMask.Height);
            mask.Fade(70247,0.4);
            mask.Fade(87702,87156,0.4,0);

            var bgBlur2 = GetLayer("BGBlur").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bgBlur2.Scale(17883, 480.0f / bitmap.Height);
            bgBlur2.Move(17883,34792,new Vector2(322,240),new Vector2(321,240));
            bgBlur2.Fade(17883, 34792, 0, 0.3);
            bgBlur2.Fade(34793,0);

            var bgMain = GetLayer("BGMain").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bgMain.Scale(35338, 480.0f / bitmap.Height);
            bgMain.Fade(35338,1);

            bgMain.Fade(68065,69702,1,0);
            //bgMain.Fade(87702, 95660, 1, 0);

            var bgBlurMain = GetLayer("BGBlurMain").CreateSprite("sb/blur.jpg", OsbOrigin.Centre);
            bgBlurMain.Scale(70247, 480.0f / bitmap.Height);
            bgBlurMain.Fade(70247,1);
            bgBlurMain.Fade(87156,87702,1,0);
 


            var duration = 200;
            List<double> kickTimes = new List<double>(){
                35338,35883,36429,36974,
                37520,38065,38611,39156,
                39702,40247,40793,41338,
                41883,42429,42974,43520,
                44065,44611,45156,45702,
                46247,46793,47338,47883,
                48429,48974,49520,50065,
                50611,51156,51702,52247,
                52793,54429,
                54974,55520,56065,56611,
                57156,57702,58247,58793,
                59338,59883,60429,60974,
                61520,62065,62611,63156,
                63702,64247,64793,65338,
                65883,66429,66974,67520,
                68065,68611,69156,
                70247,70793,71338,71883,
                72429,72974,73520,74065,
                74611,75156,75702,76247,
                76793,77338,77883,78429,
                78974,79520,80065,80611,
                81156,81702,82247,82793,
                83338,83883,84429,84974,
                85520,86065,86611,87156,
            };
            var bgKick = GetLayer("BGKick").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bgKick.Scale(35338, 480.0f / bitmap.Height);

            for(int i = 0 ; i < kickTimes.Count;i++){
                if(kickTimes[i] <70247){
                    bgKick.Fade(kickTimes[i],kickTimes[i] + duration,0.5,0);
                    bgKick.Scale(kickTimes[i],kickTimes[i] + duration,480.0f / bitmap.Height + 0.01,480.0f / bitmap.Height);
                }
                else{
                    bgKick.Fade(kickTimes[i],kickTimes[i] + duration,0.5,0);
                    bgKick.Scale(kickTimes[i],kickTimes[i] + duration,480.0f / bitmap.Height ,480.0f / bitmap.Height+ 0.02);
                }

            }



            var black = GetLayer("black").CreateSprite("sb/white.jpg",OsbOrigin.Centre);
            bitmap = GetMapsetBitmap("sb/white.jpg");
            black.Scale(34793,480.0f / bitmap.Height);
            black.Color(34793,Color4.Black);
            black.Fade(34793,1);
            black.Fade(35338,0);

            

        }
    }
}
