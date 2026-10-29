import React from 'react';
import {Audio} from '@remotion/media';
import {AbsoluteFill,Sequence,staticFile} from 'remotion';
import {SHOTS,SFX} from './data/timeline';
import {GameplayShot} from './components/GameplayShot';
import {LogoShrinkWordmarkLockup} from './components/LogoShrinkWordmarkLockup';
import {theme} from './theme';
import {audioFrom,OUTPUT_AUDIO_OFFSET_F} from './data/audio-timing';

export type ShowcaseProps={bgm:boolean};
export const Showcase:React.FC<ShowcaseProps>=({bgm=true})=><AbsoluteFill style={{background:theme.colors.base}}>
 <Sequence name="Laboratory hook" from={SHOTS.hook.startFrame} durationInFrames={SHOTS.hook.durationInFrames}><GameplayShot shot={SHOTS.hook}/></Sequence>
 <Sequence name="Eight activities" from={SHOTS.menu.startFrame} durationInFrames={SHOTS.menu.durationInFrames}><GameplayShot shot={SHOTS.menu}/></Sequence>
 <Sequence name="Guided transfer" from={SHOTS.transfer.startFrame} durationInFrames={SHOTS.transfer.durationInFrames}><GameplayShot shot={SHOTS.transfer}/></Sequence>
 <Sequence name="Observe" from={SHOTS.observation.startFrame} durationInFrames={SHOTS.observation.durationInFrames}><GameplayShot shot={SHOTS.observation}/></Sequence>
 <Sequence name="Vitamin C" from={SHOTS.vitamin.startFrame} durationInFrames={SHOTS.vitamin.durationInFrames}><GameplayShot shot={SHOTS.vitamin}/></Sequence>
 <Sequence name="Digestive system" from={SHOTS.anatomy.startFrame} durationInFrames={SHOTS.anatomy.durationInFrames}><GameplayShot shot={SHOTS.anatomy}/></Sequence>
 <Sequence name="Healthy plate" from={SHOTS.plate.startFrame} durationInFrames={SHOTS.plate.durationInFrames}><GameplayShot shot={SHOTS.plate}/></Sequence>
 <Sequence name="Check understanding" from={SHOTS.quiz.startFrame} durationInFrames={SHOTS.quiz.durationInFrames}><GameplayShot shot={SHOTS.quiz}/></Sequence>
 <Sequence name="BioNutri-MM lockup" from={SHOTS.brand.startFrame} durationInFrames={SHOTS.brand.durationInFrames}><LogoShrinkWordmarkLockup/></Sequence>
 {bgm&&<Audio src={staticFile('audio/score.wav')} trimBefore={Math.round(OUTPUT_AUDIO_OFFSET_F)}/>}
 {SFX.map((s,i)=><Sequence key={i} name={s.reason} from={audioFrom(s.from,s.src)} durationInFrames={s.duration}><Audio src={staticFile(s.src)} volume={s.volume}/></Sequence>)}
</AbsoluteFill>;
