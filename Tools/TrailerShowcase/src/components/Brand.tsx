import React from 'react';
import {CanvasImage, staticFile} from 'remotion';

export const FONT = {sans: 'Liberation, Arial, sans-serif'};
export const BRAND = {name: 'BioNutri-MM', font: 'PurpleSmile, sans-serif'};
export const PITCH = {en: {motto: 'Belajar. Eksperimen. Fahami.'}};
export const ShotcraftMark: React.FC<{size:number;tone?:string;style?:React.CSSProperties}> = ({size,style}) =>
  <CanvasImage src={staticFile('brand/logo.png')} style={{width:size,height:size,objectFit:'contain',...style}}/>;
export const Vignette: React.FC<{strength:number;inner:number;color:string}> = ({strength}) =>
  <div style={{position:'absolute',inset:0,pointerEvents:'none',background:`radial-gradient(ellipse at center, transparent 45%, rgba(0,0,0,${strength * .4}) 100%)`}}/>;
export const Grain: React.FC<{opacity:number;blend:string}> = () => null;
