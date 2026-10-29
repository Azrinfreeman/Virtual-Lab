import React from 'react';
import {Video} from '@remotion/media';
import {AbsoluteFill,Easing,interpolate,staticFile,useCurrentFrame} from 'remotion';
import {theme} from '../theme';
import type {Shot} from '../data/timeline';

export const GameplayShot:React.FC<{shot:Shot;duration?:number;caption?:string}>=({shot,duration=shot.durationInFrames,caption=shot.caption})=>{
 const f=useCurrentFrame();
 const enter=interpolate(f,[14,35],[0,1],{extrapolateLeft:'clamp',extrapolateRight:'clamp',easing:Easing.out(Easing.cubic)});
 const exit=interpolate(f,[duration-14,duration-1],[1,0],{extrapolateLeft:'clamp',extrapolateRight:'clamp'});
 return <AbsoluteFill style={{background:theme.colors.base,fontFamily:theme.font,color:theme.colors.text}}>
  <Video src={staticFile(shot.assetRefs[0])} trimBefore={shot.sourceStart??0} muted objectFit="contain" style={{position:'absolute',left:120,top:0,width:1680,height:945}}/>
  <div style={{position:'absolute',left:100,right:100,top:972,textAlign:'center',fontSize:42,lineHeight:1.2,opacity:enter*exit,translate:`0 ${interpolate(enter,[0,1],[10,0])}px`}}>{caption}</div>
  {shot.disclosure && <div style={{position:'absolute',left:80,right:80,bottom:18,textAlign:'center',fontSize:23,color:theme.colors.secondary,opacity:exit}}>{shot.disclosure}</div>}
 </AbsoluteFill>;
};
