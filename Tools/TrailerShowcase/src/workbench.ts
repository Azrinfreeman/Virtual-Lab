import {SHOTS,SFX} from './data/timeline';
import {Showcase} from './Showcase';
import {GameplayShot} from './components/GameplayShot';
import {LogoShrinkWordmarkLockup} from './components/LogoShrinkWordmarkLockup';
import {audioFrom,OUTPUT_AUDIO_OFFSET_F} from './data/audio-timing';
export const WORKBENCH={
 name:'BioNutri-MM · Gameplay showcase',fps:60,width:1920,height:1080,total:3600,background:'#14103F',
 shots:Object.values(SHOTS).map(s=>s.id==='brand'?{id:s.id,label:'BioNutri-MM',from:s.startFrame,duration:s.durationInFrames,component:LogoShrinkWordmarkLockup}:{id:s.id,label:s.narrativeGoal,from:s.startFrame,duration:s.durationInFrames,component:GameplayShot,props:{shot:s,caption:s.caption},durationProp:'duration',schema:[{type:'textarea',key:'caption',label:'Caption',default:s.caption}]}),
 captions:[],transitions:[],overlays:[],sfx:SFX.map(s=>({...s,from:audioFrom(s.from,s.src)})),
 bgm:[{from:0,trimBefore:Math.round(OUTPUT_AUDIO_OFFSET_F),duration:3600,src:'audio/score.wav',volume:1}],original:Showcase,
};
