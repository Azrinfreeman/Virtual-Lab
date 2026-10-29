import fs from 'node:fs';
import path from 'node:path';
import {bundle} from '@remotion/bundler';
import {openBrowser,selectComposition,renderStill} from '@remotion/renderer';
const frames=[45,260,360,560,650,1140,1245,1600,1695,2050,2145,2350,2445,2800,2900,3230,3345,3560];
const serveUrl=await bundle({entryPoint:path.resolve('src/index.ts'),outDir:path.resolve('out/qa-bundle'),rspack:true});
const browser=await openBrowser('chrome');
const errors=[];
try{
 const composition=await selectComposition({serveUrl,id:'BioNutriShowcase',inputProps:{bgm:true},puppeteerInstance:browser});
 fs.mkdirSync('out/qa/frames',{recursive:true});
 for(const frame of frames){
  await renderStill({serveUrl,composition,frame,scale:.5,imageFormat:'png',output:`out/qa/frames/${String(frame).padStart(4,'0')}.png`,inputProps:{bgm:true},puppeteerInstance:browser,onBrowserLog:log=>{if(log.type==='error')errors.push(log.text)}});
  console.log(`QA still ${frame}`);
 }
 fs.writeFileSync('out/qa/still-results.json',JSON.stringify({frames,dimensions:[960,540],fps:60,duration:60,errors},null,2));
}finally{await browser.close({silent:true});}
